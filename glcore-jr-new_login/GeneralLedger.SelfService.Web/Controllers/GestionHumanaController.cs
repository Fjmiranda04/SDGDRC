using Common;
using Common.Model;
using DocumentFormat.OpenXml.Wordprocessing;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xceed.Words.NET;
using Microsoft.Extensions.Logging;


namespace GeneralLedger.SelfService.Web.Controllers
{

    public class GestionHumanaController : Controller
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<GestionHumanaController> _logger;

        #endregion UserManager

        #region Services

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IGestionHumanaService gestionHumanaService;
        private readonly IProfilerService profilerService;

        #endregion Services

        #region Others

        private readonly IHttpContextAccessor contextAccessor;
        private string KeyConnection;
        private readonly IMail mail;

        #endregion Others

        #region Constructor

        public GestionHumanaController
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<GestionHumanaController> logger,

            IWebHostEnvironment webHostEnvironment,
            IGestionHumanaService gestionHumanaService,
            IProfilerService profilerService,
            IHttpContextAccessor contextAccessor,
            IMail mail
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._logger = logger;

            this.webHostEnvironment = webHostEnvironment;
            this.gestionHumanaService = gestionHumanaService;
            this.profilerService = profilerService;

            this.contextAccessor = contextAccessor;
            this.mail = mail;

