using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Domain.Interfaces;

namespace SimpleAgileBoard.Application.Notes.Commands.EditNote
{
    public class EditNoteCommandHandler : IRequestHandler<EditNoteCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IApplicationDbContext _applicationDbContext;

        public EditNoteCommandHandler(IBoardRepository boardRepository, IApplicationDbContext applicationDbContext)
        {
            _boardRepository = boardRepository;
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<BoardViewModel> Handle(EditNoteCommand request, CancellationToken cancellationToken)
        {
            var note = _applicationDbContext.Notes
                .FirstOrDefault(x => x.NoteId == request.NoteId);

            note.Title = request.Title;
            note.Description = request.Description;

            _applicationDbContext.Notes.Update(note);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var board = _boardRepository.Get(request.BoardId);

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}