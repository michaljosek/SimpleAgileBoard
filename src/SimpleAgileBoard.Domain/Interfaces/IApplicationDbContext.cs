using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Lane> Lanes { get; set; }
        public DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}