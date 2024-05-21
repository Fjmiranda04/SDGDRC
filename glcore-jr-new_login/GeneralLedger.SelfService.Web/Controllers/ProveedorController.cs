using AutoMapper;
using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    public class ProveedorController : Controller
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        #endregion UserManager

        #region Servicios

        private readonly IProfilerService profilerService;

        #endregion Servicios

        #region Others

        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;

        #endregion Others

        #region Constructor

        public ProveedorController
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IProfilerService profilerService,
            IMapper mapper,
            IHttpContextAccessor contextAccessor
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.profilerService = profilerService;

            this.mapper = mapper;
            this.contextAccessor = contextAccessor;
            ConnectionTools.SetKeyConnectionStringDirect(SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection"));
        }

        #endregion Constructor

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Proponentes()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetProveedores(string search)
        {
            return Json(new { });
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetProPonentes(string search)
        {
            return Json(new { });
        }
    }
}