using Capa_de_Datos.Models.ModelsDTO;
<<<<<<< HEAD
using Capa_de_Datos.Models.ViewModels;
=======
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
using Capa_de_Negocios.Service;
using Capa_de_Negocios.Service.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Capa_de_Presentacion.Controllers
{
    public class RutaController : Controller
    {
        private readonly IRutaService _rutaService;

        public RutaController(IRutaService rutaService)
        {
            _rutaService = rutaService;
        }

        // GET: Ruta


        public async Task<IActionResult> Index()
        {
            // Obtener la lista de rutas
            var rutas = await _rutaService.ObtenerTodasLasRutasAsync();
            // Obtener la lista de coordinadores y voluntarios
            var coordinadores = await _rutaService.ObtenerCoordinadoresAsync();
            var voluntarios = await _rutaService.ObtenerVoluntariosAsync();
            // Crear una lista de ViewModel para mostrar en la vista
            var viewModelList = new List<RutaIndexViewModel>();
            foreach (var ruta in rutas)
            {
                var coordinador = coordinadores.FirstOrDefault(c => c.IdCoordinador == ruta.CoordinadorId);
                var voluntario = voluntarios.FirstOrDefault(v => v.IdVoluntario == ruta.VoluntarioId);

                var viewModel = new RutaIndexViewModel
                {
                    Fecha = ruta.Fecha,
                    NombreCoordinador = coordinador != null ? coordinador.NombreCompleto : "Nombre no encontrado",
                    NombreVoluntario = voluntario != null ? voluntario.NombreCompleto : "Nombre no encontrado",
                    Latitud = ruta.Latitud,
                    Longitud = ruta.Longitud
                };

                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }




        // GET: Ruta/Crear
        public async Task<IActionResult> Crear()
        {
            // Obtener la lista de coordinadores y voluntarios y pasarlas a la vista
            var coordinadores = await _rutaService.ObtenerCoordinadoresAsync();
            var voluntarios = await _rutaService.ObtenerVoluntariosAsync();
            ViewBag.Coordinadores = coordinadores;
            ViewBag.Voluntarios = voluntarios;

            // Devolver la vista de creación de rutas
            return View();
        }

        // POST: Ruta/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(RutaDTO rutaDTO)
        {
            if (ModelState.IsValid)
            {
               /* // Validar que la latitud y longitud estén dentro del rango válido
                if (Math.Abs(rutaDTO.Latitud) > 90 || Math.Abs(rutaDTO.Longitud) > 180)
                {
                    ModelState.AddModelError("", "La latitud debe estar entre -90 y 90, y la longitud entre -180 y 180.");
                    return View(rutaDTO);
                }*/

                try
                {
                    // Llamar al servicio para crear la ruta
                    await _rutaService.CrearRutaAsync(rutaDTO);
                    return RedirectToAction("Index"); // Redirigir a la acción Index para mostrar la lista actualizada de rutas
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción y mostrar un mensaje de error en la vista
                    ModelState.AddModelError("", "Ocurrió un error al crear la ruta.");
                    // También puedes registrar la excepción o mostrar un mensaje de error más detallado según sea necesario
                }
            }
            // Si hay errores de validación o si ocurre algún error al crear la ruta, volver a mostrar el formulario con los errores
            // Además, necesitamos volver a cargar la lista de coordinadores y voluntarios para mostrarlas en la vista
            var coordinadores = await _rutaService.ObtenerCoordinadoresAsync();
            var voluntarios = await _rutaService.ObtenerVoluntariosAsync();
            ViewBag.Coordinadores = coordinadores;
            ViewBag.Voluntarios = voluntarios;
            return View(rutaDTO);
        }

    }
}