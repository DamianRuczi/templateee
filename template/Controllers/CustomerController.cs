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
}