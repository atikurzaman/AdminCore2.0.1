using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {        
        Task<TEntity> GetAsync(Int64 id);        
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));        
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));        
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));        
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));        
        Task<TEntity> DeleteAsync(Int64 id, CancellationToken cancellationToken=default(CancellationToken));              
        Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));        
        Task<TEntity> UpdateAsync(Int64 id, TEntity entity, CancellationToken cancellationToken = default(CancellationToken));        
        Int64 Count(Func<TEntity, bool> predicate);
    }
}
