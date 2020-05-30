using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleAgileBoard.Application.Boards.Queries.GetBoards;
using SimpleAgileBoard.Domain.Entities;
using SimpleAgileBoard.Domain.Extensions;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Boards.Commands.DeleteBoard
{
    public class DeleteBoardCommandHandler : IRequestHandler<DeleteBoardCommand, BoardsViewModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteBoardCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<BoardsViewModel> Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
        {
            var board = GetBoard(request.BoardId);

            _applicationDbContext.Boards.Remove(board);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var boards = _applicationDbContext.Boards.ToList();

            return new BoardsViewModel
            {
                Boards = boards
            };
        }
        
        private Board GetBoard(int boardId)
        {
            var board = _applicationDbContext.Boards
                .FirstOrDefault(x => x.BoardId == boardId);

            return board;
        }
    }
}