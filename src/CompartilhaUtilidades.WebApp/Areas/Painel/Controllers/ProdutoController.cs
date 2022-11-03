using CompartilhaUtilidades.Model.Dtos;
using CompartilhaUtilidades.Model.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CompartilhaUtilidades.WebApp.Areas.Painel.Controllers
{
    [Area("Painel")]
    //[Authorize]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public ActionResult Index(List<IFormFile> file)
        {
            if (file != null)
                try
                {
                   var filePath = Path.GetTempFileName();
                                 

                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }
        public IActionResult Consultar()
        {
            var idUsuario = HttpContext.User.Claims.FirstOrDefault().Value;
            var service = _produtoService.Filtrar(Convert.ToInt32(idUsuario));
            var resultado = new List<ProdutoDto>
            {
                new ProdutoDto
                {
                    IdProduto = 1,
                    Titulo = "teste"
                },
                new ProdutoDto
                {
                    IdProduto = 2,
                    Titulo = "teste2"
                }
            };
            return View(resultado);
        }


        public IActionResult Novo()
        {
            //aqui defino o título da página
            ViewData["Title"] = "Inclua o Novo Produto!";
            // aqui é o tipo de view (Produto\Salvar) que vai cadastrar e o tipo que será cadastrado
            return View("Salvar", new ProdutoDto());
        }

        public IActionResult Editar(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SalvarAsync(ProdutoDto produtoDto)
        {
            return View();

        }

        public async Task<IActionResult> ExcluirAsync(int id)
        {
            return View();
        }
    }
}