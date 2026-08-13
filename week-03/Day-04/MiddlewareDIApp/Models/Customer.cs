public class Customer
{
    public int Id{get;set;}
    public string Name{get;set;}="";
    public ICollection<Order> orders {get;set;}=new List<Order>();

}