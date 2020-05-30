using MediatR;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;

namespace SimpleAgileBoard.Application.Lanes.Commands.DeleteLane
{
    public class DeleteLaneCommand : IRequest<BoardViewModel>
    {
        public int LaneId { get; set; }

        public int BoardId { get; set; }
    }
}