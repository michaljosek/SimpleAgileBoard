using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleAgileBoard.Application.Common.Exceptions;
using SimpleAgileBoard.Application.Common.Models;
using SimpleAgileBoard.Application.User.Commands.RegisterUser;
using SimpleAgileBoard.Application.User.Queries.GetToken;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserManagerWrapper _userManagerWrapper;
        private readonly JWT _jwt;
        public UserService(IUserManagerWrapper userManagerWrapper, IOptions<JWT> jwt)
        {
            _userManagerWrapper = userManagerWrapper;
            _jwt = jwt.Value;
        }

        public async Task<string> RegisterAsync(RegisterUserCommand command)
        {
            var user = new ApplicationUser
            {
                UserName = command.Email,
                Email = command.Email,
                EmailConfirmed = true
            };
            var userWithSameEmail = await _userManagerWrapper.FindByEmailAsync(command.Email);
            if (userWithSameEmail != null)
            {
                return $"Email {user.Email} is already registered.";
            }

            var result = await _userManagerWrapper.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                return string.Join(" ", result.Errors.Select(x => x.Description));
            }

            await _userManagerWrapper.AddToRoleAsync(user, Authorization.DEFAULT_ROLE.ToString());

            return $"User Registered with username {user.UserName}";
        }

        public async Task<AuthenticationModel> GetTokenAsync(GetTokenQuery query)
        {
            var authenticationModel = new AuthenticationModel();
            var user = await _userManagerWrapper.FindByEmailAsync(query.Email);
            if (user == null)
            {
                throw new IncorrectCredentialsException(query.Email);
            }

            if (!await _userManagerWrapper.CheckPasswordAsync(user, query.Password))
            {
                throw new IncorrectCredentialsException(query.Email);

            }

            authenticationModel.IsAuthenticated = true;
            var jwtSecurityToken = await CreateJwtToken(user);
            authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authenticationModel.Email = user.Email;
            authenticationModel.UserName = user.UserName;
            var rolesList = await _userManagerWrapper.GetRolesAsync(user).ConfigureAwait(false);
            authenticationModel.Roles = rolesList.ToList();
            return authenticationModel;

        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManagerWrapper.GetClaimsAsync(user);
            var roles = await _userManagerWrapper.GetRolesAsync(user);
            var roleClaims = roles.Select(t => new Claim("roles", t)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}