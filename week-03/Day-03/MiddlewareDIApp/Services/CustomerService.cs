public class CustomerService:ICustomerService
{
    public List<Customer> GetCustomers()
    {
        return new List<Customer>
        {
            new Customer{Id=1, Name="Nawras"},
            new Customer{Id=2, Name="Sara"},
            new Customer{Id=3, Name="Ahmad"}
        };
    }
}