using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteNoteCommandHandler(IBoardRepository boardRepository, IApplicationDbContext applicationDbContext)
        {
            _boardRepository = boardRepository;
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<BoardViewModel> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = _applicationDbContext.Notes
                .FirstOrDefault(x => x.NoteId == request.NoteId);
            
            _applicationDbContext.Notes.Remove(note);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var board = _boardRepository.Get(request.BoardId);

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}