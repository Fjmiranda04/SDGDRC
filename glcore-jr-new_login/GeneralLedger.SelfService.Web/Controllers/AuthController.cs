using Amazon.IdentityManagement.Model;
using Common;
using Common.Implements;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
using GeneralLedger.SelfServiceCore.Data.ModelsGL.ModelProfilers;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    public class AuthController : Controller
    {
        #region UserManager
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        #endregion UserManager

        #region Services

        private readonly IUsuarioEmpresaService usuarioService;
        private readonly IMenuService menuService;
        private readonly IPerfilService perfilService;
        private readonly IProfilerService profilerService;
        private readonly IMail mail;

        #endregion Services

        #region Others

        private IHttpContextAccessor contextAccessor;
        private string KeyConnection;

        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        #endregion Others

        #region Constructor

        public AuthController
        (
            SignInManager<ApplicationUser> signInManager,
             UserManager<ApplicationUser> userManager,
            IUsuarioEmpresaService usuarioService,
            IMenuService menuService,
            IPerfilService perfilService,
            IHttpContextAccessor contextAccessor,
            IProfilerService profilerService,
            IMail mail
        )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.usuarioService = usuarioService;
            this.menuService = menuService;
            this.perfilService = perfilService;

            this.contextAccessor = contextAccessor;
            this.profilerService = profilerService;
            this.mail = mail;

            ConnectionTools.SetKeyConnectionStringDirect(SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection"));
            KeyConnection = SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection");
        }

        #endregion Constructor

        #region ActionMethods

        public IActionResult Index()
        {
            return Redirect("login");
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl = "/")
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
        }
        //Cualquier cosa aqui get res
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            if (string.IsNullOrEmpty(KeyConnection)) SetKeyConnection();

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var rol =  userManager.GetRolesAsync(user).Result.FirstOrDefault();
            //var user = await profilerService.GetInstancia().proUserManager.FindByNameAsync(User.Identity.Name, KeyConnection);
            var empresa = await profilerService.GetInstancia().ProEmpresa.GetEmpresa(user.NitEmpresa,KeyConnection);

            await signInManager.SignOutAsync();

            if (rol.Equals("EMPLEADO"))
            {
                return Redirect("/Identity/Account/Empleados?urlcompany=" + empresa.Salt);
            }

            return Redirect("/Identity/Account/Login2?urlcompany="+empresa.Salt);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmarEmpleado(string userId, string token)
        {

            // Verificar si el usuario y el token son válidos
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            // Confirmar el correo electrónico
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                return BadRequest("Error al confirmar el correo electrónico");
            }

            // Si el correo electrónico se confirma con éxito, puedes iniciar sesión automáticamente al usuario
            await signInManager.SignInAsync(user, isPersistent: false);

            // Redirigir al usuario a una página de inicio o a la vista deseada
            return RedirectToAction("Index", "GestionHumana");
        }


        [HttpPost]
        [Route("api/auth/createusergl")]
        public async Task<IActionResult> CreateUserGL([FromBody] UserApplicationGL userApplicationGL)
        {

            if (string.IsNullOrEmpty(userApplicationGL.UserApiGl) || string.IsNullOrEmpty(userApplicationGL.PasswordApiGL))
            {
                return BadRequest(new { result = false, message = "Usuario no suministrado!", data = "null" });
            }

            var userApiCfg = Configuration["ApiAuthentication:User"].ToString();
            var passwordApiCfg = Encrypt.EncryptMD5(Configuration["ApiAuthentication:Password"].ToString());
            var userApiGl = userApplicationGL.UserApiGl;
            var passwordApiGl = userApplicationGL.PasswordApiGL;

            if (!(userApiGl.Equals(userApiCfg) && passwordApiGl.Equals(passwordApiCfg)))
            {
                return Unauthorized(new { result = false, message = "Credenciales incorrectas!",data = "null" });
            }

            try
            {
                var user = new ApplicationUser
                {
                    UserName = userApplicationGL.CodigoUsuario,
                    NroId = userApplicationGL.IdentificacionUsuario,
                    Email = userApplicationGL.Email,
                    Nombre = userApplicationGL.NombreCompleto,
                    PriNombre = userApplicationGL.PrimerNombre,
                    SegNombre = userApplicationGL.SegundoNombre,
                    PriApellido = userApplicationGL.PrimerApellido,
                    SegApellido = userApplicationGL.SegundoApellido,
                    IdEmpresa = userApplicationGL.IdEmpresa,
                    NitEmpresa = userApplicationGL.NitEmpresa,
                    UsuarioGL = userApplicationGL.NombreUsuario,
                    CodigoUsuarioGL = userApplicationGL.CodigoUsuarioGL,
                    CodigoEmpleado = userApplicationGL.CodigoEmpleado,
                    CodigoTercero = userApplicationGL.CodigoTercero,
                    TipoUsuario = userApplicationGL.TipoUsuario,
                    Celular = userApplicationGL.Celular,
                    Telefono = userApplicationGL.Telefono,
                    Direccion = userApplicationGL.Direccion,
                    Dependencia = userApplicationGL.DependenciaUsuario,
                    EmailUser = userApplicationGL.Email,
                    EsCliente = userApplicationGL.EsCliente,
                    KeyConnection = userApplicationGL.KeyConnection,
                    PhoneNumber = userApplicationGL.Telefono,
                };

                var userresult = await userManager.CreateAsync(user, userApplicationGL.Contrasena);

                if (userresult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, userApplicationGL.Rol);
                    await userManager.AddClaimAsync(user, new Claim("KeyConnection", userApplicationGL.KeyConnection));

                    string KeyConnection = userApplicationGL.KeyConnection;

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page
                    (
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, userName = user.UserName, code = code, keyConnection = KeyConnection },
                        protocol: Request.Scheme
                    );

                 
                    var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("APPROVE_USER", KeyConnection);
                    var body = emailconfig.Cuerpo.ToString().Replace("<<NOMBREUSUARIO>>", $"{user.PriNombre} {user.SegNombre} {user.PriApellido} {user.SegApellido}").Replace("<<LINK>>", $"{HtmlEncoder.Default.Encode(callbackUrl)}");
                    var destinatarios = user.Email.ToString().Split(",").ToList();
                    mail.SendMail(body, destinatarios, emailconfig);

                    return Json(new { result = true, message = "Registrado!", data = userApplicationGL.CodigoUsuario });
                }

                return Json(new { result = false, message = "Error!", data = userApplicationGL.CodigoUsuario });
            }
            catch(Exception ex)
            {
                return Json(new { result = false, message = "Error!: "+ ex.Message,data = "null"});
            }
        }

        [HttpPost]
        [Route("api/auth/updateusergl")]
        public async Task<IActionResult> UpdateUserGL([FromBody] UserApplicationGL userApplicationGL)
        {
            if (string.IsNullOrEmpty(userApplicationGL.UserApiGl) || string.IsNullOrEmpty(userApplicationGL.PasswordApiGL))
            {
                return BadRequest(new { result = false, message = "Usuario no suministrado!", data = "null" });
            }

            var userApiCfg = Configuration["ApiAuthentication:User"].ToString();
            var passwordApiCfg = Encrypt.EncryptMD5(Configuration["ApiAuthentication:Password"].ToString());
            var userApiGl = userApplicationGL.UserApiGl;
            var passwordApiGl = userApplicationGL.PasswordApiGL;

            if (!(userApiGl.Equals(userApiCfg) && passwordApiGl.Equals(passwordApiCfg)))
            {
                return Unauthorized(new { result = false, message = "Credenciales incorrectas!", data = "null" });
            }

            try
            {

                var userUpd = await userManager.FindByNameAsync(userApplicationGL.UserSSGL);
                IdentityResult userresult = null;

                if (userUpd != null)
                {
                    userUpd.UserName = userApplicationGL.CodigoUsuario;
                    userUpd.NroId = userApplicationGL.IdentificacionUsuario;
                    userUpd.Email = userApplicationGL.Email;
                    userUpd.Nombre = userApplicationGL.NombreCompleto;
                    userUpd.PriNombre = userApplicationGL.PrimerNombre;
                    userUpd.SegNombre = userApplicationGL.SegundoNombre;
                    userUpd.PriApellido = userApplicationGL.PrimerApellido;
                    userUpd.SegApellido = userApplicationGL.SegundoApellido;
                    userUpd.IdEmpresa = userApplicationGL.IdEmpresa;
                    userUpd.NitEmpresa = userApplicationGL.NitEmpresa;
                    userUpd.UsuarioGL = userApplicationGL.NombreUsuario;
                    userUpd.CodigoUsuarioGL = userApplicationGL.CodigoUsuarioGL;
                    userUpd.CodigoEmpleado = userApplicationGL.CodigoEmpleado;
                    userUpd.CodigoTercero = userApplicationGL.CodigoTercero;
                    userUpd.TipoUsuario = userApplicationGL.TipoUsuario;
                    userUpd.Celular = userApplicationGL.Celular;
                    userUpd.Telefono = userApplicationGL.Telefono;
                    userUpd.Direccion = userApplicationGL.Direccion;
                    userUpd.Dependencia = userApplicationGL.DependenciaUsuario;
                    userUpd.EmailUser = userApplicationGL.Email;
                    userUpd.EsCliente = userApplicationGL.EsCliente;
                    userUpd.KeyConnection = userApplicationGL.KeyConnection;
                    userUpd.PhoneNumber = userApplicationGL.Telefono;
                   

                    userresult = await userManager.UpdateAsync(userUpd);

                }
                else
                {
                    var user = new ApplicationUser
                    {
                        UserName = userApplicationGL.CodigoUsuario,
                        NroId = userApplicationGL.IdentificacionUsuario,
                        Email = userApplicationGL.Email,
                        Nombre = userApplicationGL.NombreCompleto,
                        PriNombre = userApplicationGL.PrimerNombre,
                        SegNombre = userApplicationGL.SegundoNombre,
                        PriApellido = userApplicationGL.PrimerApellido,
                        SegApellido = userApplicationGL.SegundoApellido,
                        IdEmpresa = userApplicationGL.IdEmpresa,
                        NitEmpresa = userApplicationGL.NitEmpresa,
                        UsuarioGL = userApplicationGL.NombreUsuario,
                        CodigoUsuarioGL = userApplicationGL.CodigoUsuarioGL,
                        CodigoEmpleado = userApplicationGL.CodigoEmpleado,
                        CodigoTercero = userApplicationGL.CodigoTercero,
                        TipoUsuario = userApplicationGL.TipoUsuario,
                        Celular = userApplicationGL.Celular,
                        Telefono = userApplicationGL.Telefono,
                        Direccion = userApplicationGL.Direccion,
                        Dependencia = userApplicationGL.DependenciaUsuario,
                        EmailUser = userApplicationGL.Email,
                        EsCliente = userApplicationGL.EsCliente,
                        KeyConnection = userApplicationGL.KeyConnection,
                        PhoneNumber = userApplicationGL.Telefono,
                    };

                    userresult = await userManager.CreateAsync(user, userApplicationGL.Contrasena);

                    await userManager.AddToRoleAsync(user, userApplicationGL.Rol);
                    await userManager.AddClaimAsync(user, new Claim("KeyConnection", userApplicationGL.KeyConnection));

                    string KeyConnection = userApplicationGL.KeyConnection;

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page
                    (
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, userName = user.UserName, code = code, keyConnection = KeyConnection },
                        protocol: Request.Scheme
                    );


                    var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("APPROVE_USER", KeyConnection);
                    var body = emailconfig.Cuerpo.ToString().Replace("<<NOMBREUSUARIO>>", $"{user.PriNombre} {user.SegNombre} {user.PriApellido} {user.SegApellido}").Replace("<<LINK>>", $"{HtmlEncoder.Default.Encode(callbackUrl)}");
                    var destinatarios = user.Email.ToString().Split(",").ToList();
                    mail.SendMail(body, destinatarios, emailconfig);
                }
            
                if (userresult.Succeeded)
                {
                    return Json(new { result = true, message = "Actualizado!", data = userApplicationGL.CodigoUsuario });
                }

                return Json(new { result = false, message = "Error!", data = userApplicationGL.CodigoUsuario });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Error!: " + ex.Message, data = "null" });
            }
        }

        private void SetKeyConnection()
        {
            KeyConnection = userManager.FindByNameAsync(User.Identity.Name).Result.KeyConnection;
        }

        #endregion ActionMethods
    }
}