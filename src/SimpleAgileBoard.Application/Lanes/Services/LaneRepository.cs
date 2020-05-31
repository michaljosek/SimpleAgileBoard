using System.Threading;
using System.Threading.Tasks;
using SimpleAgileBoard.Application.Common;
using SimpleAgileBoard.Domain.Entities;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Lanes.Services
{
    public class LaneRepository : BaseRepository<Lane>, ILaneRepository
    {
        public LaneRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}