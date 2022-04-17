using Basket.Core.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BasketDbContext _basketDbContext;
        public Repository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _basketDbContext.Set<T>().AddAsync(entity);
            await _basketDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _basketDbContext.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _basketDbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _basketDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _basketDbContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _basketDbContext.Set<T>().Update(entity);
            await _basketDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _basketDbContext.Set<T>().Remove(entity);
            await _basketDbContext.SaveChangesAsync();
            return true;
        }
    }
}
