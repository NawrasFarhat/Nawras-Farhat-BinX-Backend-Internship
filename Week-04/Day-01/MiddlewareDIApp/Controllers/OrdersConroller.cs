using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("api/[Controller]")]
public class OrdersController:ControllerBase
    {
        private readonly AppDbContext _context;
        public OrdersController(AppDbContext context)
        {
            _context=context;
        }
[HttpPost]
public async Task<IActionResult> CreateOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOrder), new{id=order.Id, order});
    }

[HttpGet]
public async Task<IActionResult> GetOrder()
    {
        var orders=await _context.Orders.ToListAsync();
        if(orders==null)
        {
            return NotFound();
        }
        return Ok(orders);
    }
[HttpGet("{id}")]
public async Task<IActionResult>GetOrder(int id)
    {
        var orders=await _context.Orders.FindAsync(id);
                if(orders == null)
        {
            return NotFound();
        }
        return Ok(orders);
    }
[HttpPut("{id}")]
public async Task<IActionResult>UpdateOrder(int id, Order order)
    {
        if(id!= order.Id)
        {
            return BadRequest();
        }
        var existingOrder= await _context.Orders.FindAsync(id);
        if(existingOrder==null)
        {
            return NotFound();
        }
        existingOrder.Id=order.Id;
        existingOrder.Total=order.Total;
        await _context.SaveChangesAsync();
        return Ok(existingOrder);
    }
[HttpDelete("{id}")]
public async Task<IActionResult>DeleteOrder(int id)
    {
        var order=await _context.Orders.FindAsync(id);
        if(order==null)
        {
            return NotFound();
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    }
 