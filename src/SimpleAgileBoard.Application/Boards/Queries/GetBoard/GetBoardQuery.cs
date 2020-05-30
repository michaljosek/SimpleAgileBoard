using MediatR;

namespace SimpleAgileBoard.Application.Boards.Queries.GetBoard
{
    public class GetBoardQuery : IRequest<BoardViewModel>
    {
        public int BoardId { get; set; }
    }
}