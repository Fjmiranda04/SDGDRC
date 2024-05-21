using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class Login2Model : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IMenuService menuService;
        private readonly IConfiguracionService configuracionService;
        private readonly IProfilerService profilerService;
        private readonly IMemoryCache memoryCache;

        private readonly ILogger<LoginModel> logger;

        public Login2Model
        (
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ILogger<LoginModel> logger,
            RoleManager<IdentityRole> roleManager,
            IMenuService menuService,
            IConfiguracionService configuracionService,
            IProfilerService profilerService,
            IMemoryCache memoryCache
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.logger = logger;

            this.menuService = menuService;
            this.configuracionService = configuracionService;
            this.profilerService = profilerService;
            this.memoryCache = memoryCache;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El usuario o correo electronico es requerido.")]
            //[EmailAddress(ErrorMessage = "Dirección de correo inválida.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "La constraseña es requerida.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            [DataType(DataType.Password)]
            public string KeyConnect { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            [DataType(DataType.Password)]
            public string Salt { get; set; }

            [Display(Name = "Recordar")]
            public bool RememberMe { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string urlcompany, string returnUrl = null)
        {

            if (string.IsNullOrEmpty(urlcompany))
            {
                return RedirectToPage("./NotFound");
            }

            if (User.Identity.IsAuthenticated)
            {
                return Redirect("~/");
            }


            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            var dataEmpresa = await profilerService.GetInstancia().ProEmpresa.GetDataEmpresa(urlcompany, "GLSELFSERVICE_USERAPP");


            ViewData["Logo"] = dataEmpresa.Logo;
            ViewData["Web"] = dataEmpresa.UrlWeb;
            ViewData["Nit"] = dataEmpresa.Nit;
            ViewData["Salt"] = dataEmpresa.Salt;
            ViewData["Email"] = "";
            ViewData["KeyConnect"] = urlcompany;


            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {

                if (string.IsNullOrEmpty(Input.Salt))
                {
                    return RedirectToPage("./NotFound");
                }

                var dataEmpresa = await profilerService.GetInstancia().ProEmpresa.GetDataEmpresa(Input.Salt, "GLSELFSERVICE_USERAPP");

                if (dataEmpresa == null)
                {
                    return RedirectToPage("./NotFound");
                }

                string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";


                bool IsEmail =  Regex.IsMatch(Input.Email, patronCorreo);

                if (!IsEmail)
                {
                    Input.Email = Input.Email.ToUpper();

                    Input.Email = Input.Email + Input.KeyConnect;
                }

                var result = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    logger.LogInformation("User logged in.");

                    var user = await userManager.FindByNameAsync(Input.Email);

                    var menuUsuarios = Task.CompletedTask;


                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                if (result.IsNotAllowed)
                {
                    var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                    var confirmed = userManager.IsEmailConfirmedAsync(user);

                    if (!confirmed.Result)
                    {
                        TempData["UrlEmpresa"] = "/Identity/Account/Login2?urlcompany=" + Input.Salt;
                        TempData["Logo"] = dataEmpresa.Logo;
                        return RedirectToPage("./UserConfirmation"/*, new { ReturnUrl = returnUrl, urlcompany = Input.Salt }*/);
                    }
                }
                else
                {
                    var user = userManager.FindByNameAsync(Input.Email);
                    if (user.Result == null)
                    {
                        ViewData["ErrorMessage"] = "Usuario o contraseña incorrecta";
                        ModelState.AddModelError(String.Empty, "Contraseña incorrecta");
                        ErrorMessage = "Usuario o contraseña incorrecta";
                    }
                    else
                    {
                        var password = userManager.CheckPasswordAsync(user.Result, Input.Password);
                        if (!password.Result)
                        {
                            ViewData["ErrorMessage"] = "Usuario o contraseña incorrecta";
                            ModelState.AddModelError(String.Empty, "Contraseña incorrecta");
                            ErrorMessage = "Contraseña incorrecta";
                        }
                        else
                        {
                            ViewData["ErrorMessage"] = "No se pudo iniciar sesión.";
                            ModelState.AddModelError(String.Empty, "No se pudo iniciar sesión.");
                            ErrorMessage = "No se pudo iniciar sesión.";
                        }
                    }

                    //ConnectionTools.RemoveConnectionUser(Input.Email);
                    return RedirectToPage("./Login2", new { urlcompany = Input.Salt });
                }
            }

            ConnectionTools.RemoveConnectionUser(Input.Email);

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private string GetConnectionStringForCompany(string connectionKey)
        {
            if (string.IsNullOrEmpty(connectionKey))
            {
                return Configuration.GetConnectionString("DefaultConnection");
            }
            return Configuration.GetConnectionString(connectionKey);
        }
    }
}