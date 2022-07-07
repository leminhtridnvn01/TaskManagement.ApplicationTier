using Domain.Base;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class Repository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly EFContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(EFContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }
        public Task<bool> SoftDeleteAsync(T entity)
        {
            entity.GetType().GetProperty("IsDelete").SetValue(entity, true);
            _dbSet.Update(entity);
            return Task.FromResult(true);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }

        public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToListAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }

        public async Task<int> InsertAndGetIdAsync(T entity, bool saveChanges = true)
        {
            await _dbSet.AddAsync(entity);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
                var id = entity.GetType().GetProperty("Id").GetValue(entity);
                return Convert.ToInt32(id);
            }
            return 0;
        }
    }
}
