using System.ComponentModel.DataAnnotations.Schema;

namespace yorg.Model;

public class Refund
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; } 

    public decimal Amount { get; set; }

    public DateTime RefundDate { get; set; }

    public string Reason { get; set; } 

    public string Status { get; set; } = "Pending"; 

    public List<RefundOrderItem> RefundOrderItems { get; set; } = new List<RefundOrderItem>(); 
}