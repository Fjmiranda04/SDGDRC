using GeneralLedger.SelfService.Web.Areas.Identity.Services;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Pages.Account
{
    public class PreLoginModel : PageModel
    {
        private readonly ILogger<PreLoginModel> _logger;

        private readonly IGenericServiceIdentity genericServiceIdentity;
        private readonly IUsuarioEmpresaService usuarioEmpresaService;
        private readonly IEmpresaService empresaService;
        private readonly IProfilerService profilerService;

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }

        [BindProperty]
        public InputPreLoginModel Input { get; set; }

        public PreLoginModel
        (
            ILogger<PreLoginModel> logger,
            IGenericServiceIdentity genericServiceIdentity,
            IUsuarioEmpresaService usuarioEmpresaService,
            IEmpresaService empresaService,
            IProfilerService profilerService
        )
        {
            _logger = logger;
            this.genericServiceIdentity = genericServiceIdentity;
            this.usuarioEmpresaService = usuarioEmpresaService;
            this.empresaService = empresaService;
            this.profilerService = profilerService;
        }

        public class InputPreLoginModel
        {
            [Required(ErrorMessage = "Este dato es requerido.")]
            [EmailAddress(ErrorMessage = "Dirección de correo inválida.")]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ConnectionTools.SetDefaultConnectionString();

            if (User.Identity.IsAuthenticated)
            {
                return Redirect("~/");
            }

            returnUrl ??= Url.Content("~/");
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ReturnUrl = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var userEmpresa = await profilerService.GetInstancia().ProEmpresa.GetUsuarioEmpresa(Input.Email.ToString(), "GLSELFSERVICE_KEY");

                if (userEmpresa.Email == null)
                {
                    ViewData["ErrorMessage"] = "No se ha podido encontrar tu cuenta";
                    ModelState.AddModelError(String.Empty, "No se ha podido encontrar tu cuenta");
                    return Page();
                }
                else
                {
                    return RedirectToPage("./Login", new { Email = Input.Email });
                }
            }

            return Page();
        }
    }
}