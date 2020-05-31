using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Services;

namespace SimpleAgileBoard.Application.Boards.Queries.GetBoards
{
    public class GetBoardsQueryHandler : IRequestHandler<GetBoardsQuery, BoardsViewModel>
    {
        private readonly IBoardRepository _boardRepository;

        public GetBoardsQueryHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        
        public async Task<BoardsViewModel> Handle(GetBoardsQuery request, CancellationToken cancellationToken)
        {
            return new BoardsViewModel
            {
                Boards = await _boardRepository.GetAll(cancellationToken)
            };;
        }
    }
}