using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;

namespace SimpleAgileBoard.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest<BoardViewModel>
    {
        public int NoteId { get; set; }

        public int BoardId { get; set; }
    }
}