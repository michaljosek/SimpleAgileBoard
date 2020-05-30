using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleAgileBoard.Domain.Entities;
using SimpleAgileBoard.Domain.Extensions;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Boards.Queries
{
    public class BoardRepository : IBoardRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public BoardRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public Board Get(int boardId)
        {
            var board = _applicationDbContext.Boards
                .Include(x => x.Lanes)
                .ThenInclude(x => x.Notes)
                .FirstOrDefault(x => x.BoardId == boardId)?
                .OrderLanesAndNotes();

            return board;
        }
    }
}