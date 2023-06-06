using Microsoft.EntityFrameworkCore;

namespace RickAndMorty.Models
{
    public class RickAndMortyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:RickAndMortyConnection"]);
        }

        public DbSet<R1> Locations { get; set; }

        public DbSet<R2> Characters { get; set; }

        public DbSet<R3> Episodes { get; set; }
    }
}
