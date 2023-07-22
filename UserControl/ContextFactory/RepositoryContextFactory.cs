using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RepositoryLayer;

namespace PresentationLayer.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<PetStoreContext>
    {
        public PetStoreContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PetStoreContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("PresentationLayer"));

            return new PetStoreContext(builder.Options);
        }
    }
}
