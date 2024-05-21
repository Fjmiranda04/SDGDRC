using AutoMapper;
using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    [Authorize]
    public class PQRSFController : Controller
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        #endregion UserManager

        #region Services

        private readonly IConfiguracionService configuracionService;
        private readonly IArchivoControl archivoControl;
        private readonly IAmazonUploader amazonUploader;
        private readonly IEmailConfiguracionService emailConfiguracionService;
        private readonly IPQRSFService pqrsfService;
        private readonly IPQRSFEstadoService pqrsfEstadoService;
        private readonly IPQRSFPrioridadService pqrsfPrioridadService;
        private readonly IClienteService clienteService;
        private readonly ISituacionService situacionService;
        private readonly IContactoClienteService contactoClienteService;
        private readonly IArchivoService archivoService;
        private readonly IAgenteService agenteService;
        private readonly IEmpleadoService empleadoService;
        private readonly IProcesoService procesoService;
        private readonly IEtiquetaService etiquetaService;
        private readonly ITratamientoPQRSFService tratamientoPQRSFService;
        private readonly ISeguimientoPQRSFService seguimientoPQRSFService;
        private readonly IPreguntaService preguntaService;
        private readonly IRespuestaService respuestaService;
        private readonly INotaPQRSFService notaPQRSFService;
        private readonly IProfilerService profilerService;
        private readonly IMail mail;

        #endregion Services

        #region Others

        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IMemoryCache _memoryCache;
        private readonly string KeyConnection;
        private ProAspNetUser USUARIO = new ProAspNetUser();

        #endregion Others

        #region Constructor

        public PQRSFController
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IPQRSFService pqrsfService,
            IPQRSFEstadoService pqrsfEstadoService,
            IPQRSFPrioridadService pqrsfPrioridadService,
            ISituacionService situacionService,
            IProcesoService procesoService,
            IClienteService clienteService,
            IAgenteService agenteService,
            IEmpleadoService empleadoService,
            IContactoClienteService contactoClienteService,
            ITratamientoPQRSFService tratamientoPQRSFService,
            IEtiquetaService etiquetaService,
            ISeguimientoPQRSFService seguimientoPQRSFService,
            IPreguntaService preguntaService,
            IRespuestaService respuestaService,
            INotaPQRSFService notaPQRSFService,
            IArchivoService archivoService,
            IConfiguracionService configuracionService,
            IArchivoControl archivoControl,
            IAmazonUploader amazonUploader,
            IEmailConfiguracionService emailConfiguracionService,
            IProfilerService profilerService,
            IMail mail,
            IMapper mapper,
            IHttpContextAccessor contextAccessor,
            IMemoryCache memoryCache

        )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;

            this.pqrsfService = pqrsfService;
            this.pqrsfEstadoService = pqrsfEstadoService;
            this.pqrsfPrioridadService = pqrsfPrioridadService;
            this.situacionService = situacionService;
            this.procesoService = procesoService;
            this.clienteService = clienteService;
            this.agenteService = agenteService;
            this.empleadoService = empleadoService;
            this.contactoClienteService = contactoClienteService;
            this.tratamientoPQRSFService = tratamientoPQRSFService;
            this.etiquetaService = etiquetaService;
            this.seguimientoPQRSFService = seguimientoPQRSFService;
            this.preguntaService = preguntaService;
            this.respuestaService = respuestaService;
            this.notaPQRSFService = notaPQRSFService;
            this.archivoService = archivoService;
            this.configuracionService = configuracionService;
            this.archivoControl = archivoControl;
            this.amazonUploader = amazonUploader;
            this.emailConfiguracionService = emailConfiguracionService;
            this.profilerService = profilerService;
            this.mail = mail;

            this.mapper = mapper;
            this.contextAccessor = contextAccessor;
            this._memoryCache = memoryCache;
            ConnectionTools.SetKeyConnectionStringDirect(SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection"));
            KeyConnection = SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection");
        }

        #endregion Constructor

        #region ActionMethods

        [Authorize(Roles = "ADMIN,CLIENTE,AGENTE")]
        public async Task<IActionResult> Index()
        {
            var user = await profilerService.GetInstancia().proUserManager.FindByNameAsync(User.Identity.Name, KeyConnection); //Esto consulta a aspnetusers

            //   var situaciones =  await profilerService.GetInstancia().ProProfilerGeneric.GetAllSituaciones(KeyConnection);

            ViewBag.Situaciones = await profilerService.GetInstancia().ProProfilerGeneric.GetAllSituaciones(KeyConnection);
            ViewBag.Estados = await profilerService.GetInstancia().ProProfilerGeneric.GetAllEstados(KeyConnection);
            ViewBag.Permisos = null;

            var permisos = new List<ProPermisosUsuarios>();
            var situaciones = new List<Situacion>();
            var estados = new List<Estado>();

            if (_memoryCache.TryGetValue($"permisosUsuario{user.Id}", out permisos))
            {
                ViewBag.Permisos = permisos;
            }
            else
            {
                var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(600000));

                permisos = profilerService.GetInstancia().ProConfiguracion.GetPermisosUsuario(user.Id, KeyConnection).Result.ToList();

                _memoryCache.Set($"permisosUsuario{user.Id}", permisos, cacheOptions);

                ViewBag.Permisos = permisos;
            }

            if (_memoryCache.TryGetValue($"proestados", out estados))
            {
                ViewBag.Estados = estados;
            }
            else
            {
                var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(600000));

                estados = profilerService.GetInstancia().ProProfilerGeneric.GetAllEstados(KeyConnection).Result.ToList();

                _memoryCache.Set($"proestados", estados, cacheOptions);

                ViewBag.Estados = estados;
            }

            return View();
        }

        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<IActionResult> List()
        {
            var user = await profilerService.GetInstancia().proUserManager.FindByNameAsync(User.Identity.Name, KeyConnection);
            // var permisos = await profilerService.GetInstancia().ProConfiguracion.GetPermisosUsuario(user.Id, KeyConnection  );
            // var areaAgente = profilerService.GetInstancia().ProAgentes.GetAgente(user.NroId, KeyConnection).Result.Area;

            ViewBag.Clientes = await profilerService.GetInstancia().ProCliente.GetClientes(KeyConnection);
            ViewBag.Situaciones = await profilerService.GetInstancia().ProProfilerGeneric.GetAllSituaciones(KeyConnection);

            ViewBag.Estados = await profilerService.GetInstancia().ProProfilerGeneric.GetAllEstados(KeyConnection);
            ViewBag.Prioridades = await profilerService.GetInstancia().ProProfilerGeneric.GetAllPrioridades(KeyConnection);

            ViewBag.Agentes = await profilerService.GetInstancia().ProAgentes.GetAgentes("", KeyConnection);

            return View();
        }

        [Authorize(Roles = "ADMIN,CLIENTE")]
        public async Task<IActionResult> Create()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var pqrsfCreateDTO = await pqrsfService.PreparePQRSFToCreate(user.NroId);
            pqrsfCreateDTO.NitEmpresa = user.NitEmpresa;
            return View(pqrsfCreateDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN,CLIENTE,AGENTE")]
        public async Task<JsonResult> Create(PQRSFCreateDTO pqrsfCreateDTO)
        {
            var user = await profilerService.GetInstancia().proUserManager.FindByNameAsync(User.Identity.Name, KeyConnection); //Esto consulta a aspnetusers
            pqrsfCreateDTO.Fecha = DateTime.Now;
            pqrsfCreateDTO.NitEmpresa = user.NitEmpresa;

            if (string.IsNullOrEmpty(pqrsfCreateDTO.Descripcion))
            {
                pqrsfCreateDTO.Descripcion = "Nueva pqrsf";
                pqrsfCreateDTO.Tipo = "PQRSF Externa";
            }
            var pqrsf = mapper.Map<PQRSF>(pqrsfCreateDTO);

            try
            {
                var pqrsfresult = await profilerService.GetInstancia().ProPqrsf.SavePqrsf(pqrsf, KeyConnection);
                var configuracion = await profilerService.GetInstancia().ProConfiguracion.GetConfiguraciones(KeyConnection);
                var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("MAILCLIENTEPQRSF", KeyConnection);
                var agentes = await profilerService.GetInstancia().ProAgentes.GetAgentes("", KeyConnection);

                var url = configuracion.Where(c => c.Id == 3).Select(c => c.Valor).FirstOrDefault();
                var idBucket = configuracion.Where(c => c.Id == 4).Select(c => c.Valor).FirstOrDefault();
                var bucket = configuracion.Where(c => c.Id == 5).Select(c => c.Valor).FirstOrDefault();
                var urlCliente = Url.Page("", pageHandler: null, values: new { Id = pqrsfresult.Codigo }, protocol: Request.Scheme).Replace("Create", "Details");
                var urlAgente = Url.Page("", pageHandler: null, values: new { Id = pqrsfresult.Codigo }, protocol: Request.Scheme).Replace("Create", "Profiler");

                mail.SendMailPQRSF(pqrsfresult, agentes.ToList(), emailconfig, urlCliente, urlAgente);

                #region UploadArchivo

                if (pqrsfCreateDTO.Archivos != null)
                {
                    foreach (var item in pqrsfCreateDTO.Archivos)
                    {
                        var archivo = mapper.Map<Archivo>(await archivoControl.SaveFilesPQRSF(Convert.ToInt32(pqrsfresult.Codigo), item, url));
                        archivo.NitEmpresa = user.NitEmpresa;
                        archivo = await profilerService.GetInstancia().ProConfiguracion.SaveArchivo(archivo, KeyConnection);
                        amazonUploader.SendFileToS3(idBucket, archivo.Ruta, bucket, "", archivo.Nombre);
                    }
                }

                #endregion UploadArchivo
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Ups! Ha ocurrido un error, intentelo nuevamente" });
            }

            TempData["Message"] = "PQRSF Creada con exito";
            return Json(new { result = true });
        }

        [Authorize(Roles = "ADMIN,CLIENTE")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var pqrsfShowDTO = await pqrsfService.GetPQRSFByCliente(id.Value, user.NroId);

            if (pqrsfShowDTO == null)
            {
                return View("NotFound");
            }

            return View(pqrsfShowDTO);
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await pqrsfService.Delete(id.Value);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> DeleteByRange(string ids)
        {
            if (ids == "")
            {
                return NotFound();
            }
            else
            {
                var list = ids.Split('-').ToList();

                foreach (var id in list)
                {
                    await pqrsfService.Delete(int.Parse(id));
                }
            }

            return Json(new { result = "Redirect", url = Url.Action("Index", "PQRSF") });
        }

        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<IActionResult> Profiler(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var pqrsf = await pqrsfService.GetPQRSFToProfiler(id);

            if (pqrsf == null)
            {
                return View("NotFound");
            }

            var pqrsfProfilerDTO = mapper.Map<PQRSFProfilerDTO>(pqrsf);
            ViewBag.Archivos = await archivoService.GetArchivosByIdPQRSF(pqrsf.Id);
            ViewBag.Trazabilidad = await notaPQRSFService.GetAllNotasByAgente(pqrsf.Id);
            ViewBag.Agentes = await agenteService.GetAll();
            ViewBag.Procesos = await profilerService.GetInstancia().ProAreas.GetAreas("", KeyConnection);//procesoService.GetAll();
            ViewBag.Etiquetas = await profilerService.GetInstancia().ProEtiquetas.GetEtiquetas("", KeyConnection);
            ViewBag.Estados = await pqrsfEstadoService.GetAll();
            ViewBag.Prioridades = await pqrsfPrioridadService.GetAll();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Permisos = await profilerService.GetInstancia().ProConfiguracion.GetPermisosUsuario(user.Id, KeyConnection);

            return View(pqrsfProfilerDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<IActionResult> Profiler(PQRSFProfilerDTO pQRSFProfilerDTO)
        {
            var pqrsf = await pqrsfService.GetById(pQRSFProfilerDTO.Id);
            var sendmail = (pQRSFProfilerDTO.NroIdResponsable == pqrsf.NroIdResponsable) ? false : true;
            pqrsf.Perfilacion = true;
            pqrsf.NroIdPerfilo = _userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
            pqrsf.FechaCierre = pQRSFProfilerDTO.FechaCierre;
            pqrsf.IdEstado = pQRSFProfilerDTO.IdEstado;
            pqrsf.IdPrioridad = pQRSFProfilerDTO.IdPrioridad;
            pqrsf.Etiquetas = pQRSFProfilerDTO.Etiquetas;
            pqrsf.IdProceso = pQRSFProfilerDTO.IdProceso;
            pqrsf.NroIdResponsable = pQRSFProfilerDTO.NroIdResponsable;

            pqrsf = await pqrsfService.Update(pqrsf);

            if (sendmail)
            {
                //var emailconf = mapper.Map<EmailConfiguracionDTO>(await emailConfiguracionService.GetEmailConfiguracionByKey("PROPQRSF"));
                var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("PROPQRSF", KeyConnection);

                var agente = await agenteService.GetAgenteByNroId(pqrsf.NroIdResponsable);
                var destinatarios = agente.Email.Split(',').ToList();
                var body = emailconfig.Cuerpo.Replace("<<NUMERO>>", pqrsf.Id.ToString());
                mail.SendMail(body, destinatarios, emailconfig);
            }

            TempData["MessageProfiler"] = "¡Perfilación actualizada con exito!";
            return RedirectToAction("Profiler", "PQRSF", routeValues: new { id = pqrsf.Id });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<JsonResult> GetTratamiento(int? id)
        {
            var list = await tratamientoPQRSFService.GetAllTratamientoById(id);
            return Json(new { data = list });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<IActionResult> SaveTratamiento(TratamientoPQRSFCreateDTO tratamientoPQRSFCreateDTO)
        {
            if (tratamientoPQRSFCreateDTO.Actividad != null)
            {
                var tratamientoPQRSF = mapper.Map<TratamientoPQRSF>(tratamientoPQRSFCreateDTO);
                tratamientoPQRSF.NitEmpresa = _userManager.FindByNameAsync(User.Identity.Name).Result.NitEmpresa;
                tratamientoPQRSF = await tratamientoPQRSFService.Insert(tratamientoPQRSF);
                return Json(new { result = true, message = "Tratamiento agregado con exito" });
            }
            else
            {
                return Json(new { result = false, message = "Hay campos obligatorios que debe llenar" });
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteTratamiento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await tratamientoPQRSFService.Delete(id.Value);
            return Json(new { result = true, message = "Registro eliminado con exito" });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<IActionResult> GetSeguimiento(int? id)
        {
            var list = await seguimientoPQRSFService.GetAllSeguimientoById(id);
            return Json(new { data = list });
        }

        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<JsonResult> SaveSeguimiento(SeguimientoPQRSFCreateDTO seguimientoPQRSFCreateDTO)
        {
            if (seguimientoPQRSFCreateDTO.Observaciones != null)
            {
                var seguimientoPQRSF = mapper.Map<SeguimientoPQRSF>(seguimientoPQRSFCreateDTO);
                seguimientoPQRSF.NitEmpresa = _userManager.FindByNameAsync(User.Identity.Name).Result.NitEmpresa;
                seguimientoPQRSF = await seguimientoPQRSFService.Insert(seguimientoPQRSF);
                return Json(new { result = true, message = "Seguimiento agregado con exito" });
            }
            else
            {
                return Json(new { result = false, message = "Hay campos obligatorios que debe llenar" });
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<JsonResult> GetPreguntas()
        {
            var preguntas = await preguntaService.GetAll();
            return Json(new { data = preguntas });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<JsonResult> SavePreguntas([FromBody] List<RespuestaCreateDTO> listRespuestaCreateDTO)
        {
            var respuesta = new Respuesta();
            var pqrsf = new PQRSF();

            if (listRespuestaCreateDTO.Count > 0)
            {
                foreach (RespuestaCreateDTO respuestaCreateDTO in listRespuestaCreateDTO)
                {
                    respuesta = mapper.Map<Respuesta>(respuestaCreateDTO);
                    respuesta.NitEmpresa = _userManager.FindByNameAsync(User.Identity.Name).Result.NitEmpresa;
                    await respuestaService.Insert(respuesta);
                }
                var idPQRSF = listRespuestaCreateDTO[0].IdPQRSF;
                pqrsf = await pqrsfService.GetById(idPQRSF);
                pqrsf.IdEstado = 5;//Estado Cerrada
                pqrsf.FechaCierreReal = DateTime.Now;
                pqrsf.NroIdCerro = _userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                await pqrsfService.Update(pqrsf);

                return Json(new { result = true, message = "PQRSF cerrada con exito", redirect = @Url.Action("Profiler", "PQRSF", new { id = idPQRSF }) });
            }
            else
            {
                return Json(new { result = false, message = "Ups! Ha ocurrido un error, intente de nuevo." });
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,AGENTE,CLIENTE")]
        public async Task<IActionResult> ClosePQRSFCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var NroIdCli = _userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
            var pqrsfShowDTO = await pqrsfService.GetById(id.Value);

            if (pqrsfShowDTO == null)
            {
                TempData["Message"] = "Ups! Ha ocurrido un error, intente de nuevo!";
                return Json(new { result = true, message = "Ups! Ha ocurrido un error, intente de nuevo." });
            }
            else
            {
                var pqrsf = mapper.Map<PQRSF>(pqrsfShowDTO);
                pqrsf.IdEstado = 4;
                pqrsf.FechaCierreReal = DateTime.Now;
                await pqrsfService.Update(pqrsf);

                TempData["Message"] = "La PQRSF ha sido cerrada con exito!";
                return Json(new { result = true, message = "PQRSF cerrada con exito", redirect = @Url.Action("Index", "PQRSF", new { id = pqrsf.Id }) });
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,AGENTE,CLIENTE")]
        public async Task<IActionResult> OpenPQRSFCliente(NotaPQRSF notaPQRSF)
        {
            if (notaPQRSF == null)
            {
                return NotFound();
            }
            var pqrsfShowDTO = await pqrsfService.GetById(notaPQRSF.IdPQRSF);

            if (pqrsfShowDTO == null)
            {
                TempData["Message"] = "Ups! Ha ocurrido un error, intente de nuevo!";
                return Json(new { result = true, message = "Ups! Ha ocurrido un error, intente de nuevo." });
            }
            else
            {
                var pqrsf = mapper.Map<PQRSF>(pqrsfShowDTO);
                pqrsf.IdEstado = 2;
                await pqrsfService.Update(pqrsf);

                notaPQRSF.Fecha = DateTime.Now;
                notaPQRSF.NroIdeAutor = _userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                notaPQRSF.NitEmpresa = _userManager.FindByNameAsync(User.Identity.Name).Result.NitEmpresa;
                await notaPQRSFService.Insert(notaPQRSF);

                TempData["Message"] = "La PQRSF ha sido abierta nuevamente!";
                return Json(new { result = true, message = "PQRSF abierta nuevamente", redirect = @Url.Action("Index", "PQRSF", new { id = pqrsf.Id }) });
            }
        }

        [Authorize(Roles = "ADMIN,AGENTE,CLIENTE")]
        [HttpPost]
        public async Task<IActionResult> AnswerPQRSF(NotaPQRSF notaPQRSF)
        {
            if (notaPQRSF == null)
            {
                return NotFound();
            }
            else
            {
                notaPQRSF.Fecha = DateTime.Now;
                notaPQRSF.NroIdeAutor = _userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                notaPQRSF.NitEmpresa = _userManager.FindByNameAsync(User.Identity.Name).Result.NitEmpresa;
                await notaPQRSFService.Insert(notaPQRSF);

                @TempData["MessageProfiler"] = "Respuesta agregada satisfactoriamente!";
                return Json(new { result = true, redirect = @Url.Action("Profiler", "PQRSF", new { id = notaPQRSF.IdPQRSF }) });
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,AGENTE,CLIENTE")]
        public async Task<IActionResult> ReportPQRSFPDF(int? id)
        {
            var reportPQRSFPDF = await pqrsfService.GetPQRSFToReport(id);
            return new ViewAsPdf("PdfReport", reportPQRSFPDF)
            {
                FileName = $"PQRSF{id}.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
            };
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,AGENTE,CLIENTE")]
        public async Task<IActionResult> ReportPQRSFExcel(int? id)
        {
            var reportPQRSFExcel = await pqrsfService.GetPQRSFToReport(id);
            var excel = Reports.GetReportPQRSFToExcel(reportPQRSFExcel);
            return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"PQRSF{id}.xlsx");
        }

        [Authorize(Roles = "ADMIN,AGENTE")]
        public IActionResult Statistic()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,AGENTE")]
        public async Task<IActionResult> LoadStatistic()
        {
            var pqrsf = await pqrsfService.GetAll();

            var cantidades = new
            {
                total = pqrsf.Count(),
                open = pqrsf.Count(x => x.IdEstado == 2),
                expires = pqrsf.Where(x => x.FechaCierre.ToString("MM/dd/yyyy") == DateTime.Now.ToString("MM/dd/yyyy")).Count(),
                noAssigned = pqrsf.Count(x => x.NroIdResponsable == "0000000000"),
                close = pqrsf.Count(x => x.IdEstado == 4),
                inmanagement = pqrsf.Count(x => x.IdEstado == 3)
            };

            var situaciones = await situacionService.GetAll();
            List<int> valuesSituacion = new List<int>();

            foreach (var situacion in situaciones)
            {
                valuesSituacion.Add(pqrsf.Where(x => x.IdSituacion == situacion.Id).Count());
            }
            var statisticResena = new
            {
                labels = situaciones.Select(x => x.TipoSituacion),
                values = valuesSituacion,
                title = "PQRSF Por Tipo de Reseña"
            };

            var estados = await pqrsfEstadoService.GetAll();
            List<int> valuesEstado = new List<int>();

            foreach (var estado in estados)
            {
                valuesEstado.Add(pqrsf.Where(x => x.IdEstado == estado.Id).Count());
            }

            var statisticEstados = new
            {
                labels = estados.Select(x => x.Nombre),
                values = valuesEstado,
                title = "PQRSF Por Estado"
            };

            var prioridades = await pqrsfPrioridadService.GetAll();
            List<int> valuesPrioridad = new List<int>();

            foreach (var prioridad in prioridades)
            {
                valuesPrioridad.Add(pqrsf.Where(x => x.IdPrioridad == prioridad.Id).Count());
            }

            var statisticPrioridad = new
            {
                labels = prioridades.Select(x => x.Nombre),
                values = valuesPrioridad,
                title = "PQRSF Por Prioridad"
            };

            var procesos = await procesoService.GetAll();
            List<int> valuesProcesos = new List<int>();

            foreach (var proceso in procesos)
            {
                valuesProcesos.Add(pqrsf.Where(x => x.IdProceso == proceso.codare).Count());
            }

            var statisticProceso = new
            {
                labels = procesos.Select(x => x.nomare),
                values = valuesProcesos,
                title = "PQRSF Por Area/Proceso"
            };

            List<int> data = new List<int>();
            List<Object> series = new List<object>();
            var pqrsfOrder = pqrsf.OrderBy(x => x.Fecha);
            var fechas = pqrsfOrder.Select(x => DateTime.Parse(x.Fecha.ToString("MM/dd/yyyy"))).Distinct();

            foreach (var fecha in fechas)
            {
                data.Add(pqrsf.Count(x => DateTime.Parse(x.Fecha.ToString("MM/dd/yyyy")) == fecha));
            }

            var statisticTime = new
            {
                dates = fechas,
                data = data
            };

            return Json(new { timepqrsf = statisticTime, resena = statisticResena, estados = statisticEstados, prioridad = statisticPrioridad, procesos = statisticProceso, count = cantidades });
        }

        [Authorize(Roles = "ADMIN,CLIENTE,AGENTE")]
        public IActionResult DownLoadArchivo(string id)
        {
            var list = id.Split("&&&&").ToArray();
            var nombreArchivo = list[0];
            var content = list[1];
            var contentType = content.Replace("%", "/");
            var FileVirtualPath = $"~/Temp/Trash/{nombreArchivo}";

            var ruote = Environment.CurrentDirectory + $"\\wwwroot\\Temp\\Trash\\{nombreArchivo}";

            if (!System.IO.File.Exists(ruote))
            {
                var config = configuracionService.GetAll().Result;
                var url = config.Where(c => c.Id == 3).Select(c => c.Valor).FirstOrDefault();
                var idBucket = config.Where(c => c.Id == 4).Select(c => c.Valor).FirstOrDefault();
                var bucket = config.Where(c => c.Id == 5).Select(c => c.Valor).FirstOrDefault();
                var nitempresa = config.Where(c => c.Id == 9).Select(c => c.Valor).FirstOrDefault();

                amazonUploader.DownLoadFile(idBucket, bucket, nombreArchivo, nitempresa);
            }

            byte[] archivoBytes = System.IO.File.ReadAllBytes(ruote);

            // Crear el resultado de la acción para la descarga
            var result = new FileContentResult(archivoBytes, contentType)
            {
                FileDownloadName = nombreArchivo
            };

            return result;

            //return File(FileVirtualPath, contentType, Path.GetFileName(FileVirtualPath));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetPqrsf(FilterPQRSFDTO filter)
        {
            try
            {
                filter.Search = (string.IsNullOrEmpty(filter.Search)) ? "na" : filter.Search;
                var result = await pqrsfService.GetPqrsf(filter, KeyConnection);

                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetPqrsfByUser(FilterPQRSFDTO filter)
        {
            try
            {
                filter.Search = (string.IsNullOrEmpty(filter.Search)) ? "na" : filter.Search;
                var user = await profilerService.GetInstancia().proUserManager.FindByNameAsync(User.Identity.Name, KeyConnection);
                var result = await pqrsfService.GetAllPQRSFByUser(user.NroId, filter, KeyConnection);

                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,CLIENTE,AGENTE")]
        public async Task<JsonResult> LoadContactosCliente()
        {
            try
            {
                var user = await profilerService.GetInstancia().proUserManager.FindByNameAsync(User.Identity.Name, KeyConnection);
                var listContactosCliente = await profilerService.GetInstancia().proContacto.GetContactoClientes(KeyConnection);
                return Json(new { result = true, message = "Done", data = listContactosCliente });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult UploadImageSummerNote(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Environment.CurrentDirectory + $"\\wwwroot\\Temp\\Trash\\", "imagessummer");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    var imageUrl = "/imagessummer/" + uniqueFileName; // Ruta a la imagen guardada
                    return Ok(new { filePath = imageUrl });
                }
                else
                {
                    return BadRequest("No se ha recibido ninguna imagen.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        #endregion ActionMethods
    }
}