using MediatR;

namespace SimpleAgileBoard.Application.Boards.Queries.GetBoards
{
    public class GetBoardsQuery : IRequest<BoardsViewModel>
    {
    }
}