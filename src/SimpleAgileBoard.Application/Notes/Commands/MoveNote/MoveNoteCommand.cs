using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;

namespace SimpleAgileBoard.Application.Notes.Commands.MoveNote
{
    public class MoveNoteCommand : IRequest<BoardViewModel>
    {
        public int NoteIndex { get; set; }
        public int LaneId { get; set; }
        public int BoardId { get; set; }
        public bool MoveUp { get; set; }
    }
}