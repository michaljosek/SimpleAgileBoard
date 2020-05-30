using System.Threading;
using System.Threading.Tasks;
using MediatR;

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
            var board = _boardRepository.Get(request.BoardId);

            return await Task.FromResult(new BoardViewModel
            {
                Board = board
            });
        }
    }
}