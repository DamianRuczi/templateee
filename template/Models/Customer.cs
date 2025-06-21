using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace template.Models;

[Table("Customer")]
public class Customer
{
    [Column("CustomerId")]
    [Key]
    public int CustomerId { get; set; }

    [Column("FirstName")]
    public string FirstName { get; set; } = string.Empty;

    [Column("LastName")]
    public string LastName { get; set; } = string.Empty;

    [Column("PhoneNumber")]
    public string? PhoneNumber { get; set; }
    
    public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; } = null!;
}