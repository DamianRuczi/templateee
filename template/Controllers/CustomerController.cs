using Microsoft.AspNetCore.Mvc;
using template.DTOs;
using template.Services;

namespace template.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController(IDbService dbService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPurchases()
    {
        var purchases = await dbService.GetPurchases();
        return Ok(purchases);
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
}