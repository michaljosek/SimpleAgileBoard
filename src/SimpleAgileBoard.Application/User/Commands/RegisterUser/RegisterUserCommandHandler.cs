using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Common;
using SimpleAgileBoard.Application.User.Services;

namespace SimpleAgileBoard.Application.User.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.RegisterAsync(request);
        }
    }
}