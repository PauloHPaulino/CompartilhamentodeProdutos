using CompartilhaUtilidades.Model.Dtos;
using CompartilhaUtilidades.Model.Interfaces;
using CompartilhaUtilidades.WebApp.Areas.Painel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompartilhaUtilidades.WebApp.Areas.Painel.Controllers
{
    [Area("Painel")]
    //[Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioController(IUsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        public IActionResult Consultar()
        {
                var usuarios = _UsuarioService.Filtrar();

            return View(usuarios);
        }

        public IActionResult Novo()
        {
            ViewData["Title"] = "Novo Usuário";
            return View("Salvar", new UsuarioDto());
        }

        public IActionResult Editar(int id)
        {
            var usuario = _UsuarioService.Selecionar(id);
            ViewData["Title"] = "Editar Usuário";
            return View("Salvar", usuario);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarAsync(UsuarioDto usuarioDto)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _UsuarioService.Salvar(usuarioDto);
                return Json(new ResultadoViewModel
                {
                    Sucesso = resultado.Sucesso,
                    Id = resultado.Id,
                    Url = Url.Action("Consultar"),
                    Erro = resultado.Erros
                });
            }
            var erros =  ModelState.Select(x => x.Value.Errors).Where(y => y.Count() > 0).Select(z => z.ToArray());
            var listError = new List<string>();
            foreach(var index in erros)
            {
                listError.Add(index.First().ErrorMessage);
            }
            return Json(new ResultadoViewModel
            {
                Sucesso = false,
                Id = 0,
                Url = Url.Action("Consultar"),
                Erro = listError
            });
        }

        public async Task<IActionResult> ExcluirAsync(int id)
        {
            var resultado = await _UsuarioService.Excluir(id);
            return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso,
                Url = Url.Action("Consultar")
            });
        }
    }
}