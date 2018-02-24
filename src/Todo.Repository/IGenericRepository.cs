using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Model;

namespace Todo.DataAccess
{
    public interface IGenericRepository<TEntity> where TEntity : class, IModel, new()
    {
        Task InsertAsync(TEntity entity);

        Task<TEntity> GetAsync(Guid id);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(TEntity entity);
    }
}
