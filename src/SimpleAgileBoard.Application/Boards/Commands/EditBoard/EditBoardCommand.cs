using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoards;

namespace SimpleAgileBoard.Application.Boards.Commands.EditBoard
{
    public class EditBoardCommand : IRequest<BoardsViewModel>
    {
        public int BoardId { get; set; }
        public string Name { get; set; }
        public string NotePrefix { get; set; }
    }
}