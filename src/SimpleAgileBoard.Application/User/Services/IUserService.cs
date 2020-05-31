using System.Threading.Tasks;
using SimpleAgileBoard.Application.User.Commands.RegisterUser;
using SimpleAgileBoard.Application.User.Queries.GetToken;

namespace SimpleAgileBoard.Application.User.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterUserCommand command);
        Task<AuthenticationModel> GetTokenAsync(GetTokenQuery query);
    }
}