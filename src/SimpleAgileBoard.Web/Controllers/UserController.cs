using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAgileBoard.Application.User.Commands.RegisterUser;
using SimpleAgileBoard.Application.User.Queries.GetToken;

namespace Boilerplate.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Register([FromBody]RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpPost]
        public async Task<IActionResult> Token([FromBody]GetTokenQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}