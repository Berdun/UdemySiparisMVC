using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemySiparis.Data.Repository.IRepository;
using UdemySiparis.Models;

namespace UdemySiparis.Data.Repository
{
     public class CategoryRepository : Repository<Category>, ICategoryRepository
     {
          private ApplicationDbContext _context;
          public CategoryRepository(ApplicationDbContext context) : base(context)
          {
               _context = context;
          }
     }
}
