int [] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var evenNumbers = from n in numbers
                  where n % 2 == 0
                  select n;

                  foreach(var num in evenNumbers)
                  {
                    Console.WriteLine(num);
                  }