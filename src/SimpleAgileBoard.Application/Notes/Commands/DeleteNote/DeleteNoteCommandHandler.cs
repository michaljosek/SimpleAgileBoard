using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Boards.Services;
using SimpleAgileBoard.Application.Notes.Services;

namespace SimpleAgileBoard.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, BoardViewModel>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly INoteRepository _noteRepository;

        public DeleteNoteCommandHandler(IBoardRepository boardRepository, INoteRepository noteRepository)
        {
            _boardRepository = boardRepository;
            _noteRepository = noteRepository;
        }
        
        public async Task<BoardViewModel> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _noteRepository.Get(request.NoteId, cancellationToken);
            if (note == null)
            {
                throw new Exception();
            }

            await _noteRepository.Remove(note, cancellationToken);
            var board = await _boardRepository.Get(request.BoardId, cancellationToken);

            return new BoardViewModel
            {
                Board = board
            };
        }
    }
}