using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;

namespace SimpleAgileBoard.Application.Lanes.Commands.AddLane
{
    public class AddLaneCommand : IRequest<BoardViewModel>
    {
        public int BoardId { get; set; }
        public string Name { get; set; }
    }
}