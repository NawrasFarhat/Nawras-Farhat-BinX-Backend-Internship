using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/orders")]
public class OrderController:ControllerBase
{
    private static readonly List<Order> orders=new()
    {
        new Order{Id=1, Total=100, CustomerId=1},
        new Order{Id=2, Total=200, CustomerId=1},
        new Order{Id=3, Total=300, CustomerId=2},

    };
[HttpGet]
public IActionResult GetOrders()
    {
        return Ok(orders);
    }
[HttpGet("{id}")]

public IActionResult GetOrders(int id)
{
    var order= orders.FirstOrDefault(o=>o.Id==id);
    if(order==null)
    {
        return NotFound();
    }
    return Ok(order);

}

[HttpPost]
public IActionResult CreateOrder(Order order)
    {
        orders.Add(order);
        return CreatedAtAction(
            nameof(GetOrders),
            new{id=order.Id},
            order
        );
    }
[HttpPut("{id}")]
public IActionResult UpdatOrder(int id, Order updateOrder)
    {
        var order= orders.FirstOrDefault(o=>o.Id==id);
        if(order==null)
        {
            return NotFound();
        }
        order.Total=updateOrder.Total;
        order.CustomerId=updateOrder.CustomerId;
        return Ok(order);
    }
[HttpDelete("{id}")]
public IActionResult DeleteOrder(int id)
    {
        var order= orders.FirstOrDefault(o=>o.Id==id);
        if(order==null)
        {
            return NotFound();
        }
    orders.Remove(order);
    return NoContent();
        
    }

[HttpGet("/api/v1/customers/{CustomerId}/order")]
public IActionResult GetCustomerOrders(int CustomerId)
    {
        var customerOrders= orders.Where(o=>o.CustomerId==CustomerId).ToList();
        return Ok(customerOrders);
    } 
}