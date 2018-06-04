using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Core;

namespace MasyvaiPrasidedaVienetu.DataAccessLayer
{
    public abstract class DALBase<T> where T : class
    {
        protected ArrayStartAtOneCtxContainer _ctx;
        protected DbSet<T> _dbSet;

        public DALBase()
        {
            _ctx = new ArrayStartAtOneCtxContainer();
            _dbSet = _ctx.Set<T>();
        }

        public DALBase(ArrayStartAtOneCtxContainer ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                var addedEntity = _dbSet.Add(entity);
                await _ctx.SaveChangesAsync();
                return addedEntity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<T> DeleteAsync(int id)
        {
            var entityToRemove = await GetByIdAsync(id);
            _dbSet.Remove(entityToRemove);
            await _ctx.SaveChangesAsync();
            return entityToRemove;
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            var removedEntity = _dbSet.Remove(entity);
            await _ctx.SaveChangesAsync();
            return removedEntity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.AddOrUpdate(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}