using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;

namespace SimpleAgileBoard.Application.Notes.Commands.MoveNoteToLane
{
    public class MoveNoteToLaneCommand : IRequest<BoardViewModel>
    {
        public int BoardId { get; set; }
        public int NoteId { get; set; }
        public int NewLaneId { get; set; }
    }
}
