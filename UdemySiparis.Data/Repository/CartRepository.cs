using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemySiparis.Data.Repository.IRepository;
using UdemySiparis.Models;

namespace UdemySiparis.Data.Repository
{
     public class CartRepository : Repository<Cart>, ICartRepository
     {
          private ApplicationDbContext _context;
          public CartRepository(ApplicationDbContext context) : base(context)
          {
               _context = context;
          }

     }
}
