using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CompartilhaUtilidades.Model.Dtos;
using CompartilhaUtilidades.Model.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompartilhaUtilidades.WebApp.Areas.Painel.Controllers
{
    [Area("Painel")]
    public class SecureController : Controller
    {
        private readonly IUsuarioService _UsuarioService;

        public SecureController(IUsuarioService UsuarioService)
        {
            this._UsuarioService = UsuarioService;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginDto();
            return View(model);
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var usuario = this._UsuarioService.Autenticar(model);

                if (usuario != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Name, usuario.Nome),
                        new Claim(ClaimTypes.GivenName, usuario.Login)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(2)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    model = new LoginDto();

                    TempData["ErroAutenticacao"] = "Usuário ou senha inválido";
                    return View(model);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Secure");
        }
    }
}
