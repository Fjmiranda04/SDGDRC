using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IMenuService menuService;
        private readonly IConfiguracionService configuracionService;
        private readonly IProfilerService profilerService;
        private readonly IMemoryCache memoryCache;

        private readonly ILogger<LoginModel> logger;

        public LoginModel
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

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Este dato es requerido.")]
            [EmailAddress(ErrorMessage = "Dirección de correo inválida.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Recordar")]
            public bool RememberMe { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string Email, string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("~/");
            }

            if (string.IsNullOrEmpty(Email))
            {
                return Redirect("PreLogin");
            }

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            var userEmpresa = await profilerService.GetInstancia().ProEmpresa.GetUsuarioEmpresa(Email, "GLSELFSERVICE_KEY");
            var dataEmpresa = await profilerService.GetInstancia().ProEmpresa.GetEmpresa(userEmpresa.NitEmpresa.ToString(), "GLSELFSERVICE_KEY");
            var configuracion = await profilerService.GetInstancia().ProConfiguracion.GetConfiguraciones(dataEmpresa.KeyConnection);

            ViewData["Logo"] = configuracion.Where(x => x.Clave == "LOGO_EMPRESA").Select(x => x.Valor).FirstOrDefault();
            ViewData["Web"] = configuracion.Where(x => x.Clave == "WEB_EMPRESA").Select(x => x.Valor).FirstOrDefault();
            ViewData["Email"] = Email;

            ConnectionTools.SetKeyConnectionStringDirect(dataEmpresa.KeyConnection);

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
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                //ConnectionTools.SetKeyConnectionString(Input.Email);

                var userEmpresa = await profilerService.GetInstancia().ProEmpresa.GetUsuarioEmpresa(Input.Email, "GLSELFSERVICE_KEY");
                var dataEmpresa = await profilerService.GetInstancia().ProEmpresa.GetEmpresa(userEmpresa.NitEmpresa.ToString(), "GLSELFSERVICE_KEY");

                ConnectionTools.SetKeyConnectionStringDirect(dataEmpresa.KeyConnection);

                var result = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    logger.LogInformation("User logged in.");

                    var user = await userManager.FindByNameAsync(Input.Email);

                    var menuUsuarios = Task.CompletedTask;

                    if (memoryCache.TryGetValue($"menu{user.NroId}", out menuUsuarios))
                    {
                        ViewData["Menus"] = menuUsuarios;
                    }
                    else
                    {
                        var cacheOptions = new MemoryCacheEntryOptions()
                                               .SetSlidingExpiration(TimeSpan.FromSeconds(600));

                        menuUsuarios = profilerService.GetInstancia().ProConfiguracion.GetMenusByUser(user.NroId, "", dataEmpresa.KeyConnection);

                        await memoryCache.Set($"menu{user.NroId}", menuUsuarios, cacheOptions);

                        ViewData["Menus"] = menuUsuarios;
                    }

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
                        logger.LogWarning("User account not confirmed.");
                        return RedirectToPage("./UserConfirmation");
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
                    return RedirectToPage("./Login", new { Email = Input.Email });
                }
            }

            ConnectionTools.RemoveConnectionUser(Input.Email);

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}