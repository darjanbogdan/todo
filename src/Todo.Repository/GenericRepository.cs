using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Model;
using Todo.DataAccess.Context;

namespace Todo.DataAccess
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IModel, new()
    {
        private readonly TodoDbContext dbContext;

        public GenericRepository(TodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task InsertAsync(TEntity entity)
        {
            this.dbContext.AddAsync(entity);

            return this.dbContext.SaveChangesAsync();
        }

        public Task<TEntity> GetAsync(Guid id)
        {
            return this.dbContext.FindAsync<TEntity>(id);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return this.dbContext.Set<TEntity>().Where(expression);
        }

        public Task DeleteAsync(Guid id)
        {
            TEntity entity = new TEntity() { Id = id };

            this.dbContext.Remove(entity);
            
            return this.dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            this.dbContext.Update(entity);

            return this.dbContext.SaveChangesAsync();
        }
    }
}
