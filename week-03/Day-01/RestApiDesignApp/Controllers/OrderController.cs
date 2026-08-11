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
}