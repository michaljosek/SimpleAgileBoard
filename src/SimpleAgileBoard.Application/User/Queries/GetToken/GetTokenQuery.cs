using MediatR;

namespace SimpleAgileBoard.Application.User.Queries.GetToken
{
    public class GetTokenQuery : IRequest<AuthenticationModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}