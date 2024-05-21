using AutoMapper;
using Common;
using GeneralLedger.SelfService.Web.Areas.Identity.Data;
using GeneralLedger.SelfServiceCore.Data;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using GeneralLedger.SelfServiceCore.Data.Models;
using GeneralLedger.SelfServiceCore.Data.ModelsGL;
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
using System.Threading.Tasks;

namespace GeneralLedger.SelfService.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterProveedorModel : PageModel
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

        public RegisterProveedorModel
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

            [Required(ErrorMessage = "Este dato es requerido")]
            public string TipoDoc { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Ingrese No. Documento valido")]
            public string NitProveedor { get; set; }

            [Required(ErrorMessage = "Este dato es requerido.")]
            [StringLength(100, ErrorMessage = "El nombre debe contener mínimo {2} y maximo {1} caracteres.", MinimumLength = 2)]
            public string RazonSocial { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string Direccion { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string Ciudad { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string Telefono { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string Fax { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string RepLegal { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string CedRepLegal { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string ContactoRepLegal { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string CargoLegal { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public int IsRUP { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string NumeroRUT { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public DateTime FechaVencimientoRUT { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public DateTime FechaInscripcionRUT { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public int IsCertificadoEstablecimientoComercio { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public string NumeroMatriculaMercantil { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public int TipoBienServicio { get; set; }

            [Required(ErrorMessage = "Este dato es requerido")]
            public int TipoActividadComercial { get; set; }

            public int IdEmpresa { get; set; }

            /**/
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
                try
                {
                    var empresa = await empresaService.GetEmpresaByNit(Input.NitEmpresa.ToString());

                    if (empresa == null)
                    {
                        ViewData["ErrorMessage"] = "Nit empresa no encontrado. Por favor verificar.";
                        ViewData["Empresas"] = await empresaService.GetAll();
                        ViewData["Ciudades"] = profilerService.GetInstancia().ProCiudades.GetAll().OrderBy(c => c.Ciunom);
                        return Page();
                    }

                    var userEmpresa = await usuarioEmpresaService.GetUsuarioByEmail(Input.Email);

                    if (userEmpresa != null)
                    {
                        ViewData["ErrorMessage"] = "Ya existe una cuenta registrada con esta información.";
                        ViewData["Empresas"] = await empresaService.GetAll();
                        ViewData["Ciudades"] = profilerService.GetInstancia().ProCiudades.GetAll().OrderBy(c => c.Ciunom);
                        return Page();
                    }

                    var newUsuarioEmpresa = new UsuarioEmpresaCreateDTO()
                    {
                        IdEmpresa = empresa.Id,
                        NitEmpresa = empresa.Nit,
                        NroIde = Input.NitProveedor,
                        Email = Input.Email
                    };

                    var resultNewUser = await SaveUsuarioEmpresa(newUsuarioEmpresa);

                    if (resultNewUser != null)
                    {
                        ConnectionTools.SetKeyConnectionStringDirect(empresa.KeyConnection);

                        var proponente = new AccglPro
                        {
                            Procargo = Input.CargoLegal,
                            ProCodCiud = Input.Ciudad,
                            Pronit1 = Input.NitProveedor,
                            Prodir = Input.Direccion,
                            Proced = Input.CedRepLegal,
                            Proconta = Input.ContactoRepLegal,
                            Promail = Input.Email,
                            Profax = Input.Fax,
                            InscrR = Input.FechaInscripcionRUT,
                            Fechav = Input.FechaVencimientoRUT,
                            IdProponente = 0,
                            IdEmpresa = empresa.Id,
                            Certie = Input.IsCertificadoEstablecimientoComercio,
                            Rup = Input.IsRUP,
                            NitEmpresa = Input.NitEmpresa,
                            Pronit = Input.NitProveedor,
                            Nummatri = Input.NumeroMatriculaMercantil,
                            Rut = Input.NumeroRUT,
                            Password = Input.Password,
                            Pronom = Input.RazonSocial,
                            Proreplegal = Input.RepLegal,
                            Protel = Input.Telefono,
                            Pronoactividad = Input.TipoActividadComercial,
                            Bienser = Input.TipoBienServicio,
                            TipDocu = Input.TipoDoc
                        };

                        var proponenteNew = await profilerService.GetInstancia().ProAccglpro.SaveProponente(proponente, empresa.KeyConnection);

                        if (proponenteNew != null)
                        {
                            var configuracionGeneral = await configuracionService.GetConfiguracionByKey("PRINCIPAL_EMAILS");
                            var destinatarios = configuracionGeneral.Valor.ToString().Split(",").ToList();

                            var emailConfiguracion = mapper.Map<EmailConfiguracionDTO>(await emailConfiguracionService.GetEmailConfiguracionByKey("REQUEST_NEW_USER"));

                            var body = BuildBodyEmail(emailConfiguracion.Cuerpo, Input);

                            // mail.SendMail(body, destinatarios, emailConfiguracion);

                            ConnectionTools.SetDefaultConnectionString();
                            return RedirectToPage("UserConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewData["Empresas"] = await empresaService.GetAll();
                    ViewData["Ciudades"] = profilerService.GetInstancia().ProCiudades.GetAll().OrderBy(c => c.Ciunom);
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["Empresas"] = await empresaService.GetAll();
            ViewData["Ciudades"] = profilerService.GetInstancia().ProCiudades.GetAll().OrderBy(c => c.Ciunom);
            return Page();
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
            return body;
        }
    }
}