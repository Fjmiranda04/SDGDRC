using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using GeneralLedger.SelfServiceCore.Services.Profilers.Implements;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class NotFoundModel : PageModel
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IProfilerService profilerService;

        public NotFoundModel
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IProfilerService profilerService
        )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._logger = logger;
            this.profilerService = profilerService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            var dataEmpresas = await profilerService.GetInstancia().ProEmpresa.GetEmpresas("GLSELFSERVICE_USERAPP");

            ViewData["Empresas"] = dataEmpresas;
            ViewData["UrlEmpresa"] = "/Identity/Account/Login2?urlcompany=";

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            return Page();
        }
    }
}