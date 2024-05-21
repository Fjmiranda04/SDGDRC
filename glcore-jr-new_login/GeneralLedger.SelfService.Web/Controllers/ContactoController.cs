using AutoMapper;
using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    public class ContactoController : Controller
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        #endregion UserManager

        #region Services

        private readonly IContactoClienteService contactoClienteService;

        #endregion Services

        #region Others

        private readonly IMapper mapper;
        private readonly ILogger<HomeController> logger;
        private readonly IHttpContextAccessor contextAccessor;

        #endregion Others

        #region Constructor

        public ContactoController
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IContactoClienteService contactoClienteService,
            IMapper mapper,
            ILogger<HomeController> logger,
            IHttpContextAccessor contextAccessor
        )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

            this.contactoClienteService = contactoClienteService;

            this.mapper = mapper;
            this.logger = logger;
            this.contextAccessor = contextAccessor;

            ConnectionTools.SetKeyConnectionStringDirect(SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection"));
        }

        #endregion Constructor

        #region ActionMethods

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,CLIENTE,AGENTE")]
        public async Task<JsonResult> LoadContactosCliente()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var listContactosCliente = await contactoClienteService.GetContactByCliente(user.NroId);
            return Json(new { result = true, data = listContactosCliente });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,CLIENTE,AGENTE")]
        public async Task<JsonResult> SaveNewContacto(ContactoClienteCreateDTO contactoClienteCreateDTO)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            contactoClienteCreateDTO.NitEmpresa = user.NitEmpresa;
            contactoClienteCreateDTO.NroIdCli = user.NroId;
            var contactoCliente = mapper.Map<ContactoCliente>(contactoClienteCreateDTO);
            contactoCliente = await contactoClienteService.Insert(contactoCliente);
            return Json(new { result = true, contacto = contactoCliente.Id, message = "Contacto agregado con exito" });
        }

        #endregion ActionMethods
    }
}