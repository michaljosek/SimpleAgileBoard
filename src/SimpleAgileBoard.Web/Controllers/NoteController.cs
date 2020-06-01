using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleAgileBoard.Application.Boards.Queries.GetBoard;
using SimpleAgileBoard.Application.Notes.Commands.AddNote;
using SimpleAgileBoard.Application.Notes.Commands.DeleteNote;
using SimpleAgileBoard.Application.Notes.Commands.EditNote;
using SimpleAgileBoard.Application.Notes.Commands.MoveNote;
using SimpleAgileBoard.Application.Notes.Commands.MoveNoteToLane;
using SimpleAgileBoard.Application.Notes.Queries.GetNote;

namespace Boilerplate.Controllers
{
    public class NoteController : BaseController
    {
        [Route("{noteId}")]
        [HttpGet]
        public async Task<ActionResult<BoardViewModel>> Get(int noteId)
        {
            return Ok(await Mediator.Send(new GetNoteQuery(){
                NoteId = noteId
            }));
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BoardViewModel>> Add([FromBody]AddNoteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BoardViewModel>> Delete([FromBody]DeleteNoteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BoardViewModel>> Edit([FromBody]EditNoteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BoardViewModel>> Move([FromBody]MoveNoteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BoardViewModel>> MoveToLane([FromBody]MoveNoteToLaneCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}