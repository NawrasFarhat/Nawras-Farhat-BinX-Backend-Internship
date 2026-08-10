using System.Runtime.CompilerServices;

List<Customer>customers=new();
customers.Add(new Customer{Id=1, Name="Nawras"});
customers.Add(new Customer{Id=2, Name="Sara"});
customers.Add(new Customer{Id=3, Name="Lana"});
customers.Add(new Customer{Id=4, Name="Ahmad"});
customers.Add(new Customer{Id=5, Name="Salma"});
customers.Add(new Customer{Id=6, Name="Yara"});


List<Order>orders=new();
orders.Add(new Order{Id=1, Total=100, CustomerId=1, Items=new List<OrderItem>(){new OrderItem{Id =1, Name="Laptop", Price=50}, new OrderItem{Id =2, Name="Mouse", Price=60}}});
orders.Add(new Order{Id=2, Total=200, CustomerId=2, Items=new List<OrderItem>(){new OrderItem{Id =2, Name="Keybord", Price=70}, new OrderItem{Id =2, Name="Charger", Price=80}}});
orders.Add(new Order{Id=3, Total=300, CustomerId=3});
orders.Add(new Order{Id=4, Total=400, CustomerId=4});
orders.Add(new Order{Id=5, Total=500, CustomerId=3});
orders.Add(new Order{Id=6, Total=100, CustomerId=1});
var groupedOrder=orders.GroupBy(order=>order.CustomerId);

foreach(var group in groupedOrder)
{
    decimal totalAmount = group.Sum(order=>order.Total);
    Console.WriteLine($"CostomerId: {group.Key}, Total: {totalAmount}");

}

var customerOrders= customers.Join(
orders,
customer=>customer.Id,
order=>order.CustomerId,
(customer , order)=>new
{
    customer.Name,
    order.Total
}

);
foreach(var customerOrder in customerOrders)
{
    Console.WriteLine($"CustomerOrder= {customerOrder.Name}, {customerOrder.Total}");
}

var allitems=orders.SelectMany(order=>order.Items);
foreach(var item in allitems)
{
    Console.WriteLine($"item:{item.Name}, price: {item.Price}");
}
// The new order appears in the result because the query
// is executed during the foreach, not when it is defined.
// This demonstrates deferred execution.
var query=orders.Where(order=>order.Total>200);
orders.Add(new Order{Id=7, Total=700, CustomerId=5});
foreach(var o in query)
{
    Console.WriteLine($"OrderId: {o.Id}, orderTotal: {o.Total}");
}