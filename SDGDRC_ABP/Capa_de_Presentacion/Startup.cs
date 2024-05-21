using Capa_de_Negocios.Repository.Implementations;
using Capa_de_Negocios.Repository;
using Capa_de_Negocios.Service.Implementations;
using Capa_de_Negocios.Service;
using Microsoft.EntityFrameworkCore;
using System;
using Capa_de_Datos.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

namespace Capa_de_Presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método se llama por el tiempo de ejecución. Úsalo para agregar servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración del contexto de la base de datos
            services.AddDbContext<SdgdrcContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Repositorio y servicio de usuario
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            // Obtener la clave secreta de la configuración
            string claveSecreta = Configuration["Jwt:ClaveSecreta"];

            // Registrar AuthService con la clave secreta y el repositorio de autenticación
            services.AddScoped<IAuthService>(provider => new AuthService(Configuration, provider.GetRequiredService<IAuthRepository>()));
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<IRutaService, RutaService>();
            services.AddScoped<IRutaRepository, RutaRepository>();

            // Configuración de la autenticación basada en cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.LogoutPath = "/Auth/Logout";
                });

            // Configuración de la autorización
            services.AddAuthorization();
            // Configuración de la autorización basada en roles
           /* services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("Voluntario", policy => policy.RequireRole("Voluntario"));
                options.AddPolicy("Coordinador", policy => policy.RequireRole("Coordinador"));
            });*/

            // Controladores y vistas
            services.AddControllersWithViews();
        }

        // Este método se llama por el tiempo de ejecución. Úsalo para configurar el canal de solicitudes HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Middleware de autenticación
            app.UseAuthentication();

            // Middleware de autorización
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
<<<<<<< HEAD
                    pattern: "{controller=Home}/{action=Index}/{id?}");
=======
                    pattern: "{controller=Ruta}/{action=Index}/{id?}");
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
            });
        }
    }
}
