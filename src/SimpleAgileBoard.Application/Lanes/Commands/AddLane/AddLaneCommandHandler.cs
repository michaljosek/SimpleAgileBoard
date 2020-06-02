using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.Lanes.Commands.AddLane
{
    public class AddLaneCommandHandler : IRequestHandler<AddLaneCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;

        public AddLaneCommandHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        
        public async Task<BoardViewModel> Handle(AddLaneCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.Get(request.BoardId, cancellationToken);
            if (board == null)
            {
                throw new NotFoundException(nameof(board), request.BoardId);
            }
            
            var lane = new Lane
            {
                Name = request.Name,
                SortIndex = board.Lanes.Count
            };

            board.Lanes.Add(lane);
            await _boardRepository.Update(board, cancellationToken);
            board = await _boardRepository.Get(board.Id, cancellationToken);

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}