using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Services;

namespace SimpleAgileBoard.Application.Boards.Queries.GetBoard
{
    public class GetBoardQueryHandler : IRequestHandler<GetBoardQuery, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;

        public GetBoardQueryHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        
        public async Task<BoardViewModel> Handle(GetBoardQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.Get(request.BoardId, cancellationToken);

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}