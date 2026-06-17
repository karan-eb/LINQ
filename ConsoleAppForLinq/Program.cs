using System.Xml.Linq;

// int [] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
// var evenNumbers = from n in numbers
//                   where n % 2 == 0
//                   select n;
// var evenNumbersWithMethodSyntax = numbers.Where(num => num % 2 == 0);
// foreach (var num in evenNumbers)
// {
//     Console.WriteLine(num);
// }

var data = LoadPracticeDatabase();

Console.WriteLine($"Loaded {data.Customers.Count} customers, {data.Products.Count} products, and {data.Orders.Count} orders from XML.");

var customersByCity = data.Customers.GroupBy(c => c.City);
foreach (var group in customersByCity)
{
    Console.WriteLine($"Customers in {group.Key}:");
    foreach (var customer in group)
    {
        Console.WriteLine($"- {customer.Name}");
    }

    Console.WriteLine();
}

static PracticeDatabase LoadPracticeDatabase()
{
    var xmlPath = Path.Combine(AppContext.BaseDirectory, "PracticeDatabase.xml");

    if (!File.Exists(xmlPath))
    {
        throw new FileNotFoundException($"Could not find the practice XML file at '{xmlPath}'.");
    }

    var document = XDocument.Load(xmlPath);

    return new PracticeDatabase
    {
        Customers = document.Root!
            .Element("Customers")!
            .Elements("Customer")
            .Select(customerElement => new Customer
            {
                Id = (int)customerElement.Attribute("Id")!,
                Name = (string)customerElement.Attribute("Name")!,
                City = (string)customerElement.Attribute("City")!
            })
            .ToList(),
        Products = document.Root!
            .Element("Products")!
            .Elements("Product")
            .Select(productElement => new Product
            {
                Id = (int)productElement.Attribute("Id")!,
                Name = (string)productElement.Attribute("Name")!,
                Price = (decimal)productElement.Attribute("Price")!,
                ExpiryDate = (DateTime)productElement.Attribute("ExpiryDate")!
            })
            .ToList(),
        Orders = document.Root!
            .Element("Orders")!
            .Elements("Order")
            .Select(orderElement => new Orders
            {
                Id = (int)orderElement.Attribute("Id")!,
                CustomerId = (int)orderElement.Attribute("CustomerId")!,
                OrderDate = (DateTime)orderElement.Attribute("OrderDate")!,
                Amount = (decimal)orderElement.Attribute("Amount")!,
                ListItems = orderElement
                    .Element("ListItems")?
                    .Elements("OrderItems")
                    .Select(itemElement => new OrderItems
                    {
                        Id = (int)itemElement.Attribute("Id")!,
                        OrderId = (int)itemElement.Attribute("OrderId")!,
                        ProductId = (int)itemElement.Attribute("ProductId")!,
                        Quantity = (int)itemElement.Attribute("Quantity")!,
                        Cost = (float)itemElement.Attribute("Cost")!
                    })
                    .ToList() ?? new List<OrderItems>()
            })
            .ToList()
    };
}

class PracticeDatabase
{
    public List<Customer> Customers { get; set; } = new();
    public List<Product> Products { get; set; } = new();
    public List<Orders> Orders { get; set; } = new();
}