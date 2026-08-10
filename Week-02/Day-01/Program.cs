using System.Data.Common;

Repository<Customer> CustomerRepo=new();

Customer Customer1=new Customer{Id=1, Name="Nawras"};
CustomerRepo.add(Customer1);

Customer Customer2=new Customer{Id=2, Name="Lara"};
CustomerRepo.add(Customer2);

IReadOnlyList<Customer>Customers=CustomerRepo.GetAll();

foreach(Customer customer in Customers)
{
    Console.WriteLine($"CustomerId= {customer.Id}, CustomerName= {customer.Name}");
}
 Customer? foundCustomer=CustomerRepo.Find(customer=>customer.Id==1);
if(foundCustomer!=null)
{
    Console.WriteLine($"FoundCustomer: {foundCustomer.Name}");
}

Repository<Order> OrderRepo=new();
Order order1=new Order{Id=1, Total=100};
OrderRepo.add(order1);

Order order2=new Order{Id=2, Total=200};
OrderRepo.add(order2);

IReadOnlyList<Order>orders=OrderRepo.GetAll();
foreach(Order order in orders)
{
    Console.WriteLine($"OrderId= {order.Id}, OrderTotal= {order.Total}");
}

Order? foundOrder=OrderRepo.Find(order=>order.Id==2);
if(foundOrder!=null)
{
    Console.WriteLine($"FoundOrder= {foundOrder.Id}");
}
