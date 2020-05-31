using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoards;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Common.Exceptions;

namespace SimpleAgileBoard.Application.Boards.Commands.DeleteBoard
{
    public class DeleteBoardCommandHandler : IRequestHandler<DeleteBoardCommand, BoardsViewModel>
    {
        private readonly IBoardRepository _boardRepository;

        public DeleteBoardCommandHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        
        public async Task<BoardsViewModel> Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.Get(request.BoardId, cancellationToken);
            if (board == null)
            {
                throw new NotFoundException(nameof(board), request.BoardId);
            }
            
            await _boardRepository.Remove(board, cancellationToken);
            var boards = await _boardRepository.GetAll(cancellationToken);

            return new BoardsViewModel
            {
                Boards = boards
            };
        }
    }
}