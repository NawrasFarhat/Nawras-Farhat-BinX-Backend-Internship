static void Notify(INotification notification)
{
    notification.send();
}
Customer C =new Customer(1, "Nawras", "nawras@gmail.com");
Notify(C);
Order O= new Order();
Notify(O);

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
