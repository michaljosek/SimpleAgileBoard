using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Domain.Entities;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Lanes.Commands.AddLane
{
    public class AddLaneCommandHandler : IRequestHandler<AddLaneCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IApplicationDbContext _applicationDbContext;

        public AddLaneCommandHandler(IBoardRepository boardRepository, IApplicationDbContext applicationDbContext)
        {
            _boardRepository = boardRepository;
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<BoardViewModel> Handle(AddLaneCommand request, CancellationToken cancellationToken)
        {
            var board = _boardRepository.Get(request.BoardId);
            var lane = new Lane
            {
                Name = request.Name
            };

            board.Lanes.Add(lane);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}