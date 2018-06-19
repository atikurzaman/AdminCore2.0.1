using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;
        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }        
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }        
        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync(cancellationToken);
            return entities;
        }        
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _entities.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);            
        }        
        public async Task<TEntity> GetAsync(Int64 id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }        
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _entities.AsNoTracking().ToListAsync(cancellationToken);
        }        
        public async Task<TEntity> DeleteAsync(Int64 id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entityToDelete = await _entities.FindAsync(id);

            if (entityToDelete == null)
            {
                return entityToDelete; 
            }

            _context.Entry(entityToDelete).State = EntityState.Deleted;
            _entities.Remove(entityToDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return entityToDelete;
        }               
        public async Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _entities.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
            return entities;
        }        
        public async Task<TEntity> UpdateAsync(Int64 id,TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        { 
            if (entity == null)
            {
                return null;
            }

            var entityToUpdate = await _entities.FindAsync(id);

            if (entityToUpdate != null)
            {
               _context.Entry(entityToUpdate).State = EntityState.Modified;
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                //_entities.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return entityToUpdate;
        }     
        public Int64 Count(Func<TEntity, bool> predicate)
        {
            return _entities.AsNoTracking().Where(predicate).LongCount();
        }        
    }
}
