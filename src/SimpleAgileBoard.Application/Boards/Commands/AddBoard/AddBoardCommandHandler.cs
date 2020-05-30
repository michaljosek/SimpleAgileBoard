using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoards;
using SimpleAgileBoard.Domain.Entities;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Boards.Commands.AddBoard
{
    public class AddBoardCommandHandler : IRequestHandler<AddBoardCommand, BoardsViewModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddBoardCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<BoardsViewModel> Handle(AddBoardCommand request, CancellationToken cancellationToken)
        {
            var board = new Board
            {
                Name = request.Name,
                NotePrefix = request.NotePrefix,
            };


            _applicationDbContext.Boards.Add(board);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var boards = _applicationDbContext.Boards.ToList();

            return new BoardsViewModel
            {
                Boards = boards
            };
        }
    }
}