using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomersController:ControllerBase
{
    private readonly List<Customer>customers=new List<Customer>
        {
            new Customer{Id=1, Name="Nawras"},
            new Customer{Id=2, Name="Sara"},
            new Customer{Id=3, Name="Ahmad"}
            
        };
[HttpGet]
public List<Customer> GetCustomers()
    {

        return customers;
    }
[HttpGet("{id}")]
public Customer? GetCustomer(int id)
{
    var customer=customers.FirstOrDefault(c=>c.Id==id);
    return customer;
}
}
