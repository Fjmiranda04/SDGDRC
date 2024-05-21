//using GeneralLedger.SelfService.Web.Areas.Identity.Data;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//[assembly: HostingStartup(typeof(GeneralLedger.SelfService.Web.Areas.Identity.IdentityHostingStartup))]

//namespace GeneralLedger.SelfService.Web.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        public void Configure(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices((context, services) =>
//            {
//                services.AddDbContext<UserDataContext>(Options =>
//                    Options.UseSqlServer(
//                        context.Configuration.GetConnectionString("GLSELFSERVICE_USERAPP")));

//                services.AddDefaultIdentity<ApplicationUser>(options =>
//                {
//                    options.SignIn.RequireConfirmedAccount = true;
//                    options.User.RequireUniqueEmail = true;

//                    // Password settings.
//                    options.Password.RequireDigit = true;
//                    options.Password.RequireLowercase = false;
//                    options.Password.RequireNonAlphanumeric = false;
//                    options.Password.RequireUppercase = false;
//                    options.Password.RequiredLength = 6;
//                    options.Password.RequiredUniqueChars = 0;
//                }).AddRoles<IdentityRole>()
//                .AddEntityFrameworkStores<UserDataContext>();

//                services.ConfigureApplicationCookie(options =>
//                {
//                    options.LoginPath = "/Identity/Account/Login2";
//                });
//            });
//        }
//    }
//}