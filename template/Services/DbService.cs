using Microsoft.EntityFrameworkCore;
using template.Data;
using template.DTOs;
using template.Exceptions;

namespace template.Services;

public interface IDbService
{
    public Task<GetPurchasesDto> GetPurchases(int customerId = 0);
    Task<IEnumerable<GetPurchasesDto>> GetCustomers();
    Task DeleteCustomerAsync(int customerId);
}

public class DbService(MyDbContext data) : IDbService
{
    public async Task<GetPurchasesDto> GetPurchases(int customerId = 0)
    {
        var customer = await data.Customers
            .Include(c => c.PurchaseHistories)
            .ThenInclude(ph => ph.AvailableProgram)
            .ThenInclude(ap => ap.WashingMachine)
            .Include(c => c.PurchaseHistories)
            .ThenInclude(ph => ph.AvailableProgram)
            .ThenInclude(ap => ap.WashingProgram)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
       
        if (customer == null)
        {
            return null;
        }
        
        var customerDto = new GetPurchasesDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = customer.PurchaseHistories.Select(ph => new PurchaseDto
            {
                Date = ph.PurchaseDate,
                Rating = ph.Rating,
                Price = ph.AvailableProgram.Price,
                WashingMachine = new WashingMachineDto
                {
                    Serial = ph.AvailableProgram.WashingMachine.SerialNumber,
                    MaxWeight = ph.AvailableProgram.WashingMachine.MaxWeight
                },
                Program = new WashingProgramDto
                {
                    Name = ph.AvailableProgram.WashingProgram.Name,
                    Duration = ph.AvailableProgram.WashingProgram.DurationMinutes
                }
            }).ToList()
        };

        return customerDto;
    }

    public async Task<IEnumerable<GetPurchasesDto>> GetCustomers()
    {
        var customers = await data.Customers
            .Include(c => c.PurchaseHistories)
            .ThenInclude(ph => ph.AvailableProgram)
            .ThenInclude(ap => ap.WashingMachine)
            .Include(c => c.PurchaseHistories)
            .ThenInclude(ph => ph.AvailableProgram)
            .ThenInclude(ap => ap.WashingProgram)
            .ToListAsync();
        
        if (!customers.Any())
        {
            throw new CustomersNotFoundException("No customers found in the database.");
        }

        var customerDtos = customers.Select(customer => new GetPurchasesDto()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = customer.PurchaseHistories.Select(ph => new PurchaseDto
            {
                Date = ph.PurchaseDate,
                Rating = ph.Rating,
                Price = ph.AvailableProgram.Price,
                WashingMachine = new WashingMachineDto
                {
                    Serial = ph.AvailableProgram.WashingMachine.SerialNumber,
                    MaxWeight = ph.AvailableProgram.WashingMachine.MaxWeight
                },
                Program = new WashingProgramDto
                {
                    Name = ph.AvailableProgram.WashingProgram.Name,
                    Duration = ph.AvailableProgram.WashingProgram.DurationMinutes
                }
            }).ToList()
        }).ToList();

        return customerDtos;
    }

    public async Task DeleteCustomerAsync(int customerId)
    {
        var customer = await data.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        if (customer == null)
        {
            throw new CustomersNotFoundException($"Customer with ID {customerId} not found.");
        }

        data.Customers.Remove(customer);
        await data.SaveChangesAsync();
    }
}