public class Order
{
    public int Id{get;set;}
    public decimal Total{get;set;}

    public int CustomerId{get;set;}
    public Customer Customer{get;set;}=null!;
}