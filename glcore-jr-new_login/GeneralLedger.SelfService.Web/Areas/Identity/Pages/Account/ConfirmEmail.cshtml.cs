using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> userManager;

        #endregion UserManager

        #region Constructor

        public ConfirmEmailModel
        (
            UserManager<ApplicationUser> userManager
        )
        {
            this.userManager = userManager;
        }

        #endregion Constructor

        [TempData]
        public string StatusMessage { get; set; }

        //public ApplicationUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code, string keyConnection)
        {
            if (userId == null || code == null || keyConnection == null)
            {
                return RedirectToPage("/Index");
            }

            ConnectionTools.SetKeyConnectionStringDirect(keyConnection);

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await userManager.ConfirmEmailAsync(user, code);
            ViewData["userEmail"] = user.Email;

            var callbackUrl = Url.Page(
                    "/Account/Index",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

            return Page();
        }
    }
}