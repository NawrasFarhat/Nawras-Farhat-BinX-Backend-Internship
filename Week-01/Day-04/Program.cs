static void Notify(INotification notification)
{
    notification.send();
}
Customer C =new Customer(1, "Nawras", "nawras@gmail.com");
Notify(C);
Order O= new Order();
Notify(O);
List <Order> orders= new List<Order>();
orders.Add(new Order{OrderId=1,Total=100});
orders.Add(new Order{OrderId=2,Total=200});
orders.Add(new Order{OrderId=3,Total=300});
orders.Add(new Order{OrderId=4,Total=400});
orders.Add(new Order{OrderId=5,Total=500});
orders.Add(new Order{OrderId=6,Total=600});
orders.Add(new Order{OrderId=7,Total=700});
orders.Add(new Order{OrderId=8,Total=800});

var filterOrders= orders.Where(Order=>Order.Total>400);
foreach(var o in filterOrders)
{
    Console.WriteLine($"OrderId= {o.OrderId}, Total= {o.Total}");
}

var orderIds= orders.Select(order=>order.OrderId);
foreach(var id in orderIds)
{
    Console.WriteLine(id);
}

var totalSum= orders.Sum(order=>order.Total);
Console.WriteLine($"Total Sum= {totalSum}");

string result= await GetOrderData();

Console.WriteLine("Enter OrderId:");
string? input= Console.ReadLine();
try
{
    int orderId=int.Parse(input);
    Console.WriteLine(orderId);
}
catch(FormatException)
{
    Console.WriteLine("Invalid OrderId");
}
catch(ArgumentNullException)
{
    Console.WriteLine("OrderId can't be null");   
}


static async Task<string> GetOrderData()
{
    await Task.Delay(2000);
    return "Order data Loaded";
}
class Customer:INotification
{
    private string name="";
    private string email="";
    public int CustomerId{get;set;}
    public string Name
    {
        get{return name;}
        set{name=value;}
    }
    public string Email
    {
    get{return email;}
    set{email=value;}
    }
public Customer(int customerId, string name, string email)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty");
        }
        CustomerId=customerId;
        Name=name;
        Email=email;
        
    }
public void send()
    {
        Console.WriteLine("Costumer notification send");
    }
}

class Order:INotification
{
    public int OrderId{get;set;}
    public decimal Total{get;set;}
    public Customer? Customer{get;set;}
public void send()
    {
        Console.WriteLine("Order notification send");
    }
}

public record  CreatOrderRequest(int CustomerId, decimal Total);
interface INotification
{
    void send();
}
