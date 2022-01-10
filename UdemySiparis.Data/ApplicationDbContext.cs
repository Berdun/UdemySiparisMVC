using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UdemySiparis.Models;

namespace UdemySiparis.Data
{
     public class ApplicationDbContext : IdentityDbContext
     {
          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
          {
          }
          public DbSet<AppUser> AppUsers { get; set; }
          public DbSet<Cart> Carts { get; set; }
          public DbSet<Category> Categories { get; set; }
          public DbSet<OrderDetails> OrderDetails { get; set; }
          public DbSet<OrderProduct> OrderProducts { get; set; }
          public DbSet<Product> Products { get; set; }  
     }
}