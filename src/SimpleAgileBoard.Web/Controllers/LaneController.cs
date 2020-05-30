using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Lanes.Commands.AddLane;
using SimpleAgileBoard.Application.Lanes.Commands.DeleteLane;

namespace Boilerplate.Controllers
{
    public class LaneController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<BoardViewModel>> Add([FromBody] AddLaneCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<BoardViewModel>> Delete([FromBody] DeleteLaneCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}