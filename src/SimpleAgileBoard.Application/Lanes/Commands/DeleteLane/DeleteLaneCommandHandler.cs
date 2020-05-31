using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Application.Lanes.Services;

namespace SimpleAgileBoard.Application.Lanes.Commands.DeleteLane
{
    public class DeleteLaneCommandHandler : IRequestHandler<DeleteLaneCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly ILaneRepository _laneRepository;

        public DeleteLaneCommandHandler(IBoardRepository boardRepository, ILaneRepository laneRepository)
        {
            _boardRepository = boardRepository;
            _laneRepository = laneRepository;
        }
        
        public async Task<BoardViewModel> Handle(DeleteLaneCommand request, CancellationToken cancellationToken)
        {
            var lane = await _laneRepository.Get(request.LaneId, cancellationToken);
            if (lane == null)
            {
                throw new NotFoundException(nameof(lane), request.LaneId);
            }
            
            await _laneRepository.Remove(lane, cancellationToken);
            var board = await _boardRepository.Get(request.BoardId, cancellationToken);
            if (board == null)
            {
                throw new NotFoundException(nameof(board), request.BoardId);
            }
            
            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}