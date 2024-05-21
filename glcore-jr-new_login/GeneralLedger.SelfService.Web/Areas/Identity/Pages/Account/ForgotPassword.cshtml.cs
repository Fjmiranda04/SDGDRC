using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using GeneralLedger.SelfServiceCore.Services.Profilers.Implements;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        IProfilerService profilerService;

        public ForgotPasswordModel(UserManager<ApplicationUser> userManager, IEmailSender emailSender, IProfilerService profilerService)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            this.profilerService = profilerService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Este dato es requerido.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            public string Nit { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            public string Salt { get; set; }
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

            var dataEmpresa = await profilerService.GetInstancia().ProEmpresa.GetDataEmpresa(urlcompany, "GLSELFSERVICE_USERAPP");


            ViewData["Logo"] = dataEmpresa.Logo;
            ViewData["Web"] = dataEmpresa.UrlWeb;
            ViewData["Nit"] = dataEmpresa.Nit;
            ViewData["Salt"] = dataEmpresa.Salt;
            ViewData["Email"] = "";
            ViewData["KeyConnect"] = urlcompany;


            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
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

                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);


                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}