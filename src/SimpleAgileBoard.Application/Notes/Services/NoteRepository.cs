using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SimpleAgileBoard.Application.Common;
using SimpleAgileBoard.Domain.Entities;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Notes.Services
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}