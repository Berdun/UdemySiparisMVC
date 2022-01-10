using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemySiparis.Data.Repository.IRepository;
using UdemySiparis.Models;

namespace UdemySiparis.Data.Repository
{
     public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
     {
          private ApplicationDbContext _context;
          public OrderDetailsRepository(ApplicationDbContext context) : base(context)
          {
               _context = context;
          }
     }
}
