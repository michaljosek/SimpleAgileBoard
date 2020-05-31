using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleAgileBoard.Application.Common.Models;
using SimpleAgileBoard.Domain.Entities;

namespace SimpleAgileBoard.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope()) 
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                var roles = new [] { Authorization.Roles.Administrator.ToString(), Authorization.Roles.User.ToString() };

                foreach (var role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        await roleStore.CreateAsync(new IdentityRole(role)
                        {
                            NormalizedName = role.ToUpper()
                        });
                    }
                }

                var user = new ApplicationUser
                {
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(user,"admin");
                    user.PasswordHash = hashed;

                    var userStore = new UserStore<ApplicationUser>(context);
                    var result = userStore.CreateAsync(user);
                }

                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                user = await userManager.FindByEmailAsync(user.Email);
                var resultRoles = await userManager.AddToRolesAsync(user, roles);
                
                await context.SaveChangesAsync();
            }
        }
    }
}