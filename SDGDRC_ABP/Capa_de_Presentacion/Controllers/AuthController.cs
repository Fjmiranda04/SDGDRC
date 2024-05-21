<<<<<<< HEAD
﻿using Capa_de_Datos.Models;
=======
﻿using Capa_de_Datos.Models.ModelsDTO;
using Capa_de_Datos.Models;
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
using Capa_de_Negocios.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Capa_de_Datos.Models.ViewModels;
=======
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7

namespace Capa_de_Presentacion.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuario = await _authService.Login(model.Email, model.Password);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                return View(model);
            }

            // Autenticación exitosa, generar token de acceso
            var token = await _authService.GenerarTokenAcceso(usuario);

            // Aquí podrías almacenar el token en una cookie, en la sesión, o en cualquier otro lugar según tus necesidades

            // Redirigir a la página de inicio o a cualquier otra página deseada
<<<<<<< HEAD
            return RedirectToAction("DashboardAdmin", "Home");
=======
            return RedirectToAction("Index", "Home");
>>>>>>> ba3530e52b780c9f309df0acce60ad2366138fa7
        }
    }




}
