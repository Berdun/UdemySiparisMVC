using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UdemySiparis.Data.Repository.IRepository
{
     public interface IRepository<T> where T : class
     {
          void Add(T entity);
          T GetFirstOrDefault(Expression<Func<T,bool>> filter,
               string? includeProperties = null);
          IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
               string? includeProperties = null);
          void Update(T entiy);
          void Remove(T entity);
          void RemoveRange(IEnumerable<T> entities);
     }
}
