using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Boards.Services;
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
            var lane = new Lane
            {
                Name = request.Name
            };

            //service
            board.Lanes.Add(lane);
            await _boardRepository.SaveChanges(cancellationToken);

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}