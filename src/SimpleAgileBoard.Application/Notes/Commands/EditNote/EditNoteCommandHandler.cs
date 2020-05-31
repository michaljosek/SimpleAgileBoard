using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Application.Notes.Services;

namespace SimpleAgileBoard.Application.Notes.Commands.EditNote
{
    public class EditNoteCommandHandler : IRequestHandler<EditNoteCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly INoteRepository _noteRepository;

        public EditNoteCommandHandler(IBoardRepository boardRepository, INoteRepository noteRepository)
        {
            _boardRepository = boardRepository;
            _noteRepository = noteRepository;
        }
        
        public async Task<BoardViewModel> Handle(EditNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _noteRepository.Get(request.NoteId, cancellationToken);
            if (note == null)
            {
                throw new NotFoundException(nameof(note), request.NoteId);
            }

            note.Title = request.Title;
            note.Description = request.Description;

            await _noteRepository.Update(note, cancellationToken);
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