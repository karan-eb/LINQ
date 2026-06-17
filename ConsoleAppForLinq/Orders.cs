public class Orders
{
    public int Id { get; set; }
    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }
    public List<OrderItems> ListItems { get; set; }
    public decimal Amount { get; set; }
}

public class OrderItems
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public float Cost { get; set; }
}