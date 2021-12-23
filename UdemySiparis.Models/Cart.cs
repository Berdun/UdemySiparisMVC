using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemySiparis.Models
{
     public class Cart
     {
          public Cart()
          {
               Count = 1;
          }

          [Key]
          public int Id { get; set; }

          public string AppUserId { get; set; }
          public int ProductId { get; set; }
          public int Count { get; set; }
          public double Price { get; set; }

          [ForeignKey("AppUserId")]
          public AppUser AppUser { get; set; }

          [ForeignKey("ProductId")]
          public Product Product { get; set; }

     }
}
