using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemySiparis.Models
{
     public class OrderDetails
     {
          public int Id { get; set; }
          public int OrderProductId { get; set; }
          public int ProductId { get; set; }
          public int Count { get; set; }
          public double Price { get; set; }

          [ForeignKey("OrderProductId")]
          public OrderProduct OrderProduct { get; set; }
          [ForeignKey("ProductId")]
          public Product Product { get; set; }

     }
}
