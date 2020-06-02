using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleAgileBoard.Application.Common;
using SimpleAgileBoard.Domain.Entities;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Lanes.Services
{
    public class LaneRepository : BaseRepository<Lane>, ILaneRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public LaneRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public override async Task<Lane> Get(int laneId, CancellationToken cancellationToken)
        {
            var board = await _applicationDbContext.Lanes
                .Include(x => x.Notes)
                .Select(y => new Lane
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
                .FirstOrDefaultAsync(x => x.Id == laneId, cancellationToken);

            return board;
        }
    }
}