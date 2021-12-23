using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemySiparis.Data.Repository.IRepository;
using UdemySiparis.Models;

namespace UdemySiparis.Data.Repository
{
     public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
     {
          private ApplicationDbContext _context;
          public OrderProductRepository(ApplicationDbContext context) : base(context)
          {
               _context = context;
          }
     }
}
