using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Lane> Lanes { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
