using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class EmpleadosModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IMenuService menuService;
        private readonly IConfiguracionService configuracionService;
        private readonly IProfilerService profilerService;
        private readonly IMemoryCache memoryCache;
        private readonly IMail mail;

        private readonly ILogger<LoginModel> logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmpleadosModel
        (
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ILogger<LoginModel> logger,
            RoleManager<IdentityRole> roleManager,
            IMenuService menuService,
            IConfiguracionService configuracionService,
            IProfilerService profilerService,
            IMemoryCache memoryCache,
            IMail mail,
            IHttpContextAccessor httpContextAccessor
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.logger = logger;

            this.menuService = menuService;
            this.configuracionService = configuracionService;
            this.profilerService = profilerService;
            this.memoryCache = memoryCache;
            this.mail = mail;
            this._httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Número de Cédula es  Requerido.")]
            public string NumeroCedula { get; set; }

            [Required(ErrorMessage = "La Fecha de Nacimiento es Requerida.")]
            [DataType(DataType.DateTime)]
            public DateTime FechaNacimento { get; set; }

            [Required(ErrorMessage = "Pregunta de Seguridad Requerida")]
            public string TipoPreguntaSeguridad { get; set; }

            [Required(ErrorMessage = "Pregunta de Seguridad Requerida")]
            public string PreguntaSeguridad { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            [DataType(DataType.Password)]
            public string KeyConnect { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            [DataType(DataType.Password)]
            public string Salt { get; set; }

        }

        public async Task<IActionResult> OnGetAsync(string urlcompany, string returnUrl = null)
        {

            if (string.IsNullOrEmpty(urlcompany))
            {
                return RedirectToPage("./NotFound");
            }

            if (User.Identity.IsAuthenticated)
            {
                await signInManager.SignOutAsync();
                return RedirectToPage("./Empleados", new { urlcompany = urlcompany });
            }
            

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            var dataEmpresa = await profilerService.GetInstancia().ProEmpresa.GetDataEmpresa(urlcompany, "GLSELFSERVICE_USERAPP");


            ViewData["Logo"] = dataEmpresa.Logo;
            ViewData["Web"] = dataEmpresa.UrlWeb;
            ViewData["Nit"] = dataEmpresa.Nit;
            ViewData["Salt"] = dataEmpresa.Salt;
            ViewData["Email"] = "";
            ViewData["KeyConnect"] = dataEmpresa.KeyConnection;

            Random random = new Random();
            int tipo = random.Next(1, 5);

            var selectList = new List<SelectListItem>();
            ViewData["TipoPreguntaSeguridad"] = tipo.ToString();

            if (tipo ==  1)//EPS
            {
                var eps = await profilerService.GetInstancia().ProGestionHumana.GetEps("", dataEmpresa.KeyConnection);

                foreach (var item in eps)
                {
                    selectList.Add(new SelectListItem { Value = item.Epscod, Text = item.Epsnom});
                }

                ViewData["Security"] = new SelectList(selectList, "Value", "Text");
                
            }

            if (tipo == 2)//CESANTIAS
            {
                var cesantia = await profilerService.GetInstancia().ProGestionHumana.GetFondosCesantias("", dataEmpresa.KeyConnection);

                foreach (var item in cesantia)
                {
                    selectList.Add(new SelectListItem { Value = item.Cescod, Text = item.Cesnom });
                }

                ViewData["Security"] = new SelectList(selectList, "Value", "Text");
            }

            if (tipo == 3)//PENSION
            {
                var pension = await profilerService.GetInstancia().ProGestionHumana.GetFondosPension("", dataEmpresa.KeyConnection);

                foreach (var item in pension)
                {
                    selectList.Add(new SelectListItem { Value = item.Pencod, Text = item.Pennom });
                }

                ViewData["Security"] = new SelectList(selectList, "Value", "Text");
            }

            if (tipo == 4)//CAJA
            {
                var caja = await profilerService.GetInstancia().ProGestionHumana.GetCajasCompensacion("", dataEmpresa.KeyConnection);

                foreach (var item in caja)
                {
                    selectList.Add(new SelectListItem { Value = item.Arpcod, Text = item.Arpnom });
                }

                ViewData["Security"] = new SelectList(selectList, "Value", "Text");
            }


            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {

                if (string.IsNullOrEmpty(Input.Salt))
                {
                    return RedirectToPage("./NotFound");
                }

                var dataEmpresa = await profilerService.GetInstancia().ProEmpresa.GetDataEmpresa(Input.Salt, "GLSELFSERVICE_USERAPP");

                if (dataEmpresa == null)
                {
                    return RedirectToPage("./NotFound");
                }

                /**NUEVA LOGICA**/

                var empleado = await ValidateDataEmpleado(Input.NumeroCedula, Input.FechaNacimento, Input.TipoPreguntaSeguridad, Input.PreguntaSeguridad, Input.KeyConnect);

                if (string.IsNullOrEmpty(empleado.CodigoEmpleado))
                {
                    ViewData["ErrorMessage"] = "Los datos proporcionados no son válidos.";
                    ModelState.AddModelError(String.Empty, "Los datos proporcionados no son válidos.");
                    ErrorMessage = "Los datos proporcionados no son válidos.";

                    return RedirectToPage("./Empleados", new { urlcompany = Input.Salt });
                }


                if (Input.TipoPreguntaSeguridad.Equals("1"))
                {
                    if (!(Input.PreguntaSeguridad.Equals(empleado.EpsEmpleado) && 
                        Input.FechaNacimento.ToString("yyyyMMdd").Equals(empleado.FechaNacimiento.ToString("yyyyMMdd")) &&
                        Input.NumeroCedula.Equals(empleado.CedulaEmpleado)))
                    {
                        ViewData["ErrorMessage"] = "Los datos proporcionados no son válidos.";
                        ModelState.AddModelError(String.Empty, "Los datos proporcionados no son válidos.");
                        ErrorMessage = "Los datos proporcionados no son válidos.";

                        return RedirectToPage("./Empleados", new { urlcompany = Input.Salt });
                    }
                }

                if (Input.TipoPreguntaSeguridad.Equals("2"))
                {
                    if (!(Input.PreguntaSeguridad.Equals(empleado.CesantiaEmpleado) &&
                        Input.FechaNacimento.ToString("yyyyMMdd").Equals(empleado.FechaNacimiento.ToString("yyyyMMdd")) &&
                        Input.NumeroCedula.Equals(empleado.CedulaEmpleado)))
                    {
                        ViewData["ErrorMessage"] = "Los datos proporcionados no son válidos.";
                        ModelState.AddModelError(String.Empty, "Los datos proporcionados no son válidos.");
                        ErrorMessage = "Los datos proporcionados no son válidos.";

                        return RedirectToPage("./Empleados", new { urlcompany = Input.Salt });
                    }
                }

                if (Input.TipoPreguntaSeguridad.Equals("3"))
                {
                    if (!(Input.PreguntaSeguridad.Equals(empleado.PensionEmpleado) &&
                        Input.FechaNacimento.ToString("yyyyMMdd").Equals(empleado.FechaNacimiento.ToString("yyyyMMdd")) &&
                        Input.NumeroCedula.Equals(empleado.CedulaEmpleado)))
                    {
                        ViewData["ErrorMessage"] = "Los datos proporcionados no son válidos.";
                        ModelState.AddModelError(String.Empty, "Los datos proporcionados no son válidos.");
                        ErrorMessage = "Los datos proporcionados no son válidos.";

                        return RedirectToPage("./Empleados", new { urlcompany = Input.Salt });
                    }
                }

                if (Input.TipoPreguntaSeguridad.Equals("4"))
                {
                    if (!(Input.PreguntaSeguridad.Equals(empleado.CajaCompensacion) &&
                        Input.FechaNacimento.ToString("yyyyMMdd").Equals(empleado.FechaNacimiento.ToString("yyyyMMdd")) &&
                        Input.NumeroCedula.Equals(empleado.CedulaEmpleado)))
                    {
                        ViewData["ErrorMessage"] = "Los datos proporcionados no son válidos.";
                        ModelState.AddModelError(String.Empty, "Los datos proporcionados no son válidos.");
                        ErrorMessage = "Los datos proporcionados no son válidos.";

                        return RedirectToPage("./Empleados", new { urlcompany = Input.Salt });
                    }
                }

                //VALIDAMOS PREGUNTAS

                //var user = new ApplicationUser { UserName = (Input.NumeroCedula + "@tempo.com"), Email = (Input.NumeroCedula + "@tempo.com") };
                var empresa = await profilerService.GetInstancia().ProEmpresa.GetDataEmpresa(Input.Salt, "GLSELFSERVICE_USERAPP");

                if (string.IsNullOrEmpty(empresa.Nit))
                {
                    ViewData["ErrorMessage"] = "¡Los datos proporcionados no son válidos!";
                    ModelState.AddModelError(String.Empty, "¡Los datos proporcionados no son válidos!");
                    ErrorMessage = "¡Los datos proporcionados no son válidos!";

                    return RedirectToPage("./Empleados", new { urlcompany = Input.Salt });
                }

                var userExists = await userManager.FindByEmailAsync((Input.NumeroCedula + "@tempo.com"));

                if (userExists != null)
                {
                    var delete = await userManager.DeleteAsync(userExists);
                }

                var user = new ApplicationUser
                {
                    UserName = (Input.NumeroCedula + "@tempo.com"),
                    NroId = empleado.CedulaEmpleado,
                    Email = (Input.NumeroCedula + "@tempo.com"),
                    Nombre = empleado.NombreEmpleado,
                    PriNombre = "",
                    SegNombre = "",
                    PriApellido = "",
                    SegApellido = "",
                    IdEmpresa = empresa.Id,
                    NitEmpresa = empresa.Nit,
                    UsuarioGL = "EXT",
                    CodigoUsuarioGL = "EXT",
                    CodigoEmpleado = empleado.CodigoEmpleado,
                    CodigoTercero = empleado.CodigoEmpleado,
                    TipoUsuario = "",
                    Celular = "",
                    Telefono = "",
                    Direccion = "",
                    Dependencia = "",
                    EmailUser = empleado.CorreoEmpleado,
                    EsCliente = false,
                    KeyConnection = Input.KeyConnect,
                    PhoneNumber = "",
                };

                var result = await userManager.CreateAsync(user);


                if (!result.Succeeded)
                {
                    ViewData["ErrorMessage"] = "Los datos proporcionados no son válidos.";
                    ModelState.AddModelError(String.Empty, "Los datos proporcionados no son válidos.");
                    ErrorMessage = "Los datos proporcionados no son válidos.";

                    return RedirectToPage("./Empleados", new { urlcompany = Input.Salt });
                }

                await userManager.AddToRoleAsync(user, "EMPLEADO");

                // Generar un token de confirmación con expiración de 1 día
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmarEmpleado", "Auth", new { userId = user.Id, token }, Request.Scheme);


                var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("CERTI_EMPLEADO", Input.KeyConnect);
                string body = "Estimado/a " + empleado.NombreEmpleado + ". <br>"
                               + "Le informamos que se le ha concedido acceso al SelfService de Gestión Humana. <br>"
                               + "Por favor, sigue el siguiente enlace para acceder a la aplicación: <a href='" + confirmationLink + "'> Confirmar </a> <br>"
                               + "Este enlace te dirigirá directamente a la interfaz de nuestra aplicación, donde podrás comenzar a utilizarla de inmediato.<br>"
                               + "No dudes en ponerte en contacto con nosotros si necesitas asistencia o tienes alguna pregunta relacionada con el acceso o el funcionamiento de la aplicación.";

                List<string> destinatarios = new List<string>();
                emailconfig.Asunto = "Link de acceso al SelfService";
                emailconfig.Titulo = "Link de acceso al SelfService";

                destinatarios.Add(empleado.CorreoEmpleado);

                mail.SendMail(body, destinatarios, emailconfig);

                TempData["Logo"] = dataEmpresa.Logo;
                TempData["EmailSend"] = Funciones.HideEmail(empleado.CorreoEmpleado);
                /*****/
                return RedirectToPage("./ConfirmarEmpleado");

            }
            // If we got this far, something failed, redisplay form
            return RedirectToPage("./Empleados", new { urlcompany = Input.Salt });
        }

        private async Task<EmpleadoNovedad> ValidateDataEmpleado(string Cedula,DateTime FechaDeNacimiento,string TipoValidacion,string Validacion,string Keyconnection)
        {
            var empleado = await profilerService.GetInstancia().ProGestionHumana.GetInfoEmpleadoNovedad(Cedula, Keyconnection);

            return empleado;
        }
    }
}