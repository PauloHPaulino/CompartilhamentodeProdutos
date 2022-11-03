    using CompartilhaUtilidades.Model.Interfaces;
using CompartilhaUtilidades.WebApp.Areas.Painel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CriandoAplicacaoAspNetCore.WebApp.Areas.Painel.Controllers
{
    [Area("Painel")]

    public class HomeController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public HomeController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        
        public IActionResult Index()
        {
            TempData["NomeUsuario"] = HttpContext.User.Identity.Name;
            return View();
        }

        [AllowAnonymous]
        [Route("ConfirmaEmail/{idConfirmacao}")]
        public async Task<IActionResult> ConfirmaEmail(Guid idConfirmacao)
        {
            var resultado = new ResultadoViewModel();
            try
            {
                resultado.Sucesso = await _usuarioService.ConfirmarEmail(idConfirmacao);
            }
            catch (Exception ex)
            {
                resultado.Erro = new List<string> { ex.Message };
            }

            return View(resultado);
        }
    }
}
