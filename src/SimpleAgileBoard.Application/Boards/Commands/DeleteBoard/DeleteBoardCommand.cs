using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoards;

namespace SimpleAgileBoard.Application.Boards.Commands.DeleteBoard
{
    public class DeleteBoardCommand : IRequest<BoardsViewModel>
    {
        public int BoardId { get; set; }
    }
}