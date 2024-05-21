using AutoMapper;
using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using GeneralLedger.SelfServiceCore.Services.ServicesGL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Controllers
{
    [Authorize]
    public class ConfigurationController : Controller
    {
        #region UserManager

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        //private readonly RoleManager<IdentityUserRole> _userRoleManager;

        #endregion UserManager

        #region Servicios

        private readonly IPQRSFService pqrsfService;
        private readonly IMenuService menuService;
        private readonly IMenuUsuarioService menuUsuarioService;
        private readonly IMenuRolService menuRolService;
        private readonly ISolicitudClienteService solicitudClienteService;
        private readonly ITerceroService terceroService;
        private readonly IClienteService clienteService;
        private readonly IEmpleadoService empleadoService;
        private readonly IAgenteService agenteService;
        private readonly IEmpresaService empresaService;
        private readonly IMail mail;
        private readonly IEmailConfiguracionService emailConfiguracionService;
        private readonly IConfiguracionService configuracionService;
        private readonly IAccglUsuarioService usuarioGlService;
        private readonly IProfilerService profilerService;
        private readonly IUsuarioEmpresaService usuarioEmpresaService;
        private readonly string KeyConnection;

        #endregion Servicios

        #region Others

        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;

        #endregion Others

        #region Constructor

        public ConfigurationController
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IPQRSFService pqrsfService,
            IMenuService menuService,
            IMenuUsuarioService menuUsuarioService,
            IMenuRolService menuRolService,
            ISolicitudClienteService solicitudClienteService,
            ITerceroService terceroService,
            IClienteService clienteService,
            IEmailConfiguracionService emailConfiguracionService,
            IEmpresaService empresaService,
            IEmpleadoService empleadoService,
            IAgenteService agenteService,
            IConfiguracionService configuracionService,
            IAccglUsuarioService usuarioGlService,
            IProfilerService profilerService,
            IMail mail,
            IMapper mapper,
            IHttpContextAccessor contextAccessor,
            IUsuarioEmpresaService usuarioEmpresaService
        )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;

            this.pqrsfService = pqrsfService;
            this.menuService = menuService;
            this.menuUsuarioService = menuUsuarioService;
            this.menuRolService = menuRolService;
            this.solicitudClienteService = solicitudClienteService;
            this.terceroService = terceroService;
            this.clienteService = clienteService;
            this.empleadoService = empleadoService;
            this.agenteService = agenteService;
            this.emailConfiguracionService = emailConfiguracionService;
            this.usuarioGlService = usuarioGlService;
            this.empresaService = empresaService;
            this.profilerService = profilerService;
            this.mail = mail;
            this.configuracionService = configuracionService;
            this.usuarioEmpresaService = usuarioEmpresaService;

            this.mapper = mapper;
            this.contextAccessor = contextAccessor;

            ConnectionTools.SetKeyConnectionStringDirect(SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection"));
            KeyConnection = SessionHelper.GetValue(this.contextAccessor.HttpContext.User, "KeyConnection");
        }

        #endregion Constructor

        #region ActionMethod

        public IActionResult ConfiguracionGeneral()
        {
            return View();
        }

        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Permisos = await profilerService.GetInstancia().ProConfiguracion.GetPermisosUsuario(user.Id, KeyConnection);
            return View("Usuarios");
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Perfiles()
        {
            return View("Perfiles");
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Empresas()
        {
            return View("Empresas");
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult UserRequest()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> EditUser(string nroid)
        {
            var user = await userManager.Users.Where(x => x.NroId == nroid).FirstOrDefaultAsync();
            var rol = userManager.GetRolesAsync(user).Result.FirstOrDefault();

            var roluser = roleManager.Roles.Where(r => r.Name == rol).Select(r => new { r.Id, r.Name }).FirstOrDefault();
            var rolusers = roleManager.Roles.ToListAsync().Result.Select(r => new { r.Id, r.Name });
            //ViewBag.UserGl = await usuarioGlService.GetUsuariosGL();

            var AspNetUser = new AspNetUserShowDTO
            {
                Id = user.Id,
                NroId = user.NroId,
                UserName = $"{user.PriNombre} {user.SegNombre} {user.PriApellido} {user.SegApellido}",
                Password = user.PasswordHash,
                Email = user.Email,
                Direccion = user.Direccion,
                Celular = user.Celular,
                Telefono = user.PhoneNumber,
                IdRol = roluser.Id,
                Rol = roluser.Name,
                UserGL = user.UsuarioGL
            };

            return View(AspNetUser);
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> EditUser(AspNetUserEditDTO aspNetUser)
        {
            var user = await userManager.Users.Where(x => x.NroId == aspNetUser.NroId).FirstOrDefaultAsync();
            user.Nombre = aspNetUser.UserName;
            user.PhoneNumber = aspNetUser.Telefono;
            user.Email = aspNetUser.Email;
            user.Celular = aspNetUser.Celular;
            user.Direccion = aspNetUser.Direccion;
            user.UsuarioGL = aspNetUser.UserGL;

            var userResult = await userManager.UpdateAsync(user);

            if (userResult.Succeeded)
            {
                return Json(new { result = true, message = "La información del usuario ha sido actualizada satisfactoriamente!" });
            }

            return Json(new { result = false, message = "Ups! Ha ocurrido un error, por favor vuelva a intentarlo" });
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> EditEmailUser(string newEmail, string nroIdUser)
        {
            try
            {
                var user = await userManager.Users.Where(x => x.NroId == nroIdUser).FirstOrDefaultAsync();
                var code = await userManager.GenerateChangeEmailTokenAsync(user, newEmail);
                await userManager.ChangeEmailAsync(user, newEmail, code);

                await profilerService.GetInstancia().ProConfiguracion.ChangeEmail(newEmail, nroIdUser, user.NitEmpresa, KeyConnection);

                return Json(new { result = true, message = "El Email se ha cambiado con exito!" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Ha ocurrido un error inesperado, por favor intente más tarde!" });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> ChangePassword(string newPassword, string oldPassword, string nroIdUser)
        {
            try
            {
                var user = await userManager.Users.Where(x => x.NroId == nroIdUser).FirstOrDefaultAsync();
                var resultUser = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

                if (resultUser.Succeeded)
                {
                    return Json(new { result = true, message = "La contraseña se ha cambiado exitosamente!" });
                }
                else
                {
                    return Json(new { result = false, message = "La contraseña actual es incorrecta!" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Ups! Ha ocurrido un error, intentelo nuevamente" + ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> ChangePasswordU(string newPassword, string oldPassword, string nroIdUser)
        {
            try
            {
                var user = await userManager.Users.Where(x => x.NroId == nroIdUser).FirstOrDefaultAsync();
                var resultUser = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

                if (resultUser.Succeeded)
                {
                    return Json(new { result = true, message = "La contraseña se ha cambiado exitosamente!" });
                }
                else
                {
                    return Json(new { result = false, message = "La contraseña actual es incorrecta!" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Ups! Ha ocurrido un error, intentelo nuevamente" + ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> ChangeRolUser(string newRol, string nroIdUser)
        {
            var user = await userManager.Users.Where(x => x.NroId == nroIdUser).FirstOrDefaultAsync();
            var CurrentRolUser = userManager.GetRolesAsync(user).Result.FirstOrDefault();

            var newRolUser = await roleManager.FindByIdAsync(newRol);
            if (newRolUser != null)
            {
                await userManager.RemoveFromRoleAsync(user, CurrentRolUser);
                var resulRolUser = await userManager.AddToRoleAsync(user, newRolUser.Name);
                if (resulRolUser.Succeeded)
                {
                    return Json(new { result = true, message = "El rol de usuario se ha cambiado exitosamente!" });
                }
            }
            return Json(new { result = false, message = "Ups! Ha ocurrido un error, intentelo nuevamente" });
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> CreateRol(string nameRol)
        {
            var result = await roleManager.CreateAsync(new IdentityRole(nameRol));

            if (result.Succeeded)
            {
                return Json(new { result = true, message = "Perfil agregado con exito" });
            }

            return Json(new { result = false, message = "Ups! Ha ocurrido un error, intentelo nuevamente!" });
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetUsers()
        {
            var users = await userManager.Users.ToListAsync();

            var listUsers = users.Select(u => new
            {
                NroId = u.NroId,
                Nombre = $"{u.PriNombre} {u.SegNombre} {u.PriApellido} {u.SegApellido}",
                Correo = u.Email,
                Telefono = u.PhoneNumber,
                Estado = u.EmailConfirmed,
                Rol = userManager.GetRolesAsync(u).Result.FirstOrDefault(),
                UserGL = u.UsuarioGL
            });

            return Json(new { data = listUsers });
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> CreateUser(AspNetUserCreateDTO aspNetUser)
        {
            try
            {
                var userInSession = await userManager.FindByNameAsync(User.Identity.Name);
                aspNetUser.Rol = roleManager.FindByIdAsync(aspNetUser.IdRol).Result.Name;
                var user = new ApplicationUser
                {
                    UserName = aspNetUser.Email,
                    NroId = aspNetUser.NroId,
                    Email = aspNetUser.Email,
                    Nombre = aspNetUser.UserName,
                    PriNombre = aspNetUser.PriNombre,
                    SegNombre = aspNetUser.SegNombre,
                    PriApellido = aspNetUser.PriApellido,
                    SegApellido = aspNetUser.SegApellido,
                    PhoneNumber = aspNetUser.Telefono,
                    IdEmpresa = userInSession.IdEmpresa,
                    NitEmpresa = userInSession.NitEmpresa,
                    Direccion = aspNetUser.Direccion,
                    Celular = aspNetUser.Celular,
                    Dependencia = "",
                    UsuarioGL = "",
                    KeyConnection = userInSession.KeyConnection
                };

                var agente = new Agente
                {
                    Codigo = aspNetUser.NroId,
                    NroId = aspNetUser.NroId,
                    NitEmpresa = userInSession.NitEmpresa,
                    NombreCompleto = aspNetUser.UserName,
                    Email = aspNetUser.Email,
                    RecibeEmail = false
                };

                var resultUser = new IdentityResult();

                resultUser = await userManager.CreateAsync(user, aspNetUser.NroId);

                if (resultUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, aspNetUser.Rol);

                    var usuarioEmpresaCreateDTO = new UsuarioEmpresaCreateDTO
                    {
                        IdEmpresa = userInSession.IdEmpresa,
                        NitEmpresa = userInSession.NitEmpresa,
                        NroIde = aspNetUser.NroId,
                        Email = aspNetUser.Email
                    };

                    var configuracionGeneral = await configuracionService.GetAll();
                    var idEmpresa = configuracionGeneral.Where(x => x.Clave == "ID_EMPRESA").Select(x => x.Valor).FirstOrDefault();
                    var connectionStringKey = configuracionGeneral.Where(x => x.Clave == "CONNECTION_STRING").Select(x => x.Valor).FirstOrDefault();

                    await usuarioEmpresaService.Insert(mapper.Map<UsuarioEmpresa>(usuarioEmpresaCreateDTO));
                    await userManager.AddClaimAsync(user, new Claim("KeyConnection", connectionStringKey));

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, userName = user.UserName, code = code },
                        protocol: Request.Scheme);

                    var body = $"Su cuenta ha sido creada por favor click en el siguiente enlace para confirmar: {HtmlEncoder.Default.Encode(callbackUrl)}";
                    var emails = user.Email;
                    var destinatarios = emails.ToString().Split(",").ToList();
                    var emailconf = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("APPROVE_USER", connectionStringKey);
                    mail.SendMail(body, destinatarios, emailconf);

                    return Json(new { result = true, message = "Se ha creado una cuenta!" });
                }
                else
                {
                    return Json(new { result = false, message = "Ups! ha ocurrido un error o el usuario se encuentra registrado, intente nuevamente" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Ups! ha ocurrido un error o el usuario se encuentra registrado, intente nuevamente" });
            }
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetRoles()
        {
            var roles = await roleManager.Roles.ToListAsync();
            var listRoles = roles.Select(r => new
            {
                Id = r.Id,
                Rol = r.Name,
            });

            return Json(new { data = listRoles });
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetUser(string nroId)
        {
            var user = await userManager.Users.Where(x => x.NroId == nroId).FirstOrDefaultAsync();
            var rol = userManager.GetRolesAsync(user).Result.FirstOrDefault();

            var roluser = roleManager.Roles.Where(r => r.Name == rol).Select(r => new { r.Id, r.Name }).FirstOrDefault();
            var rolusers = roleManager.Roles.ToListAsync().Result.Select(r => new { r.Id, r.Name });

            if (user != null)
                return Json(new { result = true, data = new { nroId = user.NroId, name = $"{user.PriNombre} {user.SegNombre} {user.PriApellido} {user.SegApellido}", email = user.Email, direccion = user.Direccion, celular = user.Celular, telefono = user.PhoneNumber, rolUser = roluser, UserGL = user.UsuarioGL }, roles = rolusers });

            return Json(new { result = false, message = "Ups! ha ocurrido un error, intente nuevamente!" });
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetEmployee(string nroId)
        {
            try
            {
                var result = await profilerService.GetInstancia().ProAccglter.GetTercero(nroId, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> OnOffUser([FromBody] string nroid)
        {
            var user = await userManager.Users.Where(x => x.NroId == nroid).FirstOrDefaultAsync();

            if (user == null)
                return Json(new { result = false, message = "Ups! Ha ocurrido un error, intente nuevamente" });

            var onoff = user.EmailConfirmed;
            user.EmailConfirmed = !onoff;
            var userResult = await userManager.UpdateAsync(user);

            if (userResult.Succeeded)
                return Json(new { result = true, message = $"Usuario {((!onoff) ? "Activado" : "Desactivado")} con exito" });

            return Json(new { result = false, message = "Ups! Ha ocurrido un error, intente nuevamente" });
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetMenusByUsuario(string nroid)
        {
            //var usermenus = await menuService.GetMenusByUser(nroid);
            var usermenus = await profilerService.GetInstancia().ProMenus.GetMenusByUser(nroid,"",KeyConnection);
            var allmenus = await profilerService.GetInstancia().ProMenus.GetMenus(KeyConnection);
            List<object> dataMenu = new List<object>();
            foreach (var am in allmenus)
            {
                bool haveMenu = false;
                foreach (var us in usermenus)
                {
                    if (us.CodMnu == am.CodMnu)
                    {
                        haveMenu = true;
                    }
                }

                dataMenu.Add(new
                {
                    codMnu = am.CodMnu,
                    depMnu = am.DepMnu,
                    icoMnu = am.IcoMnu,
                    nomMnu = am.NomMnu,
                    activo = haveMenu
                });
            }
            return Json(new { data = dataMenu });
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> AddDeleteMenuUser(string codMnu, string nroIdUser, bool value)
        {
            if (value)
            {
                await profilerService.GetInstancia().ProMenus.RemoveMenuUsuario(codMnu, nroIdUser,KeyConnection);
                return Json(new { result = true, message = "Se ha removido el menu al usuario con exito!" });
            }
            else
            {
                await profilerService.GetInstancia().ProMenus.AddMenuUsuario(codMnu, nroIdUser, KeyConnection);
                return Json(new { result = true, message = "Se ha agregado el menu al usuario con exito!" });
            }
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetMenusByRol(string idRol)
        {
            var menusroles = await menuService.GetMenusByRol(idRol);
            var allmenus = await menuService.GetAll();
            List<object> dataMenu = new List<object>();
            foreach (var am in allmenus)
            {
                bool haveMenu = false;
                foreach (var us in menusroles)
                {
                    if (us.CodMnu == am.CodMnu)
                    {
                        haveMenu = true;
                    }
                }

                dataMenu.Add(new
                {
                    codMnu = am.CodMnu,
                    depMnu = am.DepMnu,
                    icoMnu = am.IcoMnu,
                    nomMnu = am.NomMnu,
                    activo = haveMenu
                });
            }
            return Json(new { data = dataMenu });
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> AddDeleteMenuRol(string codMnu, string idRol, bool value)
        {
            if (value)
            {
                await menuRolService.DeleteMenuRol(codMnu, idRol);
                return Json(new { result = true, message = "Se ha removido el menu al rol con exito!" });
            }
            else
            {
                await menuRolService.InsertMenuRol(codMnu, idRol);
                return Json(new { result = true, message = "Se ha agregado el menu al rol con exito!" });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetCustomerRequests(string state)
        {
            var nitEmpresa = userManager.FindByNameAsync(User.Identity.Name).Result.NitEmpresa;
            var solicitudes = await solicitudClienteService.GetSolicitudClienteByStatus(state, nitEmpresa);

            return Json(new { data = solicitudes });
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> ApproveCustomer(int id)
        {
            try
            {
                var solicitud = await solicitudClienteService.GetById(id);
                if (solicitud == null)
                {
                    return Json(new { result = false, message = "Ups! Ha ocurrido un error, intenta de nuevo" });
                }
                else
                {
                    var cliente = new SelfServiceCore.Data.ModelsGL.Cliente();

                    cliente = await profilerService.GetInstancia().ProCliente.GetCliente(solicitud.NroIde, KeyConnection);

                    if (string.IsNullOrEmpty(cliente.Clinit) || string.IsNullOrEmpty(cliente.Clicod))
                    {
                        try
                        {
                            cliente = new SelfServiceCore.Data.ModelsGL.Cliente
                            {
                                TipDoc = solicitud.TipDoc,
                                Clinit = solicitud.NroIde,
                                Clinom = solicitud.NombreCompleto,
                                CliPriNom = solicitud.PrimerNombre,
                                CliSegNom = solicitud.SegundoNombre,
                                CliPriApe = solicitud.PrimerApellido,
                                CliSegApe = solicitud.SegundoApellido,
                                Clidir = solicitud.Direccion,
                                CliCodCiud = solicitud.Ciudad,
                                Clitel = solicitud.Telefono,
                                Clicel1 = solicitud.Celular,
                                Climail = solicitud.Email,
                            };

                            cliente = await profilerService.GetInstancia().ProCliente.SaveCliente(cliente, KeyConnection);
                        }
                        catch (Exception ex)
                        {
                            return Json(new { result = false, message = "Ups! ha ocurrido un error, intente nuevamente" });
                        }
                    }

                    if (!string.IsNullOrEmpty(cliente.Clicod))
                    {
                        var configuracionGeneral = await configuracionService.GetAll();
                        var idEmpresa = configuracionGeneral.Where(x => x.Clave == "ID_EMPRESA").Select(x => x.Valor).FirstOrDefault();
                        var connectionStringKey = configuracionGeneral.Where(x => x.Clave == "CONNECTION_STRING").Select(x => x.Valor).FirstOrDefault();

                        var user = new ApplicationUser
                        {
                            UserName = solicitud.Email,
                            NroId = solicitud.NroIde,
                            Email = solicitud.Email,
                            Nombre = $"{solicitud.PrimerNombre} {solicitud.SegundoNombre} {solicitud.PrimerApellido} {solicitud.SegundoApellido}",
                            PriNombre = solicitud.PrimerNombre,
                            SegNombre = solicitud.SegundoNombre,
                            PriApellido = solicitud.PrimerApellido,
                            SegApellido = solicitud.SegundoApellido,
                            IdEmpresa = int.Parse(idEmpresa),
                            NitEmpresa = solicitud.NitEmpresa.ToString().Trim(),
                            Direccion = solicitud.Direccion,
                            Celular = solicitud.Celular,
                            PhoneNumber = solicitud.Telefono,
                            Dependencia = "",
                            UsuarioGL = "",
                            KeyConnection = connectionStringKey,
                        };

                        var resultUser = await userManager.CreateAsync(user, cliente.Clinit);

                        if (resultUser.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "CLIENTE");
                            await userManager.AddClaimAsync(user, new Claim("KeyConnection", connectionStringKey));

                            solicitud.Estado = "2";
                            await solicitudClienteService.Update(solicitud);

                            var usuarioEmpresaCreateDTO = new UsuarioEmpresaCreateDTO
                            {
                                IdEmpresa = int.Parse(idEmpresa),
                                NitEmpresa = solicitud.NitEmpresa.ToString().Trim(),
                                NroIde = solicitud.NroIde,
                                Email = solicitud.Email
                            };

                            await usuarioEmpresaService.Insert(mapper.Map<UsuarioEmpresa>(usuarioEmpresaCreateDTO));

                            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                            var callbackUrl = Url.Page(
                                "/Account/ConfirmEmail",
                                pageHandler: null,
                                values: new { area = "Identity", userId = user.Id, userName = user.UserName, code = code, keyConnection = connectionStringKey },
                                protocol: Request.Scheme);

                            //var configuracionEmail = mapper.Map<EmailConfiguracionDTO>(await emailConfiguracionService.GetEmailConfiguracionByKey("APPROVE_USER"));
                            var emailconfig = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("APPROVE_USER", KeyConnection);
                            var body = emailconfig.Cuerpo.ToString().Replace("<<NOMBREUSUARIO>>", $"{user.PriNombre} {user.SegNombre} {user.PriApellido} {user.SegApellido}").Replace("<<LINK>>", $"{HtmlEncoder.Default.Encode(callbackUrl)}");
                            var destinatarios = user.Email.ToString().Split(",").ToList();
                            mail.SendMail(body, destinatarios, emailconfig);

                            return Json(new { result = true, message = "Usuario cliente aprobado, se ha creado una cuenta para este cliente!" });
                        }
                        else
                        {
                            return Json(new { result = false, message = "Ups! ha ocurrido un error, intente nuevamente" });
                        }
                    }
                    else
                    {
                        return Json(new { result = false, message = "Ups! ha ocurrido un error, intente nuevamente" });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = "Ups! ha ocurrido un error: " + ex.Message });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> RejectCustomer(int id)
        {
            var solicitud = await solicitudClienteService.GetById(id);
            solicitud.Estado = "3";
            await solicitudClienteService.Update(solicitud);

            return Json(new { result = true, message = "Usuario cliente rechazado con exito!" });
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Permisos()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Permisos = await profilerService.GetInstancia().ProConfiguracion.GetPermisosUsuario(user.Id, KeyConnection);
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetPermisos(string search)
        {
            try
            {
                var result = await profilerService.GetInstancia().ProConfiguracion.GetPermisos(search, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetPermiso(int id)
        {
            try
            {
                var result = await profilerService.GetInstancia().ProConfiguracion.GetPermiso(id, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> SavePermiso(int id, string permiso, string tipo, string descripcion)
        {
            try
            {
                var result = await profilerService.GetInstancia().ProConfiguracion.SavePermiso(id, permiso, tipo, descripcion, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetPermisosUsuario(string idUsuario)
        {
            try
            {
                var result = await profilerService.GetInstancia().ProConfiguracion.GetPermisosUsuario(idUsuario, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> SavePermisoUsuario(string idUsuario, int idPermiso)
        {
            try
            {
                var result = await profilerService.GetInstancia().ProConfiguracion.SavePermisoUsuario(idUsuario, idPermiso, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetRolesUsuario(string idUsuario)
        {
            try
            {
                var result = await profilerService.GetInstancia().ProConfiguracion.GetRolesUsuario(idUsuario, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> SaveRolUsuario(string idUsuario, string idRol)
        {
            try
            {
                var result = await profilerService.GetInstancia().ProConfiguracion.SaveRolUsuario(idUsuario, idRol, KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> GetConfiguraciones()
        {
            try
            {
                var result = await profilerService.GetInstancia().ProConfiguracion.GetConfiguraciones(KeyConnection);
                return Json(new { result = true, message = "Done", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<JsonResult> SaveConfiguraciones(List<Configuracion> configuraciones)
        {
            try
            {
                var result = await profilerService.GetInstancia().ProConfiguracion.SaveConfiguraciones(configuraciones, KeyConnection);
                return Json(new { result = true, message = "Configuración guardada", data = result });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public JsonResult SaveLogoEmpresa(IFormFile logo)
        {
            try
            {
                return Json(new { });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message, data = "null" });
            }
        }

        #endregion ActionMethod
    }
}