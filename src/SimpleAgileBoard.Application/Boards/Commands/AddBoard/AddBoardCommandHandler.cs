using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoards;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.Boards.Commands.AddBoard
{
    public class AddBoardCommandHandler : IRequestHandler<AddBoardCommand, BoardsViewModel>
    {
        private readonly IBoardRepository _boardRepository;

        public AddBoardCommandHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        
        public async Task<BoardsViewModel> Handle(AddBoardCommand request, CancellationToken cancellationToken)
        {
            var board = new Board
            {
                Name = request.Name,
                NotePrefix = request.NotePrefix,
            };

            await _boardRepository.Add(board, cancellationToken);
            var boards = await _boardRepository.GetAll(cancellationToken);

            return new BoardsViewModel
            {
                Boards = boards
            };
        }
    }
}