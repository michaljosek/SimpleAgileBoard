using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleAgileBoard.Application.Common;
using SimpleAgileBoard.Application.User.Services;

namespace SimpleAgileBoard.Application.User.Queries.GetToken
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, AuthenticationModel>
    {
        private readonly IUserService _userService;

        public GetTokenQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        
        public async Task<AuthenticationModel> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetTokenAsync(request);
        }
    }
}