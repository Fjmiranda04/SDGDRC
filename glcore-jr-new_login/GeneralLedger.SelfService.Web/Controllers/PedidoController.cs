using AutoMapper;
using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Implements;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;


namespace GeneralLedger.SelfService.Web.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        #endregion UserManager

        #region Services

        private readonly IArticuloService articuloService;
        private readonly IServicioService servicioService;
        private readonly IPedidoService pedidoService;
        private readonly IProfilerService profilerService;
        #endregion Services

        #region Others

        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;
        private string KeyConnection;
        #endregion Others

        #region Constructor

        public PedidoController
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IArticuloService articuloService,
            IServicioService servicioService,
            IPedidoService pedidoService,
            IProfilerService profilerService,
            IMapper mapper,
            IHttpContextAccessor contextAccessor
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

            this.articuloService = articuloService;
            this.servicioService = servicioService;
            this.pedidoService = pedidoService;
            this.profilerService = profilerService;

            this.mapper = mapper;
            this.contextAccessor = contextAccessor;

            KeyConnection = SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection");
        }

        #endregion Constructor

        #region ActionMethods
        [Authorize]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetPedidosByClinit(string clinit)
        {
            try
            {
                // Aquí podrías llamar al servicio que obtiene los pedidos filtrados por clinit
                var pedidos = await pedidoService.GetPedidosByCliente(clinit);

                if (pedidos == null || !pedidos.Any())
                {
                    return NotFound();
                }

                return Json(pedidos);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [Authorize]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetPedidos(string FechaI, string FechaF)
        {
            if (string.IsNullOrEmpty(FechaI) || string.IsNullOrEmpty(FechaF))
            {
                return BadRequest("Las fechas de inicio y fin son requeridas.");
            }

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return Unauthorized(); // Usuario no autenticado
            }

            var rol = await userManager.GetRolesAsync(user);
            if (rol.Contains("ADMIN") || rol.Contains("AGENTE"))
            {
                var pedidos = await pedidoService.GetPedidos(FechaI, FechaF, "");
                return Json(pedidos);
            }

            var pedidosCliente = await pedidoService.GetPedidos(FechaI, FechaF, user.NroId);
            return Json(pedidosCliente);
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetDetallesPedido(string numeroPedido)
        {
            try
            {
                // Aquí llamas al servicio para obtener los detalles del pedido
                var detallesPedido = await pedidoService.GetDetallesPedido(numeroPedido);

                if (detallesPedido == null || !detallesPedido.Any())
                {
                    return NotFound();
                }

                return Json(detallesPedido);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cliente = await profilerService.GetInstancia().ProCliente.GetCliente(user.NroId, KeyConnection);

            if (string.IsNullOrEmpty(cliente.Clicod))
            {
                return View("/");
            }

            var result = await pedidoService.GetNewPedido(user.NroId, KeyConnection);
            return View("Create2", result);
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> Create(PedidoCreateDTO pedido)
        {
            try
            {
                pedido.Fecha = DateTime.Now.ToString("yyyyMMdd");
                pedido.FechaRequerido = pedido.FechaRequerido.Split('/')[2] + pedido.FechaRequerido.Split('/')[1] + pedido.FechaRequerido.Split('/')[0];
                var result = await pedidoService.SavePedido(pedido);

                return Json(new { result = true, redirect = @Url.Action("Index", "Pedido") });
            }
            catch
            {
                return Json(new { result = false });
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Authorize]
        public async Task<IActionResult> GetArticulos()
        {
            return Json(await articuloService.GetArticulos());
        }

        [HttpGet]
        [Produces("application/json")]
        [Authorize]
        public async Task<IActionResult> GetServicios()
        {
            return Json(await servicioService.GetServicios());
        }


        private void SetKeyConnection()
        {
            KeyConnection = userManager.FindByNameAsync(User.Identity.Name).Result.KeyConnection;
        }

        #endregion ActionMethods
    }
}