            KeyConnection = SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection");
        }

        #endregion Constructor

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Solicitudes()
        {
            if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

            ViewBag.TipoNovedades = await profilerService.GetInstancia().ProGestionHumana.GetTipoNovedades("", KeyConnection);
            ViewBag.Eps = await profilerService.GetInstancia().ProGestionHumana.GetEps("", KeyConnection);
            ViewBag.Cesantias = await profilerService.GetInstancia().ProGestionHumana.GetFondosCesantias("", KeyConnection);
            ViewBag.Pension = await profilerService.GetInstancia().ProGestionHumana.GetFondosPension("", KeyConnection);
            ViewBag.CajasCompensacion = await profilerService.GetInstancia().ProGestionHumana.GetCajasCompensacion("", KeyConnection);

            return View();
        }

        [Authorize]
        public IActionResult SolicitudesEmpleado()
        {
            return View();
        }

        [Authorize]
        public IActionResult Ausentismo()
        {
            return View();
        }
        [Authorize]
        public IActionResult FormAusentismo()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetBancos()
        {

            if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

            var bancos = await gestionHumanaService.GetBancos(KeyConnection);

            return Json(new { result = true, data = bancos, message = "Success" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetDocumentCertificadoLaboralS()
        {
            string fileName = "";
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var NumeroCedula = userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                var certificado = await gestionHumanaService.GetCertificadoLaboralS(NumeroCedula,KeyConnection);

                var pdf = new ViewAsPdf("RptCertificadoLaboralS", certificado)
                {
                    FileName = $"Certificado_Laboral_Sueldo{NumeroCedula}.pdf",
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                };

                string fullpath = webHostEnvironment.WebRootPath + "/Temp/Trash/" + $"{pdf.FileName}";
                fileName = pdf.FileName;

                var byteArray = await pdf.BuildFile(ControllerContext);
                var fileStream = new FileStream(fullpath, FileMode.Create, FileAccess.Write);
                fileStream.Write(byteArray, 0, byteArray.Length);
                fileStream.Close();
            }
            catch
            {
                return Json(new { result = false, data = fileName, message = "Error generando certificado" });
            }

            return Json(new { result = true, data = fileName, message = "Success" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetDocumentCertificadoLaboralP()
        {
            string fileName = "";
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var NumeroCedula = userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                var certificado = await gestionHumanaService.GetCertificadoLaboralS(NumeroCedula, KeyConnection);

                var pdf = new ViewAsPdf("RptCertificadoLaboralSP", certificado)
                {
                    FileName = $"Certificado_Laboral_Sueldo_Promedio{NumeroCedula}.pdf",
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                };

                string fullpath = webHostEnvironment.WebRootPath + "/Temp/Trash/" + $"{pdf.FileName}";
                fileName = pdf.FileName;

                var byteArray = await pdf.BuildFile(ControllerContext);
                var fileStream = new FileStream(fullpath, FileMode.Create, FileAccess.Write);
                fileStream.Write(byteArray, 0, byteArray.Length);
                fileStream.Close();
            }
            catch
            {
                return Json(new { result = false, data = fileName, message = "Error generando certificado" });
            }

            return Json(new { result = true, data = fileName, message = "Success" });
        }

        [Authorize]
        [HttpGet]//INGRESOS Y RETENCIONES
        public async Task<IActionResult> GetDocumentCertificadoLaboral(string Periodo)
        {
            string fileName = "";

            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var user = await userManager.FindByNameAsync(User.Identity.Name);

                string rutaArchivo = webHostEnvironment.WebRootPath + "\\Net\\General Ledger.exe"; // Ruta del archivo .exe
                string[] argumentos = { $"GenIngresosReteEmp,{KeyConnection},{user.NroId},{Periodo},{user.NroId}" }; // Argumentos a pasar al archivo .exe

                string rutaArchivoResultante = webHostEnvironment.WebRootPath + "\\Net\\Temp\\IngresosRete_" + user.NroId + ".pdf";


                Funciones.ExecuteExe(rutaArchivo, argumentos);

                string fullpath = rutaArchivoResultante;
                fileName = "IngresosRete_" + user.NroId + ".pdf";

            }
            catch
            {
                return Json(new { result = false, data = fileName, message = "Error generando certificado" });
            }

            return Json(new { result = true, data = fileName, message = "Success" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetContratoLaboral()
        {
            string fileName = "";

            string template = webHostEnvironment.WebRootPath + "/Reports/CONTRATOSTD.docx";
            string outputPath = "";

            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var NumeroCedula = userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                var certificado = await gestionHumanaService.GetContratoLaboral(NumeroCedula, KeyConnection);
                fileName = "CERTIFICADOLABORAL_" + certificado.CedulaEmpleado;
                outputPath = webHostEnvironment.WebRootPath + "/Temp/Trash/" + fileName;

                using (DocX oDocX = DocX.Load(template))
                {
                    oDocX.ReplaceText("[<NitEmpresa>]", certificado.NitEmpresa.ToString());
                    oDocX.ReplaceText("[<NombreEmpresa>]", certificado.NombreEmpresa.ToString());
                    oDocX.ReplaceText("[<DireccionEmpresa>]", certificado.DireccionEmpresa.ToString());
                    oDocX.ReplaceText("[<NombreEmpleado>]", certificado.NombreEmpleado.ToString());
                    oDocX.ReplaceText("[<NombreEmpleado2>]", certificado.NombreEmpleado.ToString());
                    oDocX.ReplaceText("[<CedulaEmpleado>]", certificado.CedulaEmpleado.ToString());
                    oDocX.ReplaceText("[<DireccionEmpleado>]", certificado.DireccionEmpleado.ToString());
                    oDocX.ReplaceText("[<FechaNacimientoEmpleado>]", certificado.FechaNacimientoEmpleado.ToString());
                    oDocX.ReplaceText("[<ProfesionEmpleado>]", certificado.ProfesionEmpleado.ToString());
                    oDocX.ReplaceText("[<SueldoEmpleado>]", String.Format("{0:C}", certificado.SalarioBasico));
                    oDocX.ReplaceText("[<SalarioBasico>]", String.Format("{0:C}", certificado.SalarioBasico));
                    oDocX.ReplaceText("[<PeriodoPago>]", certificado.PeriodoPago.ToString());
                    oDocX.ReplaceText("[<FechaInicio>]", certificado.FechaInicio.ToString());
                    oDocX.ReplaceText("[<FechaInicio2>]", certificado.FechaInicio.ToString());
                    oDocX.ReplaceText("[<FechaFin>]", certificado.FechaFin.ToString());
                    oDocX.ReplaceText("[<FechaFin2>]", certificado.FechaFin.ToString());
                    oDocX.ReplaceText("[<CiudadContratacion>]", certificado.DepartamentoFirma.ToString());
                    oDocX.ReplaceText("[<DepartamentoContratacion>]", certificado.DepartamentoFirma.ToString());
                    oDocX.ReplaceText("[<TipoContrato>]", certificado.TipoContrato.ToString());
                    oDocX.ReplaceText("[<Cargo>]", certificado.Cargo.ToString());
                    oDocX.ReplaceText("[<Cargo2>]", certificado.Cargo.ToString());
                    oDocX.ReplaceText("[<CiudadFirma>]", certificado.CiudadFirma.ToString());
                    oDocX.ReplaceText("[<DepartamentoFirma>]", certificado.DepartamentoFirma.ToString());
                    oDocX.ReplaceText("[<FechaFirma>]", certificado.FechaFirma.ToString());
                    oDocX.ReplaceText("[<NombreEmpleadoFirma>]", certificado.NombreEmpleado.ToString());
                    oDocX.ReplaceText("[<CedulaEmpleadoFirma>]", certificado.CedulaEmpleado.ToString());
                    oDocX.ReplaceText("[<Telefono>]", certificado.Telefono.ToString());
                    oDocX.ReplaceText("[<TerminoContrato>]", certificado.FechaFin.ToString());
                    oDocX.ReplaceText("[<CiudadExp>]", certificado.CiudadFirma.ToString());
                    oDocX.ReplaceText("[<TipoDoc>]", certificado.TipoDoc.ToString());
                    oDocX.SaveAs(outputPath);
                }

                DocumentCore dc = DocumentCore.Load(outputPath + ".docx");
                dc.Save(outputPath + ".pdf");

                // Open the result for demonstration purposes.
                //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outputPath + ".pdf") { UseShellExecute = true });
            }
            catch
            {
                return Json(new { result = false, data = fileName + ".pdf", message = "Error generando certificado" });
            }

            return Json(new { result = true, data = fileName + ".pdf", message = "Success" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetExamenIngreso(string Empresa, string Direccion, string Ciudad)
        {
            string fileName = "";

            string template = webHostEnvironment.WebRootPath + "/Reports/EXAMENDEINGRESOSTD.docx";
            string outputPath = "";

            try
            {

                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var NumeroCedula = userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                var examenIngreso = await gestionHumanaService.GetExamenIngreso(NumeroCedula, KeyConnection);
                fileName = "EXAMENINGRESO_" + examenIngreso.Cedula;
                outputPath = webHostEnvironment.WebRootPath + "/Temp/Trash/" + fileName;

                using (DocX oDocX = DocX.Load(template))
                {
                    oDocX.ReplaceText("[<Codigo>]", examenIngreso.Codigo);
                    oDocX.ReplaceText("[<Version>]", examenIngreso.Version);
                    oDocX.ReplaceText("[<Fvig>]", examenIngreso.FechaVigencia);
                    oDocX.ReplaceText("[<FECHA>]", examenIngreso.Fecha);
                    oDocX.ReplaceText("[<NOMBRE_EMPRESA>]", Empresa);
                    oDocX.ReplaceText("[<DIRECCION_EMPRESA>]", Direccion);
                    oDocX.ReplaceText("[<CIUDAD_EMPRESA>]", Ciudad);
                    oDocX.ReplaceText("[<NOMEMPLEADO>]", examenIngreso.NombreEmpleado);
                    oDocX.ReplaceText("[<CEDEMPLEADO>]", examenIngreso.Cedula);
                    oDocX.ReplaceText("[<CARGO>]", examenIngreso.Cargo);
                    oDocX.ReplaceText("[<CCOSTO>]", examenIngreso.CentroCosto);
                    oDocX.ReplaceText("[<JEFERRHH>]", examenIngreso.JefeRRHH);
                    oDocX.ReplaceText("[<DIREMPRESA>]", examenIngreso.DireccionEmpresa);
                    oDocX.ReplaceText("[<TELEMPRESA>]", examenIngreso.TelefonoEmpresa);
                    oDocX.ReplaceText("[<EMAILEMPRESA>]", examenIngreso.EmailEmpresa);
                    oDocX.SaveAs(outputPath);
                }

                DocumentCore dc = DocumentCore.Load(outputPath + ".docx");
                dc.Save(outputPath + ".pdf");
            }
            catch
            {
                return Json(new { result = false, data = fileName + ".pdf", message = "Error generando certificado" });
            }

            return Json(new { result = true, data = fileName + ".pdf", message = "Success" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCartaBanco(string Banco)
        {
            string fileName = "";

            string template = webHostEnvironment.WebRootPath + "/Reports/CARTABANCOSTD.docx";
            string outputPath = "";

            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var NumeroCedula = userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                var examenIngreso = await gestionHumanaService.GetCartaBancos(NumeroCedula, Banco, KeyConnection);
                fileName = "CARTABANCO_" + examenIngreso.Cedula + "_" + Banco;
                outputPath = webHostEnvironment.WebRootPath + "/Temp/Trash/" + fileName;

                using (DocX oDocX = DocX.Load(template))
                {
                    oDocX.ReplaceText("[<Codigo>]", examenIngreso.Codigo);
                    oDocX.ReplaceText("[<Version>]", examenIngreso.Version);
                    oDocX.ReplaceText("[<Fvig>]", examenIngreso.FechaVigencia);
                    oDocX.ReplaceText("[<FECHA>]", examenIngreso.Fecha);
                    oDocX.ReplaceText("[<NOMEMPLEADO>]", examenIngreso.NombreEmpleado);
                    oDocX.ReplaceText("[<CEDEMPLEADO>]", examenIngreso.Cedula);
                    oDocX.ReplaceText("[<CARGO>]", examenIngreso.Cargo);
                    oDocX.ReplaceText("[<CCOSTO>]", examenIngreso.CentroCosto);
                    oDocX.ReplaceText("[<JEFERRHH>]", examenIngreso.JefeRRHH);
                    oDocX.ReplaceText("[<DIREMPRESA>]", examenIngreso.DireccionEmpresa);
                    oDocX.ReplaceText("[<TELEMPRESA>]", examenIngreso.TelefonoEmpresa);
                    oDocX.ReplaceText("[<EMAILEMPRESA>]", examenIngreso.EmailEmpresa);
                    oDocX.SaveAs(outputPath);
                }

                DocumentCore dc = DocumentCore.Load(outputPath + ".docx");
                dc.Save(outputPath + ".pdf");
            }
            catch
            {
                return Json(new { result = false, data = fileName + ".pdf", message = "Error generando certificado" });
            }

            return Json(new { result = true, data = fileName + ".pdf", message = "Success" });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetInfoEmpleado()
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var result = await profilerService.GetInstancia().ProGestionHumana.GetInfoEmpleadoNovedad(user.NroId, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetVacacionesEmpleado()
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var result = await profilerService.GetInstancia().ProGestionHumana.GetDatosVacacionesEmpleado(user.NroId, KeyConnection);
                result.DiasFestivos = profilerService.GetInstancia().ProGestionHumana.GetDiasFeriados(KeyConnection).Result.Select(x => x.Feriado).ToList();
                return Json(new { result = true, message = "Done", data = result ,feriados = result.DiasFestivos });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetDiasDisfrutados(string fechaInicio, string tipoNomina,int dias)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var result = await profilerService.GetInstancia().ProGestionHumana.GetDiasDisfrutados(fechaInicio,tipoNomina,dias, KeyConnection);
                return Json(new { result = true, message = "Solicitud", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveSolicitudNovedadEmpleado(NovedadEmpleadoDTO novedadEmpleado)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var user = await userManager.FindByNameAsync(User.Identity.Name);

                var empleado = await profilerService.GetInstancia().ProEmpleado.GetEmpleadoByNit(user.NroId, KeyConnection);

                if (string.IsNullOrEmpty(empleado.Empcod))
                {
                    return Json(new { result = false, message = "¡Usted no esta registrado como empleado en el sistema!", data = "null" });
                }

                novedadEmpleado.CodigoEmpleado = empleado.EmpCed;

                var result = await profilerService.GetInstancia().ProGestionHumana.SaveSolicitudNovedadEmpleado(novedadEmpleado, KeyConnection);

                var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("CERTI_EMPLEADO", KeyConnection);
                string body = "Estimado/a " + empleado.EmpNom + ". <br>"
                               + "Le informamos que usted ha enviado una  nueva solicitud con la siguiente información: <br><br>"
                               + "Fecha de Solictud: " + $"<b>{result.FechaNovedad.ToString("dd/MM/yyyy")}</b> <br>" 
                               + "Tipo de solicitud: " + $"<b>{result.NombreNovedad}</b> <br>"
                               + "Dato anterior: " + $"<b>{result.ValorAnterior}</b> <br>"
                               + "Dato Nuevo: " + $"<b>{result.ValorNuevo}</b> <br>"
                               + "Observaciones: " + $"<b>{result.DescripcionNovedad}</b>";

                List<string> destinatarios = new List<string>();
                emailconfig.Asunto = "Solictud de: " + result.NombreNovedad;
                emailconfig.Titulo = "Solictud de: " + result.NombreNovedad;

                if (!string.IsNullOrEmpty(empleado.EmpEmail))
                {
                    destinatarios.Add(empleado.EmpEmail);

                    mail.SendMail(body, destinatarios, emailconfig);
                }

                //ENVio CORREO A JEFE DE RECURSOS HUMANOS
                var jeferrhh = await profilerService.GetInstancia().ProGestionHumana.GetJefeRRHH(KeyConnection);
                var link = Url.Action("SolicitudesEmpleado", "GestionHumana", new { }, Request.Scheme);

                body = "Estimado/a jefe de RRHH " + jeferrhh.Nombre + ". <br>"
                               + $"Le informamos que el colaborador {empleado.EmpNom} ha enviado una nueva solicitud con la siguiente información: <br><br>"
                               + "Fecha de Solictud: " + $"<b>{result.FechaNovedad.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Tipo de solicitud: " + $"<b>{result.NombreNovedad}</b> <br>"
                               + "Dato anterior: " + $"<b>{result.ValorAnterior}</b> <br>"
                               + "Dato Nuevo: " + $"<b>{result.ValorNuevo}</b> <br>"
                               + "Observaciones: " + $"<b>{result.DescripcionNovedad}</b> <br><br>" +
                               $" Siga el siguiente enlace para ver la solicitud: <a href='{link}'> Ver Solicitud </a>" ;

                destinatarios = new List<string>();

                if (!string.IsNullOrEmpty(jeferrhh.Email))
                {
                    destinatarios.Add(jeferrhh.Email);

                    mail.SendMail(body, destinatarios, emailconfig);
                }


                return Json(new { result = true, message = "¡Solicitud enviada con éxito!", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveSolicitudPermisoEmpleado(PermisoEmpleadoDTO permisoEmpleado)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var empleado = await profilerService.GetInstancia().ProEmpleado.GetEmpleadoByNit(user.NroId,KeyConnection);

                if (string.IsNullOrEmpty(empleado.Empcod))
                {
                    return Json(new { result = false, message = "¡Usted no esta registrado como empleado en el sistema!", data = "null" });
                }

                permisoEmpleado.CodigoEmpleado = empleado.Empcod;

                var result = await profilerService.GetInstancia().ProGestionHumana.SaveSolicitudPermisoEmpleado(permisoEmpleado, KeyConnection);

                var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("CERTI_EMPLEADO", KeyConnection);
                string body = "Estimado/a " + empleado.EmpNom + ". <br>"
                               + "Le informamos que usted ha enviado una  nueva solicitud con la siguiente información: <br><br>"
                               + "Fecha de Solictud: " + $"<b>{result.FechaNovedad.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Tipo de solicitud: " + $"<b>{result.NombreNovedad}</b> <br>"
                               + "Fecha y Hora de Salida: " + $"<b>{permisoEmpleado.FechaInicial} {permisoEmpleado.HoraInicial}</b> <br>"
                               + "Fecha y Hora de Regreso : " + $"<b>{permisoEmpleado.FechaFinal} {permisoEmpleado.HoraFinal}</b> <br>"
                               + "Regresa : " + $"<b>{((permisoEmpleado.Reingresa)? "SI":"NO")}</b> <br>"
                               + "Observaciones: " + $"<b>{result.DescripcionNovedad}</b>";

                List<string> destinatarios = new List<string>();
                emailconfig.Asunto = "Solictud de: " + result.NombreNovedad;
                emailconfig.Titulo = "Solictud de: " + result.NombreNovedad;

                if (!string.IsNullOrEmpty(empleado.EmpEmail))
                {
                    destinatarios.Add(empleado.EmpEmail);

                    mail.SendMail(body, destinatarios, emailconfig);
                }

                //ENVio CORREO A JEFE DE RECURSOS HUMANOS
                var jeferrhh = await profilerService.GetInstancia().ProGestionHumana.GetJefeRRHH(KeyConnection);
                var link = Url.Action("SolicitudesEmpleado", "GestionHumana", new { }, Request.Scheme);

                body = "Estimado/a jefe de RRHH " + jeferrhh.Nombre + ". <br>"
                               + $"Le informamos que el colaborador {empleado.EmpNom} ha enviado una nueva solicitud con la siguiente información: <br><br>"
                               + "Fecha de Solictud: " + $"<b>{result.FechaNovedad.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Tipo de solicitud: " + $"<b>{result.NombreNovedad}</b> <br>"
                               + "Fecha y Hora de Salida: " + $"<b>{permisoEmpleado.FechaInicial} {permisoEmpleado.HoraInicial}</b> <br>"
                               + "Fecha y Hora de Regreso : " + $"<b>{permisoEmpleado.FechaFinal} {permisoEmpleado.HoraFinal}</b> <br>"
                               + "Regresa : " + $"<b>{((permisoEmpleado.Reingresa) ? "SI" : "NO")}</b> <br>"
                               + "Observaciones: " + $"<b>{result.DescripcionNovedad}</b>"
                               + $" Siga el siguiente enlace para ver la solicitud: <a href='{link}'> Ver Solicitud </a>";

                destinatarios = new List<string>();

                if (!string.IsNullOrEmpty(jeferrhh.Email))
                {
                    destinatarios.Add(jeferrhh.Email);

                    try
                    {
                        mail.SendMail(body, destinatarios, emailconfig);
                    }
                    catch(Exception ex)
                    {

                    }
                }


                return Json(new { result = true, message = "¡Solicitud enviada con éxito!", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveSolicitudAusentismoEmpleado(AusentismoEmpleadoDTO ausentismoEmpleado)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var user = await userManager.FindByNameAsync(User.Identity.Name);

                var empleado = await profilerService.GetInstancia().ProEmpleado.GetEmpleadoByNit(user.NroId, KeyConnection);

                if (string.IsNullOrEmpty(empleado.Empcod))
                {
                    return Json(new { result = false, message = "¡Usted no está registrado como empleado en el sistema!", data = "null" });
                }

                ausentismoEmpleado.CodigoEmpleado = empleado.EmpCed;

                var result = await profilerService.GetInstancia().ProGestionHumana.SaveSolicitudAusentismoEmpleado(ausentismoEmpleado, KeyConnection);

                var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("CERTI_EMPLEADO", KeyConnection);
                string body = "Estimado/a " + empleado.EmpNom + ". <br>"
                                + "Le informamos que usted ha enviado una nueva solicitud de ausentismo con la siguiente información: <br><br>"
                                + "Fecha de Solicitud: " + $"<b>{result.FechaNovedad.ToString("dd/MM/yyyy")}</b> <br>"
                                + "Tipo de ausentismo: " + $"<b>{result.NombreNovedad}</b> <br>"
                                + "Fecha de inicio: " + $"<b>{ausentismoEmpleado.FechaInicioAusentismo.ToString("dd/MM/yyyy")}</b> <br>"
                                + "Fecha de fin: " + $"<b>{ausentismoEmpleado.FechaFinAusentismo.ToString("dd/MM/yyyy")}</b> <br>"
                                + "Detalle: " + $"<b>{ausentismoEmpleado.DetalleAusentismo}</b>";

                List<string> destinatarios = new List<string>();
                emailconfig.Asunto = "Solicitud de Ausentismo: " + result.NombreNovedad;
                emailconfig.Titulo = "Solicitud de Ausentismo: " + result.NombreNovedad;

                if (!string.IsNullOrEmpty(empleado.EmpEmail))
                {
                    destinatarios.Add(empleado.EmpEmail);

                    mail.SendMail(body, destinatarios, emailconfig);
                }

                var jeferrhh = await profilerService.GetInstancia().ProGestionHumana.GetJefeRRHH(KeyConnection);
                var link = Url.Action("SolicitudesEmpleado", "GestionHumana", new { }, Request.Scheme);

                body = "Estimado/a jefe de RRHH " + jeferrhh.Nombre + ". <br>"
                                + $"Le informamos que el colaborador {empleado.EmpNom} ha enviado una nueva solicitud de ausentismo con la siguiente información: <br><br>"
                                + "Fecha de Solicitud: " + $"<b>{result.FechaNovedad.ToString("dd/MM/yyyy")}</b> <br>"
                                + "Tipo de ausentismo: " + $"<b>{result.NombreNovedad}</b> <br>"
                                + "Fecha de inicio: " + $"<b>{ausentismoEmpleado.FechaInicioAusentismo.ToString("dd/MM/yyyy")}</b> <br>"
                                + "Fecha de fin: " + $"<b>{ausentismoEmpleado.FechaFinAusentismo.ToString("dd/MM/yyyy")}</b> <br>"
                                + "Detalle: " + $"<b>{ausentismoEmpleado.DetalleAusentismo}</b> <br><br>"
                                + $"Siga el siguiente enlace para ver la solicitud: <a href='{link}'> Ver Solicitud </a>";

                destinatarios = new List<string>();

                if (!string.IsNullOrEmpty(jeferrhh.Email))
                {
                    destinatarios.Add(jeferrhh.Email);

                    mail.SendMail(body, destinatarios, emailconfig);
                }

                return Json(new { result = true, message = "¡Solicitud de ausentismo enviada con éxito!", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSolicitudNovedadEmpleado(string idNovedad)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProGestionHumana.GetSolicitudNovedadEmpleado(idNovedad, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSolicitudPermisoEmpleado(string idNovedad)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProGestionHumana.GetSolicitudPermiso(idNovedad, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSolicitudesNovedadEmpleado()
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var result = await profilerService.GetInstancia().ProGestionHumana.GetSolicitudesNovedadByEmpleado(user.NroId, KeyConnection);

                var solicitudes = new
                {
                    Pendientes = result.Where(x => x.EstadoSolicitudNovedad == 0),
                    Aprobadas = result.Where(x => x.EstadoSolicitudNovedad == 1),
                    Rechazadas = result.Where(x => x.EstadoSolicitudNovedad == 2),
                };

                return Json(new { result = true, message = "Done", data = solicitudes });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSolicitudesNovedad()
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProGestionHumana.GetSolicitudesNovedadByEmpleado("", KeyConnection);

                var solicitudes = new
                {
                    Pendientes = result.Where(x => x.EstadoSolicitudNovedad == 0),
                    Aprobadas = result.Where(x => x.EstadoSolicitudNovedad == 1),
                    Rechazadas = result.Where(x => x.EstadoSolicitudNovedad == 2),
                };

                return Json(new { result = true, message = "Done", data = solicitudes });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAusentismos()
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProGestionHumana.GetAusentismos(KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveApproveReject(string solicitud, string valor, string razones, bool remunerado)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProGestionHumana.SaveApproveReject(solicitud, valor, razones, remunerado, KeyConnection);

                return Json(new { result = true, message = "La solicitud ha sido: " + (valor.Equals("1")?"aprobada":"rechazada"), data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetDocumentComprobantePago(string FechaI, string FechaF)
        {
            string fileName = "";

            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                TempData["FechaI"] = FechaI.Split('-')[2] + "/" + FechaI.Split('-')[1] + "/" + FechaI.Split('-')[0];
                TempData["FechaF"] = FechaF.Split('-')[2] + "/" + FechaF.Split('-')[1] + "/" + FechaF.Split('-')[0];

                FechaI = FechaI.Split('-')[0] + FechaI.Split('-')[1] + FechaI.Split('-')[2];
                FechaF = FechaF.Split('-')[0] + FechaF.Split('-')[1] + FechaF.Split('-')[2];

                var NumeroCedula = userManager.FindByNameAsync(User.Identity.Name).Result.NroId;
                var empleado = await profilerService.GetInstancia().ProEmpleado.GetEmpleadoByNit(NumeroCedula,KeyConnection);

                if (empleado.Empcod == null)
                {
                    return Json(new { result = false, data = fileName, message = "El usuario no se encuentro registrado como empleado" });
                }

                var certificado = await gestionHumanaService.GetComprobantePago(empleado.Empcod, FechaI, FechaF, KeyConnection);

                if (certificado.Count() <= 0)
                {
                    return Json(new { result = false, data = fileName, message = "No se encuentran reportes de pago en el periodo seleccionado" });
                }

                var pdf = new ViewAsPdf("Reports/RptComprobantePago", certificado)
                {
                    FileName = $"Comprobante_Pago_{NumeroCedula}.pdf",
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                };

                string fullpath = webHostEnvironment.WebRootPath + "\\Temp\\Trash\\" + $"{pdf.FileName}";
                fileName = pdf.FileName;

                var byteArray = await pdf.BuildFile(ControllerContext);
                var fileStream = new FileStream(fullpath, FileMode.Create, FileAccess.Write);
                fileStream.Write(byteArray, 0, byteArray.Length);
                fileStream.Close();
            }
            catch
            {
                return Json(new { result = false, data = fileName, message = "Error generando certificado" });
            }

            return Json(new { result = true, data = fileName, message = "Success" });
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveSolicitudVacacionesEmpleado(VacacionesEmpleadoDTO solicitudVacaciones)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var empleado = await profilerService.GetInstancia().ProEmpleado.GetEmpleadoByNit(user.NroId, KeyConnection);

                if (string.IsNullOrEmpty(empleado.Empcod))
                {
                    return Json(new { result = false, message = "¡Usted no esta registrado como empleado en el sistema!", data = "null" });
                }

                solicitudVacaciones.CodigoEmpleado = empleado.Empcod;

                var result = await profilerService.GetInstancia().ProGestionHumana.SaveSolicitudVacacionesEmpleado(solicitudVacaciones, KeyConnection);


                var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("CERTI_EMPLEADO", KeyConnection);
                string body = "Estimado/a " + empleado.EmpNom + ". <br>"
                               + "Le informamos que usted ha enviado una  nueva solicitud de vacaciones con la siguiente información: <br><br>"
                               + "Fecha de Solictud: " + $"<b>{result.FechaNovedad.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Tipo de solicitud: " + $"<b>{result.NombreNovedad}</b> <br>"
                               + "Periodo de Vacaciones: " + $"<b>{result.FechaPeriodoI.ToString("dd/MM/yyyy")} - {result.FechaPeriodoF.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Fecha de Inicio de Vacaciones: " + $"<b>{result.FechaVacacionesI.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Fecha de Reintegro: " + $"<b>{result.FechaVacacionesF.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Días: " + $"<b>{result.DiasHabiles}</b> <br>"
                               + "Días Disfrutados: " + $"<b>{result.DiasDisfrute}</b> <br>"
                               + "Días Compensados: " + $"<b>{result.DiasCompensados}</b> <br>"
                               + "Total Días: " + $"<b>{result.TotalDias}</b> <br>"
                               + "Observaciones: " + $"<b>{result.DescripcionNovedad}</b>";

                List<string> destinatarios = new List<string>();
                emailconfig.Asunto = "Solictud de: " + result.NombreNovedad;
                emailconfig.Titulo = "Solictud de: " + result.NombreNovedad;

                if (!string.IsNullOrEmpty(empleado.EmpEmail))
                {
                    destinatarios.Add(empleado.EmpEmail);

                    mail.SendMail(body, destinatarios, emailconfig);
                }

                //ENVio CORREO A JEFE DE RECURSOS HUMANOS
                var jeferrhh = await profilerService.GetInstancia().ProGestionHumana.GetJefeRRHH(KeyConnection);
                var link = Url.Action("SolicitudesEmpleado", "GestionHumana", new { }, Request.Scheme);

                body = "Estimado/a jefe de RRHH " + jeferrhh.Nombre + ". <br>"
                               + "Le informamos que usted ha enviado una  nueva solicitud de vacaciones con la siguiente información: <br><br>"
                               + "Fecha de Solictud: " + $"<b>{result.FechaNovedad.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Tipo de solicitud: " + $"<b>{result.NombreNovedad}</b> <br>"
                               + "Periodo de Vacaciones: " + $"<b>{result.FechaPeriodoI.ToString("dd/MM/yyyy")} - {result.FechaPeriodoF.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Fecha de Inicio de Vacaciones: " + $"<b>{result.FechaVacacionesI.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Fecha de Reintegro: " + $"<b>{result.FechaVacacionesF.ToString("dd/MM/yyyy")}</b> <br>"
                               + "Días: " + $"<b>{result.DiasHabiles}</b> <br>"
                               + "Días Disfrutados: " + $"<b>{result.DiasDisfrute}</b> <br>"
                               + "Días Compensados: " + $"<b>{result.DiasCompensados}</b> <br>"
                               + "Total Días: " + $"<b>{result.TotalDias}</b> <br>"
                               + "Observaciones: " + $"<b>{result.DescripcionNovedad}</b>" +
                                $" Siga el siguiente enlace para ver la solicitud: <a href='{link}'> Ver Solicitud </a>";

                destinatarios = new List<string>();

                if (!string.IsNullOrEmpty(jeferrhh.Email))
                {
                    destinatarios.Add(jeferrhh.Email);

                    mail.SendMail(body, destinatarios, emailconfig);
                }

                return Json(new { result = true, message = "¡Solicitud enviada con éxito!", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetDocumentHistorialLaboral()
        {
            string fileName = "";

            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var NumeroCedula = userManager.FindByNameAsync(User.Identity.Name).Result.NroId;

                var empleado = await profilerService.GetInstancia().ProEmpleado.GetEmpleadoByNit(NumeroCedula, KeyConnection);

                if (empleado.Empcod == null)
                {
                    return Json(new { result = false, data = fileName, message = "El usuario no se encuentro registrado como empleado" });
                }

                var certificado = await gestionHumanaService.GetHistorialLaboral(NumeroCedula, KeyConnection);

                var pdf = new ViewAsPdf("Reports/RptHistorialLaboral", certificado)
                {
                    FileName = $"Historial_Laboral_{NumeroCedula}.pdf",
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                };

                string fullpath = webHostEnvironment.WebRootPath + "/Temp/Trash/" + $"{pdf.FileName}";
                fileName = pdf.FileName;

                var byteArray = await pdf.BuildFile(ControllerContext);
                var fileStream = new FileStream(fullpath, FileMode.Create, FileAccess.Write);
                fileStream.Write(byteArray, 0, byteArray.Length);
                fileStream.Close();
            }
            catch
            {
                return Json(new { result = false, data = fileName, message = "Error generando certificado" });
            }

            return Json(new { result = true, data = fileName, message = "Success" });
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SendMyEmail(string FileSend)
        {
            string fileName = "";

            if (string.IsNullOrEmpty(FileSend))
            {
                return Json(new { result = false, data = fileName, message = "No hay archivos que enviar" });
            }

            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var Email = userManager.FindByNameAsync(User.Identity.Name).Result.EmailUser;
                var nomEmpleado = userManager.FindByNameAsync(User.Identity.Name).Result.Nombre;

                if(string.IsNullOrEmpty(Email))
                {
                    return Json(new { result = false, data = fileName, message = "Error enviando certificado: No tiene un correo electrónico configurado" });
                }

                var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("CERTI_EMPLEADO", KeyConnection);

                emailconfig.Titulo = emailconfig.Titulo.Replace("<<NOMCERTIFICADO>>", FileSend);
                emailconfig.Asunto = emailconfig.Asunto.Replace("<<NOMCERTIFICADO>>", FileSend);
                emailconfig.Cuerpo = emailconfig.Cuerpo.Replace("<<Empleado>>", nomEmpleado).Replace("<<NOMCERTIFICADO>>", FileSend);

                var destinatarios = Email.Split(',').ToList();

                List<Attachment> files = new List<Attachment>();

                string filepath = webHostEnvironment.WebRootPath + ((FileSend.Contains("IngresosRete"))?  "\\Net\\Temp\\" :  "\\Temp\\Trash\\" ) + FileSend;

                byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
                string contentFile =  Convert.ToBase64String(fileBytes);

                files.Add(new Attachment { content = contentFile, filename = filepath });

                mail.SendMail(emailconfig.Cuerpo, destinatarios, emailconfig,files);
            }
            catch
            {
                return Json(new { result = false, data = fileName, message = "Error generando certificado" });
            }

            return Json(new { result = true, data = fileName, message = "El certificado ha sido enviado con éxito" });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SendOtherEmail(string FileSend,string Email)
        {
            string fileName = "";

            if (string.IsNullOrEmpty(FileSend))
            {
                return Json(new { result = false, data = fileName, message = "No hay archivos que enviar" });
            }

            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var nomEmpleado = userManager.FindByNameAsync(User.Identity.Name).Result.Nombre;

                if (string.IsNullOrEmpty(Email))
                {
                    return Json(new { result = false, data = fileName, message = "Error enviando certificado: No tiene un correo electrónico configurado" });
                }

                var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("CERTI_EMPLEADO", KeyConnection);

                emailconfig.Titulo = emailconfig.Titulo.Replace("<<NOMCERTIFICADO>>", FileSend);
                emailconfig.Asunto = emailconfig.Asunto.Replace("<<NOMCERTIFICADO>>", FileSend);
                emailconfig.Cuerpo = emailconfig.Cuerpo.Replace("<<Empleado>>", nomEmpleado).Replace("<<NOMCERTIFICADO>>", FileSend);

                var destinatarios = Email.Split(',').ToList();

                List<Attachment> files = new List<Attachment>();

                string filepath = webHostEnvironment.WebRootPath + ((FileSend.Contains("IngresosRete")) ? "\\Net\\Temp\\" : "\\Temp\\Trash\\") + FileSend;

                byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
                string contentFile = Convert.ToBase64String(fileBytes);

                files.Add(new Attachment { content = contentFile, filename = filepath });

                mail.SendMail(emailconfig.Cuerpo, destinatarios, emailconfig, files);
            }
            catch
            {
                return Json(new { result = false, data = fileName, message = "Error generando certificado" });
            }

            return Json(new { result = true, data = fileName, message = "El certificado ha sido enviado con éxito" });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DownLoadFile(string FileSend)
        {
            string fileName = "";

            if (string.IsNullOrEmpty(FileSend))
            {
                return Json(new { result = false, data = fileName, message = "No hay archivos que descargar" });
            }

            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

               
                string filepath = webHostEnvironment.WebRootPath + ((FileSend.Contains("IngresosRete")) ? "\\Net\\Temp\\" : "\\Temp\\Trash\\") + FileSend;

                byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);

                var result = new FileContentResult(fileBytes, "application/pdf")
                {
                    FileDownloadName = FileSend
                };

                return result;

            }
            catch
            {
                return Json(new { result = false, data = fileName, message = "Error descargando certificado" });
            }

            return Json(new { result = true, data = fileName, message = "Descargando certificado..." });
        }

        /**LOGICA PARA MANEJAR EL TEMA DE GESTIOn HUMANA**/

        private void SetKeyConnection()
        {
            KeyConnection =  userManager.FindByNameAsync(User.Identity.Name).Result.KeyConnection;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetAllEmpleadosDisponibles()
        {
            try
            {
                // Verifica si la conexión está establecida
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                // Obtiene todos los empleados disponibles
                var empleados = await profilerService.GetInstancia().ProEmpleado.GetAllEmpleados(KeyConnection);

                // Verifica si se encontraron empleados
                if (empleados != null && empleados.Any())
                {
                    // Devuelve los empleados en formato JSON
                    return Json(new { result = true, empleados = empleados });
                }
                else
                {
                    // Si no se encontraron empleados, devuelve un mensaje de error
                    return Json(new { result = false, message = "No se encontraron empleados disponibles" });
                }
            }
            catch (Exception ex)
            {
                // Registra el error para depuración
                _logger.LogError(ex, "Error al obtener todos los empleados disponibles");

                // Devuelve un resultado JSON indicando que ocurrió un error durante el proceso
                return Json(new { result = false, message = "Ocurrió un error al obtener los empleados disponibles. Por favor, inténtelo de nuevo más tarde." });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetAllTiposAusentismo()
        {
            try
            {
                // Verifica si la conexión está establecida
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                // Obtiene todos los tipos de ausentismo disponibles
                var tiposAusentismo = await profilerService.GetInstancia().ProGestionHumana.GetAllTiposAusentismo(KeyConnection);

                // Verifica si se encontraron tipos de ausentismo
                if (tiposAusentismo != null && tiposAusentismo.Any())
                {
                    // Devuelve los tipos de ausentismo en formato JSON
                    return Json(new { result = true, tiposAusentismo = tiposAusentismo });
                }
                else
                {
                    // Si no se encontraron tipos de ausentismo, devuelve un mensaje de error
                    return Json(new { result = false, message = "No se encontraron tipos de ausentismo disponibles" });
                }
            }
            catch (Exception ex)
            {
                // Registra el error para depuración
                _logger.LogError(ex, "Error al obtener todos los tipos de ausentismo disponibles");

                // Devuelve un resultado JSON indicando que ocurrió un error durante el proceso
                return Json(new { result = false, message = "Ocurrió un error al obtener los tipos de ausentismo disponibles. Por favor, inténtelo de nuevo más tarde." });
            }
        }

    }
}