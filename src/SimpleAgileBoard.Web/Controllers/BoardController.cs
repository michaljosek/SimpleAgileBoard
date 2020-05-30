using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAgileBoard.Application.Boards.Commands.AddBoard;
using SimpleAgileBoard.Application.Boards.Commands.DeleteBoard;
using SimpleAgileBoard.Application.Boards.Commands.EditBoard;
using SimpleAgileBoard.Application.Boards.Queries.GetBoards;

namespace Boilerplate.Controllers
{
    public class BoardController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<BoardsViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetBoardsQuery()));
        }
        
        [HttpPost]
        public async Task<ActionResult<BoardsViewModel>> Edit([FromBody]EditBoardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPost]
        public async Task<ActionResult<BoardsViewModel>> Add([FromBody]AddBoardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPost]
        public async Task<ActionResult<BoardsViewModel>> Delete([FromBody]DeleteBoardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}