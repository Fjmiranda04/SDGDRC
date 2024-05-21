using System.Threading.Tasks;
using Capa_de_Datos.Models;
using Capa_de_Datos.Models.ModelsDTO;
using Capa_de_Negocios.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capa_de_Presentacion.Controllers
{
    
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Acción para mostrar la lista de usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.ObtenerTodosLosUsuarios();
            return View(usuarios);
        }

        // Acción para mostrar los detalles de un usuario específico
        public async Task<IActionResult> Detalles(int id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            var usuarioDto = new UsuarioCreateDTO();
            return View(usuarioDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(UsuarioCreateDTO usuarioDto)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.CrearUsuario(usuarioDto);
                return RedirectToAction("Index", "Usuario"); // Redireccionar a la página de inicio después de crear el usuario
            }
            return View(usuarioDto);
        }

<<<<<<< HEAD
        [HttpGet]
        public async Task<IActionResult> GetUserCount()
        {
            var userCount = await _usuarioService.ContarUsuarioAsync();
            return Json(new { userCount });
        }

=======
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7


        // Acción para mostrar el formulario de edición de usuario
        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // Acción para procesar el formulario de edición de usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _usuarioService.ActualizarUsuario(usuario);
                }
                catch
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // Acción para mostrar el formulario de confirmación de eliminación de usuario
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // Acción para procesar la eliminación de un usuario
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            await _usuarioService.EliminarUsuario(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
