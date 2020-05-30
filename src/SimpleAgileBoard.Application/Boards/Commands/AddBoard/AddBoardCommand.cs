using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoards;

namespace SimpleAgileBoard.Application.Boards.Commands.AddBoard
{
    public class AddBoardCommand : IRequest<BoardsViewModel>
    {
        public string Name { get; set; }
        public string NotePrefix { get; set; }
    }
}