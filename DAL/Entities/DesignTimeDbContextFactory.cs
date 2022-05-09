using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DAL.Entities;

namespace ASPNetCoreApp.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FilmContext>
    {
        public FilmContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new
            ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new
            DbContextOptionsBuilder<FilmContext>();
            var connectionString =
            configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new FilmContext(builder.Options);
        }
    }
}
