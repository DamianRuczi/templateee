using Microsoft.EntityFrameworkCore;
using template.Data;
using template.DTOs;

namespace template.Services;

public interface IDbService
{
    public Task<IEnumerable<GetPurchasesDto>> GetPurchases();
}

public class DbService(MyDbContext data) : IDbService
{
    public async Task<IEnumerable<GetPurchasesDto>> GetPurchases()
    {
        var customers = await data.Customers
            .Include(c => c.PurchaseHistories)
            .ThenInclude(ph => ph.AvailableProgram)
            .ThenInclude(ap => ap.WashingMachine)
            .ToListAsync();;

        return null;
    }
}