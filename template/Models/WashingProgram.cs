using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace template.Models;

[Table("Program")]
public class WashingProgram
{
    [Column("ProgramId")]
    [Key]
    public int ProgramId { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    public int DurationMinutes { get; set; }

    public int TemperatureCelsuis { get; set; }
    
    public virtual ICollection<AvailableProgram> AvailablePrograms { get; set; } = null!;
}