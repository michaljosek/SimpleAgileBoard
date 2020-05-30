using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SimpleAgileBoard.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}SimpleAgileBoard.Web", Path.DirectorySeparatorChar);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new ApplicationDbContext(builder.Options);
        }
    }
}
