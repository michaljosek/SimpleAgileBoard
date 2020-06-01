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
                .FirstOrDefaultAsync(x => x.Id == laneId, cancellationToken);

            return board;
        }
    }
}