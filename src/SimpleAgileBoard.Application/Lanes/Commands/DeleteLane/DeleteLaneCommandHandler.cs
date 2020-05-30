using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Lanes.Commands.DeleteLane
{
    public class DeleteLaneCommandHandler : IRequestHandler<DeleteLaneCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteLaneCommandHandler(IBoardRepository boardRepository, IApplicationDbContext applicationDbContext)
        {
            _boardRepository = boardRepository;
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<BoardViewModel> Handle(DeleteLaneCommand request, CancellationToken cancellationToken)
        {
            var lane = _applicationDbContext.Lanes
                .FirstOrDefault(x => x.LaneId == request.LaneId);

            _applicationDbContext.Lanes.Remove(lane);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var board = _boardRepository.Get(request.BoardId);

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}