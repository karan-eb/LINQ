// int [] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
// var evenNumbers = from n in numbers
//                   where n % 2 == 0
//                   select n;

// var evenNumbersWithMethodSyntax = numbers.Where(num => num % 2 ==0);
//                   foreach(var num in evenNumbers)
//                   {
//                     Console.WriteLine(num);
//                   }



    List<Customer> customers = new List<Customer>
    {
        new Customer {Name = "John Doe", City = "New York"},
        new Customer {Name = "Christopher", City = "New York"},
        new Customer {Name = "Jane Smith", City = "Los Angeles"},
        new Customer {Name = "Michael Johnson", City = "Chicago"},
        new Customer {Name = "Amanda", City = "New York"},
        new Customer {Name = "Emily Davis", City = "New York"},
        new Customer {Name = "Anna Wilson", City = "New York"},
        new Customer {Name = "Zoe Anderson", City = "New York"},
    };

    // var nyCustomers = customers.Where(x =>x.City == "New York" && (x.Name.StartsWith("J") || x.Name.StartsWith("A"))).OrderBy(x => x.Name).Select(x => x.Name + " - " + x.City);
    // var otherCustomers = customers.Select(c => c.Name + " - " + c.City).Where(x => !x.Contains("New York"));
    // foreach(var customer in nyCustomers)
    // {
    //     Console.WriteLine(customer);
    // }

    //  foreach(var customer in otherCustomers)
    // {
    //     Console.WriteLine("others - " + customer);
    // }
 
 // Group by

 var customersByCity = customers.GroupBy(c => c.City);
 foreach (var group in customersByCity)
 {
     Console.WriteLine($"Customers in {group.Key}:");
     foreach (var customer in group)
     {
         Console.WriteLine($"- {customer.Name}");
     }
     Console.WriteLine();
 }