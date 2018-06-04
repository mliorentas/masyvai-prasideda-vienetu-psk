using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MasyvaiPrasidedaVienetu.DataAccessLayer
{
    public abstract class DALBase<T> where T : class
    {
        protected ArrayStartAtOneCtxContainer _ctx = new ArrayStartAtOneCtxContainer();
        private DbSet<T> _dbSet;

        public DALBase()
        {
            _dbSet = _ctx.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntity = _dbSet.Add(entity);
            await _ctx.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entityToRemove = await GetByIdAsync(id);
            _dbSet.Remove(entityToRemove);
            await _ctx.SaveChangesAsync();
            return entityToRemove;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            var removedEntity = _dbSet.Remove(entity);
            await _ctx.SaveChangesAsync();
            return removedEntity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}