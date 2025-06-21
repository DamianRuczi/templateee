using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace template.Models;

[Table("Washing_Machine")]
public class WashingMachine
{
    [Column("WashingMachineId")]
    [Key]
    public int WashingMachineId { get; set; }
    
    public decimal MaxWeight { get; set; }
    
    [MaxLength(100)]
    public String? SerialNumber { get; set; }
    
    public virtual ICollection<AvailableProgram> AvailablePrograms { get; set; } = null!;
}