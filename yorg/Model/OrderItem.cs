using System.ComponentModel.DataAnnotations.Schema;

namespace yorg.Model;



public class OrderItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal TotalPrice => Quantity * Price;

    public List<RefundOrderItem> RefundOrderItems { get; set; } = new List<RefundOrderItem>();
}