using System.Collections.Generic;
using System.Linq;
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
        
        public override async Task<Board> Get(int boardId, CancellationToken cancellationToken)
        {
            var board =  await _applicationDbContext.Boards
                .Include(x => x.Lanes)
                .ThenInclude(x => x.Notes)
                .Select(x => new Board
                {
                    Id = x.Id,
                    Name = x.Name,
                    NoteCounter = x.NoteCounter,
                    NotePrefix = x.NotePrefix,
                    Lanes = x.Lanes.Select(y => new Lane
                    {
                        Id = y.Id,
                        Name = y.Name,
                        BoardId = y.BoardId,
                        SortIndex = y.SortIndex,
                        Notes = y.Notes.Select(z => new Note
                        {
                            Id = z.Id,
                            Description = z.Description,
                            LaneId = z.LaneId,
                            Title = z.Title,
                            SortIndex = z.SortIndex,
                            NoteBoardId = z.NoteBoardId
                        })
                        .OrderBy(z => z.SortIndex)
                        .ToList()
                    })
                    .OrderBy(y => y.SortIndex)
                    .ToList()
                })
                .FirstOrDefaultAsync(x => x.Id == boardId, cancellationToken);

            return board;
        }
    }
}