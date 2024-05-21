using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GeneralLedger.SelfServiceCore.Data
{
    // Esta clase solo sirve en tiempo de diseño
    public class GLSelfServiceContextFactory : IDesignTimeDbContextFactory<SelfServiceContext>
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public GLSelfServiceContextFactory()
        {
        }

        public SelfServiceContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<SelfServiceContext>();
            OptionsBuilder.UseSqlServer(Configuration.GetConnectionString("GLSELFSERVICE_KEY"));
            return new SelfServiceContext(OptionsBuilder.Options);
        }
    }
}