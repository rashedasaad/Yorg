namespace yorg.Model;

public class RefundOrderItem
{
    public Guid RefundId { get; set; }
    public Refund Refund { get; set; }

    public Guid OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; }
}