public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
}

public class CustomerSummaryDto
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public int TotalOrders { get; set; }
    public decimal TotalSpend { get; set; }
}