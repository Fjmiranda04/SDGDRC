using GeneralLedger.SelfServiceCore.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Data
{
    public class UserDataContext : IdentityDbContext<ApplicationUser>
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

        private string CurrentConnectionString { get; set; }

        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
        {
        }

        public void ChangeConnectionString(string connectionString)
        {
            CurrentConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            CurrentConnectionString = ConnectionTools.GetKeyConnectionString();

            if (string.IsNullOrEmpty(CurrentConnectionString))
            {
                builder.UseSqlServer(Configuration.GetConnectionString("GLSELFSERVICE_USERAPP"));
            }
            else
            {
                builder.UseSqlServer(Configuration.GetConnectionString("GLSELFSERVICE_USERAPP"));
            }

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}