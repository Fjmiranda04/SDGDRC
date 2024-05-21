using Capa_de_Presentacion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
using Capa_de_Negocios.Service; // Importa este namespace

namespace Capa_de_Presentacion.Controllers
{

=======
using Microsoft.AspNetCore.Authorization; // Importa este namespace

namespace Capa_de_Presentacion.Controllers
{
    
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
<<<<<<< HEAD
        private readonly IUsuarioService _usuarioService;
        private readonly IRutaService _rutaService;

        public HomeController(ILogger<HomeController> logger, IUsuarioService usuarioService,IRutaService rutaService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _rutaService = rutaService;
=======

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
        }

        // Esta acción requerirá que el usuario haya iniciado sesión
        public IActionResult Index()
        {
            return View();
        }

<<<<<<< HEAD
        public async Task<IActionResult> DashboardAdmin()
        {
            var userCount = await _usuarioService.ContarUsuarioAsync();
            var rutaCount = await _rutaService.ContarRutasAsync();
            ViewBag.UserCount = userCount;
            ViewBag.RutaCount = rutaCount;
            return View();
        }

=======
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
        // Otras acciones aquí...

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

<<<<<<< HEAD

=======
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
}
