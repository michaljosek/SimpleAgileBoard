using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;

namespace SimpleAgileBoard.Application.Notes.Commands.AddNote
{
    public class AddNoteCommand : IRequest<BoardViewModel>
    {
        public int LaneId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}