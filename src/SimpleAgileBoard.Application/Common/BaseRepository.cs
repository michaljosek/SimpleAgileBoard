using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Common
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly IApplicationDbContext _applicationDbContext;

        protected BaseRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public virtual async Task<T> Get(int id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.GetDbContext().Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public virtual async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.GetDbContext().Set<T>().ToListAsync(cancellationToken);
        }

        public virtual async Task Update(T entity, CancellationToken cancellationToken)
        {
            _applicationDbContext.GetDbContext().Set<T>().Update(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Remove(T entity, CancellationToken cancellationToken)
        {
            _applicationDbContext.GetDbContext().Set<T>().Remove(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Add(T entity, CancellationToken cancellationToken)
        {
            _applicationDbContext.GetDbContext().Set<T>().Add(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}