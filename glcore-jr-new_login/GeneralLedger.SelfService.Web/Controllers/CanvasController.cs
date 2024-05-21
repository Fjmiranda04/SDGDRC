using AutoMapper;
using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Data.DTOs.DTOsGL;
using GeneralLedger.SelfServiceCore.Services.ServicesGL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    [Authorize]
    public class CanvasController : Controller
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        #endregion UserManager

        #region Services

        private readonly IOrdenService ordenService;
        private readonly IAccglUsuarioService usuarioGlService;
        private readonly IProdependeService prodependeService;
        private readonly IViewSubCentroCostoService viewSubCentroCostoService;

        #endregion Services

        #region Others

        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;

        #endregion Others

        #region Contructor

        public CanvasController
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOrdenService ordenService,
            IAccglUsuarioService usuarioGlService,
            IProdependeService prodependeService,
            IViewSubCentroCostoService viewSubCentroCostoService,
            IMapper mapper,
            IHttpContextAccessor contextAccessor
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ordenService = ordenService;
            this.usuarioGlService = usuarioGlService;
            this.prodependeService = prodependeService;
            this.viewSubCentroCostoService = viewSubCentroCostoService;
            this.mapper = mapper;
            this.contextAccessor = contextAccessor;

            ConnectionTools.SetKeyConnectionStringDirect(SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection"));
        }

        #endregion Contructor

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var rol = userManager.GetRolesAsync(user).Result.FirstOrDefault();

            if (rol.Equals("ADMIN"))
            {
                ViewBag.UsuariosGL = await usuarioGlService.GetUsuariosGL();
                ViewBag.SubCentroGL = await viewSubCentroCostoService.GetSubCentrosCostos();
            }

            ViewBag.OtFacturar = await ordenService.GetOTFacturar();
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetCanvas(string usuario, string subcentro)
        {
            usuario = (string.IsNullOrEmpty(usuario)) ? "" : usuario;
            subcentro = (string.IsNullOrEmpty(subcentro)) ? "" : subcentro;

            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var rol = userManager.GetRolesAsync(user).Result.FirstOrDefault();

            IEnumerable<CanvasShowDTO> canvas;

            if (rol.Equals("ADMIN"))
            {
                canvas = await ordenService.GetCanvas(usuario, subcentro);
            }
            else
            {
                var subcc = await prodependeService.GetCentroCostoByUser(user.UsuarioGL);
                canvas = await ordenService.GetCanvas(subcc);
            }
            ViewBag.OtFacturar = await ordenService.GetOTFacturar();
            return Json(new { data = canvas });
        }
    }
}