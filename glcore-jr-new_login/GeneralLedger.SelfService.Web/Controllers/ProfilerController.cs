using AutoMapper;
using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    public class ProfilerController : Controller
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        #endregion UserManager

        #region Services

        private readonly IProfilerService profilerService;
        #endregion Services



        #region Others

        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;
        private string KeyConnection;

        #endregion Others

        #region Constructor

        public ProfilerController
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IProfilerService profilerService,
            IMapper mapper,
            IHttpContextAccessor contextAccessor
        )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;

            this.profilerService = profilerService;

            this.mapper = mapper;
            this.contextAccessor = contextAccessor;

            ConnectionTools.SetKeyConnectionStringDirect(SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection"));
            KeyConnection = SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection");
        }

        #endregion Constructor

        // GET: ProfilerController
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> GetEtiquetas(string search)
        {
            if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

            var result = await profilerService.GetInstancia().ProEtiquetas.GetEtiquetas(search, KeyConnection);

            return Json(result);
        }

        [Authorize]
        public async Task<JsonResult> SaveEtiqueta(string etiqueta)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProEtiquetas.SaveEtiqueta(etiqueta, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<JsonResult> EditEtiqueta(string etiqueta, string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProEtiquetas.EditEtiqueta(etiqueta, codigo, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<JsonResult> DeleteEtiqueta(string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProEtiquetas.DeleteEtiqueta(codigo, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<IActionResult> GetPreguntas(string search)
        {
            if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

            var result = await profilerService.GetInstancia().ProPreguntas.GetPreguntas(search, KeyConnection);

            return Json(result);
        }

        [Authorize]
        public async Task<JsonResult> SavePregunta(string pregunta)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProPreguntas.SavePregunta(pregunta, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<JsonResult> EditPregunta(string pregunta, int codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProPreguntas.EditPregunta(pregunta, codigo, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<JsonResult> DeletePregunta(int codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProPreguntas.DeletePregunta(codigo, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<IActionResult> GetAreas(string search)
        {
            if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

            var result = await profilerService.GetInstancia().ProAreas.GetAreas(search, KeyConnection);

            return Json(result);
        }

        [Authorize]
        public async Task<JsonResult> SaveArea(string area)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProAreas.SaveArea(area, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<JsonResult> EditArea(string area, string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProAreas.EditArea(area, codigo, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<JsonResult> DeleteArea(string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProAreas.DeleteArea(codigo, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<IActionResult> GetAgentes(string search)
        {
            if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

            var result = await profilerService.GetInstancia().ProAgentes.GetAgentes(search, KeyConnection);

            return Json(result);
        }

        [Authorize]
        public async Task<JsonResult> EnabledEmail(string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProAgentes.EnabledEmail(codigo, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<JsonResult> DeleteAgente(string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                await profilerService.GetInstancia().ProAgentes.DeleteAgente(codigo, KeyConnection);
                return Json(new { result = true, msg = "Done", data = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<JsonResult> GetUsuarioAgente(string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProAgentes.GetUsuarioAgente(codigo, KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        [Authorize]
        public async Task<JsonResult> SaveAgente(Agente agente)
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                agente.RecibeEmail = false;
                var result = await profilerService.GetInstancia().ProAgentes.SaveUsuarioAgente(agente, KeyConnection);
                var user = await _userManager.FindByNameAsync(agente.Email);
                await _userManager.AddToRoleAsync(user, "AGENTE");

                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }

        private async Task<IEnumerable<ProPermisosUsuarios>> GetPermisosUser()
        {
            if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var permiso = await profilerService.GetInstancia().ProConfiguracion.GetPermisosUsuario(user.Id, KeyConnection);

            return permiso;
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetTipoPermisos()
        {
            try
            {
                if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

                var result = await profilerService.GetInstancia().ProProfilerGeneric.GetTipoPermisos(KeyConnection);
                return Json(new { result = true, msg = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex.Message, data = "null" });
            }
        }


        private void SetKeyConnection()
        {
            KeyConnection = _userManager.FindByNameAsync(User.Identity.Name).Result.KeyConnection;
        }
    }
}