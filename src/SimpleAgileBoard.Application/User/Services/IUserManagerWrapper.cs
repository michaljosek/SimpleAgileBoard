using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Application.User.Services
{
    public interface IUserManagerWrapper
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<IList<Claim>> GetClaimsAsync(ApplicationUser user);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
    }
}
