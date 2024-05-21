using AutoMapper;
using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Services;
using GeneralLedger.SelfServiceCore.Services.Profilers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguracionService configuracionService;
        private readonly IEmpresaService empresaService;
        private readonly IEmailConfiguracionService emailConfiguracionService;
        private readonly ISolicitudClienteService solicitudClienteService;
        private readonly IUsuarioEmpresaService usuarioEmpresaService;
        private readonly IProfilerService profilerService;
        private readonly IMail mail;
        private readonly IMapper mapper;

        public RegisterModel
        (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IEmpresaService empresaService,
            IMail mail, IMapper mapper,
            IConfiguracionService configuracionService,
            IEmailConfiguracionService emailConfiguracionService,
            ISolicitudClienteService solicitudClienteService,
            IUsuarioEmpresaService usuarioEmpresaService,
            IProfilerService profilerService
        )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._logger = logger;
            this._emailSender = emailSender;
            this.empresaService = empresaService;
            this.mail = mail;
            this.mapper = mapper;
            this.configuracionService = configuracionService;
            this.emailConfiguracionService = emailConfiguracionService;
            this.solicitudClienteService = solicitudClienteService;
            this.usuarioEmpresaService = usuarioEmpresaService;
            this.profilerService = profilerService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Este dato es requerido.")]
            [EmailAddress(ErrorMessage = "Dirección de correo inválida.")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            [StringLength(100, ErrorMessage = "La contraseña debe contener mínimo {2} y máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar Contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y su confirmación no son iguales.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Ingrese un NIT válido.")]
            [Display(Name = "Nit (sin DV)")]
            public string NitEmpresa { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            [StringLength(39, ErrorMessage = "El nombre debe contener mínimo {2} y maximo {1} caracteres.", MinimumLength = 2)]
            public string PriNombre { get; set; }

            public string SegNombre { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            [StringLength(39, ErrorMessage = "Los apellido deben contener mínimo {2} y maximo {1} caracteres.", MinimumLength = 2)]
            public string PriApellido { get; set; }

            public string SegApellido { get; set; }
            public int IdEmpresa { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string TipoDoc { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Ingrese No. Documento valido")]
            public string NroId { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string Ciudad { get; set; }

            public string CodCiudad { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string Direccion { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Ingrese número de celular valido")]
            public string NumeroCelular { get; set; }

            [RegularExpression("([0-9]+)", ErrorMessage = "Ingrese número de telefono valido")]
            public string NumeroTelefono { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ViewData["Empresas"] = await empresaService.GetAll();
            ViewData["Ciudades"] = profilerService.GetInstancia().ProCiudades.GetAll().OrderBy(c => c.Ciunom);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var empresa = await profilerService.GetInstancia().ProEmpresa.GetEmpresa(Input.NitEmpresa.ToString(), "GLSELFSERVICE_KEY");

                if (empresa.Nit == null)
                {
                    ViewData["ErrorMessage"] = "Nit empresa no encontrado. Por favor verificar.";
                    ViewData["Empresas"] = await empresaService.GetAll();
                    ViewData["Ciudades"] = profilerService.GetInstancia().ProCiudades.GetAll().OrderBy(c => c.Ciunom);
                    return Page();
                }

                var userEmpresa = await profilerService.GetInstancia().ProEmpresa.GetUsuarioEmpresa(Input.Email.ToString(), "GLSELFSERVICE_KEY");

                if (userEmpresa.NroIde != null)
                {
                    ViewData["ErrorMessage"] = "Ya existe una cuenta registrada con esta información.";
                    ViewData["Empresas"] = await empresaService.GetAll();
                    ViewData["Ciudades"] = profilerService.GetInstancia().ProCiudades.GetAll().OrderBy(c => c.Ciunom);
                    return Page();
                }

                int idUsuarioEmpresa = 0;

                try
                {
                    var usuarioEmpresa = new UsuarioEmpresa()
                    {
                        IdEmpresa = empresa.Id,
                        NitEmpresa = empresa.Nit,
                        NroIde = Input.NroId,
                        Email = Input.Email
                    };

                    var resultNewUser = await profilerService.GetInstancia().ProEmpresa.SaveUsuarioEmpresa(usuarioEmpresa, "GLSELFSERVICE_KEY");

                    if (resultNewUser.NroIde != null)
                    {
                        idUsuarioEmpresa = resultNewUser.Id;

                        string PasswordHash = "";

                        using (MD5 md5 = MD5.Create())
                        {
                            byte[] inputBytes = Encoding.ASCII.GetBytes(Input.Password);
                            byte[] hashBytes = md5.ComputeHash(inputBytes);

                            // Convertir el hash byte array a una cadena hexadecimal
                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < hashBytes.Length; i++)
                            {
                                sb.Append(hashBytes[i].ToString("x2"));
                            }

                            PasswordHash = sb.ToString();
                        }

                        var solicitudCliente = new SolicitudCliente
                        {
                            Codigo = Input.NroId,
                            TipDoc = string.IsNullOrEmpty(Input.TipoDoc) ? "CC" : Input.TipoDoc,
                            NroIde = Input.NroId,
                            NombreCompleto = $"{Input.PriNombre} {Input.SegNombre} {Input.PriApellido} {Input.SegApellido}",
                            Ciudad = Input.Ciudad,
                            Direccion = string.IsNullOrEmpty(Input.Direccion) ? "" : Input.Direccion,
                            Celular = string.IsNullOrEmpty(Input.NumeroCelular) ? "" : Input.NumeroCelular,
                            Telefono = string.IsNullOrEmpty(Input.NumeroTelefono) ? "" : Input.NumeroTelefono,
                            Email = Input.Email,
                            Estado = "1",
                            Password = PasswordHash,
                            FechaCreacion = DateTime.Now,
                            NitEmpresa = Input.NitEmpresa,
                            PrimerNombre = Input.PriNombre,
                            SegundoNombre = string.IsNullOrEmpty(Input.SegNombre) ? "" : Input.SegNombre,
                            PrimerApellido = Input.PriApellido,
                            SegundoApellido = string.IsNullOrEmpty(Input.SegApellido) ? "" : Input.SegApellido
                        };

                        var resultnewSolicitud = await profilerService.GetInstancia().proSolicitudUsuario.SaveSolicitudCliente(solicitudCliente, empresa.KeyConnection);

                        if (resultnewSolicitud != null)
                        {
                            var configuracionGeneral = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracion("PRINCIPAL_EMAILS", empresa.KeyConnection);

                            var destinatarios = configuracionGeneral.Valor.ToString().Split(",").ToList();

                            var emailConfiguracion = await profilerService.GetInstancia().ProConfiguracion.GetConfiguracionEmail("REQUEST_NEW_USER", empresa.KeyConnection);
                            var body = BuildBodyEmail(emailConfiguracion.Cuerpo, Input);

                            mail.SendMail(body, destinatarios, emailConfiguracion);

                            return RedirectToPage("UserConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = "¡Ha ocurrido un error inesperado, por favor vuelva a intentar!";
                    ViewData["Empresas"] = await empresaService.GetAll();
                    ViewData["Ciudades"] = profilerService.GetInstancia().ProCiudades.GetAll().OrderBy(c => c.Ciunom);
                    await profilerService.GetInstancia().ProEmpresa.RemoveUsuarioEmpresa(idUsuarioEmpresa, "GLSELFSERVICE_KEY");
                    return Page();
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "¡Faltan campos por llenar!";
                ViewData["Empresas"] = await empresaService.GetAll();
                ViewData["Ciudades"] = profilerService.GetInstancia().ProCiudades.GetAll().OrderBy(c => c.Ciunom);
                return Page();
            }

            // If we got this far, something failed, redisplay form
            return RedirectToPage("Register");
        }

        private async Task<UsuarioEmpresa> SaveUsuarioEmpresa(UsuarioEmpresaCreateDTO usuarioEmpresaCreateDTO)
        {
            return await usuarioEmpresaService.Insert(mapper.Map<UsuarioEmpresa>(usuarioEmpresaCreateDTO));
        }

        private async Task<SolicitudCliente> SaveSolicitudCliente(SolicitudClienteCreateDTO solicitudClienteCreateDTO, string connectionString)
        {
            return await solicitudClienteService.InsertChangeDbContext(mapper.Map<SolicitudCliente>(solicitudClienteCreateDTO), connectionString);
        }

        private string BuildBodyEmail(string body, InputModel model)
        {
            body = body.Replace("<<TIPDOC>>", model.TipoDoc);
            body = body.Replace("<<NUMDOC>>", model.NroId);
            body = body.Replace("<<NOMBRE>>", $"{model.PriNombre} {model.SegNombre}");
            body = body.Replace("<<APELLIDOS>>", $"{model.PriApellido} {model.SegApellido}");
            body = body.Replace("<<CIUDAD>>", model.Ciudad);
            body = body.Replace("<<DIRECCION>>", model.Direccion);
            body = body.Replace("<<CELULAR>>", model.NumeroCelular);
            body = body.Replace("<<TELEFONO>>", model.NumeroTelefono);
            body = body.Replace("<<EMAIL>>", model.Email);
            return body;
        }
    }
}