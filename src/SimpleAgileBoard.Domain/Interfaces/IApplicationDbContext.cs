using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Board> Boards { get; set; }
        DbSet<Lane> Lanes { get; set; }
        DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        DbContext GetDbContext();
    }
}