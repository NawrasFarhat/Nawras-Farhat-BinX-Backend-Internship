public class Order
{
    public int Id{get;set;}
    public decimal Total{get;set;}

    public int CustomerId{get;set;}
    public List<OrderItem> Items {get;set;}=new();

}