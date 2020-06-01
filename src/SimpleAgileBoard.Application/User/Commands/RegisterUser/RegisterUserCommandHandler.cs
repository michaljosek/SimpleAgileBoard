using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Common;
using SimpleAgileBoard.Application.User.Services;

namespace SimpleAgileBoard.Application.User.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterViewModel>
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RegisterViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var message = await _userService.RegisterAsync(request);

            return new RegisterViewModel
            {
                Message = message
            };
        }
    }
}