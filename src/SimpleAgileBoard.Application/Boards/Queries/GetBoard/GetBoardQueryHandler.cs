using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Common.Exceptions;

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