using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoards;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Boards.Commands.EditBoard
{
    public class EditBoardCommandHandler : IRequestHandler<EditBoardCommand, BoardsViewModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public EditBoardCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<BoardsViewModel> Handle(EditBoardCommand request, CancellationToken cancellationToken)
        {
            var board = _applicationDbContext.Boards
                .FirstOrDefault(x => x.BoardId == request.BoardId);

            board.Name = request.Name;
            board.NotePrefix = request.NotePrefix;

            _applicationDbContext.Boards.Update(board);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var boards = _applicationDbContext.Boards.ToList();
            
            return new BoardsViewModel
            {
                Boards = boards
            };
        }
    }
}