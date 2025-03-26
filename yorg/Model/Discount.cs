using System.ComponentModel.DataAnnotations.Schema;

namespace yorg.Model;

public class Discount
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string Code { get; set; }
    
    public int MaxUser { get; set; }
    
    public int Used { get; set; }
    
    public bool Active { get; set; }
    
    public decimal Percentage { get; set; }
    
    public DateTime StartsAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();

}