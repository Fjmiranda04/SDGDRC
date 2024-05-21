using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Implements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    public class CotizacionController : Controller
    {
        #region Services
        private readonly ICotizacionService cotizacionService;
        private readonly IClienteService clienteService;
        private readonly ISolicitanteCtzService solicitanteService;
        private readonly IArticuloService articuloService;
        private readonly IServicioService servicioService;
        #endregion Services

        public CotizacionController(
            ICotizacionService cotizacionService,
            IClienteService clienteService,
            ISolicitanteCtzService solicitanteService,
            IArticuloService articuloService,
            IServicioService servicioService
            )
        {
            this.cotizacionService = cotizacionService;
            this.clienteService = clienteService;
            this.solicitanteService = solicitanteService;
            this.articuloService = articuloService;
            this.servicioService = servicioService;
        }

        // GET: CotizacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CotizacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CotizacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CotizacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CotizacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CotizacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CotizacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CotizacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet]
        public async Task<JsonResult> GetCotizaciones()
        {
            return Json(await cotizacionService.GetCotizaciones());
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet]
        public async Task<JsonResult> GetClientes(string filter)
        {
            var clientes = await clienteService.GetClientes(filter);

            return Json(clientes);
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet]
        public async Task<JsonResult> GetSolicitantes(string filter, string nitCliente)
        {
            var solicitantes = await solicitanteService.GetSolicitantes(filter, nitCliente);

            return Json(solicitantes);
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet]
        //[Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> GetArticulos()
        {
            return Json(await articuloService.GetArticulos());
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet]
        //[Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> GetServicios()
        {
            return Json(await servicioService.GetServicios());
        }

    }
}
