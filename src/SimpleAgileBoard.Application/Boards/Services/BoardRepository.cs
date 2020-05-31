using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleAgileBoard.Application.Common;
using SimpleAgileBoard.Domain.Entities;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Boards.Services
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public BoardRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        //todo order
        public override async Task<Board> Get(int boardId, CancellationToken cancellationToken)
        {
            var board =  await _applicationDbContext.Boards
                .Include(x => x.Lanes)
                .ThenInclude(x => x.Notes)
                .FirstOrDefaultAsync(x => x.Id == boardId, cancellationToken);

            return board;
        }
    }
}