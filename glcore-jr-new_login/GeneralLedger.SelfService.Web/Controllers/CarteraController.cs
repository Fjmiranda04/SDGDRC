using AutoMapper;
using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Model.Structures;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    [Authorize]
    public class CarteraController : Controller
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationUser userSession;

        #endregion UserManager

        #region Services

        private readonly IAnalisisVencimientoService analisisVencimientoService;
        private readonly IFichaTecnicaService fichaTecnicaService;
        private readonly IImputacionService imputacionService;
        private readonly IPagoService pagoService;
        private readonly IProfilerService profilerService;

        #endregion Services

        #region Others

        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly string KeyConnection;
        private readonly IMemoryCache _memoryCache;

        #endregion Others

        #region Constructor

        public CarteraController
        (
            UserManager<ApplicationUser> userManager,
            IAnalisisVencimientoService analisisVencimientoService,
            IFichaTecnicaService fichaTecnicaService,
            IImputacionService imputacionService,
            IPagoService pagoService,
            IMapper mapper,
            IHttpContextAccessor contextAccessor,
            IProfilerService profilerService,
            IMemoryCache memoryCache
        )
        {
            this.userManager = userManager;

            this.analisisVencimientoService = analisisVencimientoService;
            this.fichaTecnicaService = fichaTecnicaService;
            this.imputacionService = imputacionService;
            this.pagoService = pagoService;
            this.profilerService = profilerService;
            _memoryCache = memoryCache;
            this.mapper = mapper;
            this.contextAccessor = contextAccessor;

            ConnectionTools.SetKeyConnectionStringDirect(SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection"));
            userSession = userManager.FindByNameAsync(this.contextAccessor.HttpContext.User.Identity.Name).Result;

            ConnectionTools.SetKeyConnectionStringDirect(SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection"));
            KeyConnection = SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection");
        }

        #endregion Constructor

        [Authorize]
        public IActionResult Index()
        {
            //var analisisVencimiento = mapper.Map<IEnumerable<AnalisisVencimientoListDTO>>(await analisisVencimientoService.GetAnalisisVencimientoByCliente("900635373"));
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            //var analisisVencimiento = mapper.Map<IEnumerable<AnalisisVencimientoListDTO>>(await analisisVencimientoService.GetAnalisisVencimientoByCliente("900635373"));

            var clientes = new List<SelfServiceCore.Data.ModelsGL.Cliente>();
            ViewBag.Clientes = null;

            if (_memoryCache.TryGetValue("clientes", out clientes))
            {
                ViewBag.Clientes = clientes;
            }
            else
            {
                var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(600000));

                clientes = profilerService.GetInstancia().ProCliente.GetClientes(KeyConnection).Result.ToList();
                _memoryCache.Set("clientes", clientes, cacheOptions);
                ViewBag.Clientes = clientes;
            }

            
            ViewBag.Dependencias = await profilerService.GetInstancia().ProProfilerGeneric.GetDependencias(KeyConnection);
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetEstadoCuenta(string search, string endDate, string startDate = "", int daysRange = 2, bool cancel = false)
        {
            if (startDate == null) startDate = "";

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var rol = userManager.GetRolesAsync(user);

            if (rol.Result.Contains("CLIENTE"))
            {
                var analisisVencimientoC = mapper.Map<IEnumerable<AnalisisVencimientoListDTO>>(await analisisVencimientoService.GetAnalisisVencimientoByCliente(search, userSession.NroId, endDate, startDate, daysRange, cancel));
                return Json(new { data = analisisVencimientoC });
            }

            var analisisVencimiento = mapper.Map<IEnumerable<AnalisisVencimientoListDTO>>(await analisisVencimientoService.GetAnalisisVencimientoByCliente(search, "", endDate, startDate, daysRange, cancel));
            return Json(new { data = analisisVencimiento });
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetFichaTecnica(string nroFactura)
        {
            if (!string.IsNullOrEmpty(nroFactura))
            {
                var fichaTecnica = mapper.Map<FichaTecnicaShowDTO>(await fichaTecnicaService.GetFichaTecnica(nroFactura));
                //fichaTecnica.ListImputaciones = await imputacionService.GetImputaciones(nroFactura);
                fichaTecnica.ListPagos = await pagoService.GetPagos(nroFactura);
                return Json(new { result = true, data = fichaTecnica });
            }

            return Json(new { result = false, message = "Ups! Ha ocurrido un error, intentelo nuevamente" });
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetAnalisisData(string fecha, int rango)
        {
            try
            {
                var analisisVencimientoEstadistica = new List<SelfServiceCore.Data.Models.AnalisisVencimientoEstadistica>();
                IEnumerable<object> analisisEstadisticas = null;

                if (_memoryCache.TryGetValue($"analsisvencimientoEstadistica{fecha}-{rango}", out analisisVencimientoEstadistica))
                {
                    analisisEstadisticas = analisisVencimientoEstadistica;
                }
                else
                {
                    var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(300));

                    analisisEstadisticas = await analisisVencimientoService.GetAnalisisVencimientoEstadisticas(fecha, rango.ToString(), KeyConnection);
                    _memoryCache.Set($"analsisvencimientoEstadistica{fecha}-{rango}", analisisEstadisticas, cacheOptions);                    
                }


                return Json(new { result = true, message = "Done", data = analisisEstadisticas });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Ups! Ha ocurrido un error, intentelo nuevamente" + ex.Message, data = "null" });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetRecaudoCartera(string fecha)
        {
            try
            {
                var result = new SelfServiceCore.Data.Models.Recaudos();  

                if (_memoryCache.TryGetValue($"recaudos{fecha}", out result))
                {
                    var datos = new
                    {
                        cartera = result.ListCartera,
                        recaudo = result.ListRecaudo
                    };

                    return Json(new { result = true, message = "Done", data = datos });
                }
                else
                {
                    result = analisisVencimientoService.GetRecaudoCartera(fecha, KeyConnection).Result;
                    var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(300));
                    _memoryCache.Set($"recaudos{fecha}", result, cacheOptions);

                    var datos = new
                    {
                        cartera = result.ListCartera,
                        recaudo = result.ListRecaudo
                    };

                    return Json(new { result = true, message = "Done", data = datos });
                }
               
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Ups! Ha ocurrido un error, intentelo nuevamente" + ex.Message, data = "null" });
            }
        }
    }
}