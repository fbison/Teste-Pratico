using TestePratico.Domain.Entities;
using TestePratico.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TestePratico.Infra.Data.Context
{
    public class DesignTimeDataDbContext : IDesignTimeDbContextFactory<DataDbContext>
    {
        public DataDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<DesignTimeDataDbContext>()
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<DataDbContext>();
            // pass your design time connection string here
            optionsBuilder.UseSqlServer(connectionString);
            return new DataDbContext(optionsBuilder.Options);
        }
    }

}
