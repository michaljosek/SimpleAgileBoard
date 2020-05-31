using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoards;
using SimpleAgileBoard.Application.Boards.Services;

namespace SimpleAgileBoard.Application.Boards.Commands.EditBoard
{
    public class EditBoardCommandHandler : IRequestHandler<EditBoardCommand, BoardsViewModel>
    {
        private readonly IBoardRepository _boardRepository;

        public EditBoardCommandHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        
        public async Task<BoardsViewModel> Handle(EditBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.Get(request.BoardId, cancellationToken);
            if (board == null)
            {
                throw new Exception(); //todo custom exception
            }
            
            board.Name = request.Name;
            board.NotePrefix = request.NotePrefix;

            await _boardRepository.Update(board, cancellationToken);
            var boards = await _boardRepository.GetAll(cancellationToken);
            
            return new BoardsViewModel
            {
                Boards = boards
            };
        }
    }
}