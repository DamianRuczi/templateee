using template.Models;

namespace template.DTOs;

public class GetPurchasesDto
{
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String? PhoneNumber { get; set; }
    public IEnumerable<PurchaseDto> Purchases { get; set; }
}

public class PurchaseDto
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public decimal Price { get; set; }
    public WashingMachineDto WashingMachine { get; set; } = null!;
    public WashingProgramDto Program { get; set; } = null!;
}

public class WashingMachineDto
{
    public string Serial { get; set; } = null!;
    public decimal MaxWeight { get; set; }
}

public class WashingProgramDto
{
    public string Name { get; set; } = null!;
    public int Duration { get; set; }
}