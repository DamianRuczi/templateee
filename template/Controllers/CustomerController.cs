using Microsoft.AspNetCore.Mvc;
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
}