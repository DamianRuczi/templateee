using Microsoft.AspNetCore.Mvc;
using template.DTOs;
using template.Exceptions;
using template.Services;

namespace template.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController(IDbService dbService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        try
        {
            var customers = await dbService.GetCustomers();
            return Ok(customers);
        }
        catch (CustomersNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }

    [HttpGet("{customerId}/purchases")]
    public async Task<ActionResult<GetPurchasesDto>> GetCustomerPurchases(int customerId)
    {
        var customerDto = await dbService.GetPurchases(customerId);

        if (customerDto == null)
        {
            return NotFound();
        }

        return Ok(customerDto);
    }

    // TODO it's not deleting items cascade, eg. if customer has purchases this method does not delete purchases
    // to make it wokring, we should add 
    // modelBuilder.Entity<PurchaseHistory>()
    // .HasOne(ph => ph.Customer)
    //     .WithMany(c => c.PurchaseHistories)
    //     .HasForeignKey(ph => ph.CustomerId)
    //     .OnDelete(DeleteBehavior.Cascade);
    // in dbcontext
    [HttpDelete("{customerId}")]
    public async Task<IActionResult> DeleteCustomer(int customerId)
    {
        try
        {
            await dbService.DeleteCustomerAsync(customerId);
            return NoContent();
        }
        catch (CustomersNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
}