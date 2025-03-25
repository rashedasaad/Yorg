namespace yorg.Model;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public string ShippingAddress { get; set; }
    public string PaymentMethod { get; set; }
    public Guid? DiscountId { get; set; }
    public Discount Discount { get; set; }
    
}