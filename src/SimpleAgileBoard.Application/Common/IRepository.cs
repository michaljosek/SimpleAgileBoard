using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Common
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        Task<T> Get(int id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
        Task Update(T entity, CancellationToken cancellationToken);
        Task Remove(T entity, CancellationToken cancellationToken);
        Task Add(T entity, CancellationToken cancellationToken);
        Task SaveChanges(CancellationToken cancellationToken);
    }
}