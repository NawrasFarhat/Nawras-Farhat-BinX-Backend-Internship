using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext:IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext>options)
    : base(options)
    {
    }
    public DbSet<Customer> Customers{get;set;}
    public DbSet<Order>Orders {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Order>()
        .HasOne(o=>o.Customer)
        .WithMany(c=>c.orders)
        .HasForeignKey(o=>o.CustomerId);
    }
} 