using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfService.Web.Models;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> userManager;

        #endregion UserManager

        #region Services

        private readonly IMenuService menuService;
        private readonly IPQRSFService pqrsfService;
        private readonly ITratamientoPQRSFService tratamientoPQRSFService;
        private readonly IProfilerService profilerService;
        private readonly string KeyConnection;

        #endregion Services

        #region Others

        private readonly ILogger<HomeController> logger;
        private readonly IHttpContextAccessor contextAccessor;

        #endregion Others

        #region Constructor

        public HomeController
        (
            UserManager<ApplicationUser> userManager,
            IMenuService menuService,
            IPQRSFService pqrsfService,
            ITratamientoPQRSFService tratamientoPQRSFService,
            IProfilerService profilerService,
            ILogger<HomeController> logger,
            IHttpContextAccessor contextAccessor
        )
        {
            this.userManager = userManager;

            this.menuService = menuService;
            this.pqrsfService = pqrsfService;
            this.tratamientoPQRSFService = tratamientoPQRSFService;
            this.profilerService = profilerService;

            this.logger = logger;
            this.contextAccessor = contextAccessor;

            ConnectionTools.SetKeyConnectionStringDirect(SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection"));
            KeyConnection = SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection");
        }

        #endregion Constructor

        #region ActionMethods

        [Authorize]
        public async Task<IActionResult> Home()
        {
                return View();           
        }

        [Authorize(Roles = "ADMIN,AGENTE,CLIENTE")]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var rol = SessionHelper.GetValue(User, ClaimTypes.Role);

            if (rol == "CLIENTE")
            {
                return View("Dashboard");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> List(string state)
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var listPQRSF = await pqrsfService.GetAllPQRSF();
            var permisos = await profilerService.GetInstancia().ProConfiguracion.GetPermisosUsuario(user.Id, KeyConnection);
            var areaAgente = profilerService.GetInstancia().ProAgentes.GetAgente(user.NroId, KeyConnection).Result.Area;

            var pqrsfs = listPQRSF.Where(x => x.NroIdResponsable == user.NroId);
            ViewBag.Estado = "Todas";

            if (permisos.Where(x => x.Codigo == "000006" && !x.Activo).Count() > 0)
            {
                pqrsfs = pqrsfs.Where(x => x.IdProceso == areaAgente);
            }

            if (state != "all" && state != "VenceHoy")
            {
                pqrsfs = pqrsfs.Where(x => x.Estado == state);
                ViewBag.Estado = state;
            }

            if (state.Equals("VenceHoy"))
            {
                pqrsfs = pqrsfs.Where(x => x.FechaCierre.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"));
                ViewBag.Estado = "Vencen Hoy";
            }

            return View(pqrsfs);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<JsonResult> GetAllActividadesByAgente()
        {
            var NroIdAge = userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
            var listActividades = await tratamientoPQRSFService.GetAllTratamientoByAgente(NroIdAge);
            return Json(new { data = listActividades });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,AGENTE,CLIENTE")]
        public async Task<JsonResult> CheckActividad(int? id)
        {
            if (id == null)
            {
                return Json(new { result = false, message = "Ups! Ha ocurrido un problema, intente nuevamente" });
            }

            var actividad = await tratamientoPQRSFService.GetById(id.Value);
            actividad.Checked = !(actividad.Checked);
            actividad.FechaCheck = DateTime.Now;

            if (actividad == null)
            {
                return Json(new { result = false, message = "Ups! Ha ocurrido un problema, intente nuevamente" });
            }

            await tratamientoPQRSFService.Update(actividad);

            return Json(new { result = true, message = "Cambio realizado!" });
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<JsonResult> GetAssignedClosePQRSFByAgent()
        {
            List<int> listValues = new List<int>();

            try
            {
                var NroIdAge = userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                var pqrsf = await pqrsfService.GetAllPQRSFByAgente(NroIdAge);

                pqrsf = pqrsf.Where(x => x.Estado == "Cerrada").Where(x => x.NroIdCerro == NroIdAge).OrderBy(x => x.FechaCierreReal);
                var fechas = pqrsf.Select(x => x.FechaCierreReal.ToString("yyyy-MM-dd")).Distinct();

                foreach (var fecha in fechas)
                {
                    listValues.Add(pqrsf.Count(x => x.FechaCierreReal.ToString("yyyy-MM-dd") == fecha));
                }

                var result = await profilerService.GetInstancia().ProPqrsf.GetAyerVsHoyPqrsf(NroIdAge, KeyConnection);
                var dthoyr = result.Where(x => x.Dia.Equals("HOY")).FirstOrDefault();
                var dtayerr = result.Where(x => x.Dia.Equals("AYER")).FirstOrDefault();

                var data = new { date = fechas, values = listValues, dthoy = dthoyr, dtayer = dtayerr };
                return Json(new { data = data });
            }
            catch (Exception ex)
            {
                return Json(new { data = "" });
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<JsonResult> GetDataByPeriodo(string mes, string anio)
        {
            List<int> listValues = new List<int>();

            try
            {
                var NroIdAge = userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                var result = await profilerService.GetInstancia().ProPqrsf.GetDataByPerido(NroIdAge, mes, anio, KeyConnection);
                var listbyday = await profilerService.GetInstancia().ProPqrsf.GetPqrsfByDay(NroIdAge, mes, anio, KeyConnection);

                return Json(new { data = result, listbydayA = listbyday.Where(x => x.Tipo.Equals("ASSIGNED")).FirstOrDefault(), listbydayR = listbyday.Where(x => x.Tipo.Equals("RESOLVED")).FirstOrDefault() });
            }
            catch (Exception ex)
            {
                return Json(new { data = "" });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetStatisticsHome()
        {
            var user = await profilerService.GetInstancia().proUserManager.FindByNameAsync(User.Identity.Name, KeyConnection); //Esto consulta a aspnetusers

            try
            {
                List<int> canXState = new List<int>();
                //List<Porcentajes> canXPQRSF = new List<Porcentajes>();
                var listPqrsf = await profilerService.GetInstancia().ProPqrsf.GetStatistics(user.NroId, KeyConnection);
                canXState.Add(listPqrsf.Count());//ASIGNADAS
                canXState.Add(listPqrsf.Where(x => x.Estado.Equals("ABIERTA")).Count());
                canXState.Add(listPqrsf.Where(x => x.Estado.Equals("PENDIENTE")).Count());
                canXState.Add(listPqrsf.Where(x => x.Estado.Equals("GESTION")).Count());
                canXState.Add(listPqrsf.Where(x => x.Estado.Equals("CERRADA")).Count());
                canXState.Add(listPqrsf.Where(x => x.Perfilada == true && x.FechaCierre.ToString("yyyyMMdd").Equals(DateTime.Now.ToString("yyyyMMdd")) && !x.Estado.Equals("CERRADA")).Count());

                int total = listPqrsf.Count();

                List<Porcentajes> canXPQRSF = new List<Porcentajes>
                {
                    new Porcentajes {Porcentaje = (double)total, Cantidad = (int)total },
                    new Porcentajes {Porcentaje = (total == 0)? 0 :Math.Round((((listPqrsf.Where(x => x.TipoPeticion.Equals("PETICION")).Count()) * 100.00) / total),2), Cantidad = (listPqrsf.Where(x => x.TipoPeticion.Equals("PETICION")).Count()) },
                    new Porcentajes {Porcentaje = (total == 0)? 0 :Math.Round((((listPqrsf.Where(x => x.TipoPeticion.Equals("QUEJA")).Count()) * 100.00) / total),2), Cantidad = (listPqrsf.Where(x => x.TipoPeticion.Equals("QUEJA")).Count()) },
                    new Porcentajes {Porcentaje = (total == 0)? 0 :Math.Round((((listPqrsf.Where(x => x.TipoPeticion.Equals("RECLAMO")).Count()) * 100.00) / total),2), Cantidad = (listPqrsf.Where(x => x.TipoPeticion.Equals("RECLAMO")).Count()) },
                    new Porcentajes {Porcentaje = (total == 0)? 0 :Math.Round((((listPqrsf.Where(x => x.TipoPeticion.Equals("SUGERENCIA")).Count()) * 100.00) / total),2), Cantidad = (listPqrsf.Where(x => x.TipoPeticion.Equals("SUGERENCIA")).Count()) },
                    new Porcentajes {Porcentaje = (total == 0)? 0 :Math.Round((((listPqrsf.Where(x => x.TipoPeticion.Equals("FELICITACION")).Count()) * 100.00) / total),2), Cantidad = (listPqrsf.Where(x => x.TipoPeticion.Equals("FELICITACION")).Count()) },
                };

                IEnumerable<object> listCanXPQRSF = canXPQRSF.Select(p => new { p.Porcentaje, p.Cantidad });

                var data = new { xState = canXState, xPqrsf = listCanXPQRSF };

                return Json(new { result = true, message = "Done", data = data });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        #endregion ActionMethods
    }
}

//CASE MODELO
public class Porcentajes
{
    [JsonPropertyName("porcentaje")]
    public double Porcentaje;

    [JsonPropertyName("cantidad")]
    public int Cantidad;
}