using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcEkkremotites.Models;
using MvcPromitheftes.Models;
using MvcProsEpiskevi.Models;
using MvcKostologisi.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using MvcProsthikiArithmouDeltiou.Models;

namespace MvcProducts.Models
{
    public class MvcProductsContext : DbContext
    {
        public MvcProductsContext (DbContextOptions<MvcProductsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcProducts.Models.Product> Product { get; set; }

        public DbSet<MvcEkkremotites.Models.cEkkremotites> cEkkremotites { get; set; }

        public DbSet<MvcPromitheftes.Models.cPromitheftes> cPromitheftes { get; set; }

        public DbSet<MvcProsEpiskevi.Models.cProsEpiskevi> cProsEpiskevi { get; set; }

        public DbSet<MvcKostologisi.Models.Kostologisi> Kostologisi { get; set; }

        public DbSet<MvcProsthikiArithmouDeltiou.Models.ProsthikiArithmouDeltiou> ProsthikiArithmouDeltiou { get; set; }
    }
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MvcProductsContext>
    {
        public MvcProductsContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MvcProductsContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new MvcProductsContext(builder.Options);
        }
    }
}
