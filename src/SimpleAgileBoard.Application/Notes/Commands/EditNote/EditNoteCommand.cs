using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;

namespace SimpleAgileBoard.Application.Notes.Commands.EditNote
{
    public class EditNoteCommand : IRequest<BoardViewModel>
    {
        public int BoardId { get; set; }
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}