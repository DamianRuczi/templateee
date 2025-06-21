using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace template.Models;

[Table("Available_Program")]
public class AvailableProgram
{
    [Column("AvailableProgramId")]
    [Key]
    public int AvailableProgramId { get; set; }

    [Column("WashingMachineId")]
    public int WashingMachineId { get; set; }

    [Column("ProgramId")]
    public int ProgramId { get; set; }

    [Column("Price")]
    public decimal Price { get; set; }

    
    [ForeignKey(nameof(WashingMachineId))]
    public virtual WashingMachine WashingMachine { get; set; } = null!;

    [ForeignKey(nameof(ProgramId))]
    public virtual WashingProgram WashingProgram { get; set; } = null!;
    
    public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; } = null!;

}