using Microsoft.AspNetCore.Mvc;
using App_DVP.Models;
using App_DVP.Recursos;
using App_DVP.Servicios.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.AccessControl;
using Microsoft.VisualBasic;

namespace App_DVP.Controllers
{
    public class Inicio : Controller
    {
        private readonly IUsuarioService _usuarioServicio;

        public Inicio(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(EntidadPersona modelo)
        {
            //modelo.NuevaContrasena = Utilidades.ClaveSegura(modelo.NuevaContrasena);

            EntidadPersona usuarioCreate = await _usuarioServicio.SavePersona(modelo);

            //var resultado = await this.RegistrarUsuario(new EntidadUsuario());
            var usuarioModelo = new EntidadUsuario();
            await RegistrarUsuario(usuarioModelo);

            if (usuarioCreate.Identificador > 0)
            {
                return RedirectToAction("InicioSesion", "Inicio");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(EntidadUsuario modelo)
        {
            //modelo.Pass = Utilidades.ClaveSegura(modelo.Pass);

            EntidadUsuario usuarioCreate = await _usuarioServicio.SaveUsuario(modelo);

            if (usuarioCreate.Identificador > 0)
            {
                return RedirectToAction("InicioSesion", "Inicio");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult InicioSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InicioSesion(string user, string pass)
        {
            EntidadUsuario usuarioFound = await _usuarioServicio.GetUsuario(user, pass);

            if (usuarioFound == null)
            {
                ViewData["Mensaje"] = "No se encontro registros";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioFound.Usuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity),
               properties
            );

            return RedirectToAction("Index", "Home");
        }
            
    }
    
}
