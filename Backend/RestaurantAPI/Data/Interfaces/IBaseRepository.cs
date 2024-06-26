using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);
        public Task Add(T entity);
        public Task AddBatch(IEnumerable<T> entities);
        public Task Update(T entity);
        public Task Delete(T entity);
        public Task ExecuteInTransaction(Func<Task> operation);

    }
}
