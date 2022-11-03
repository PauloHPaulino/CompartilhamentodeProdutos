using CompartilhaUtilidades.Model.Dtos;
using CompartilhaUtilidades.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompartilhaUtilidades.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ProdutoDto CompartilharProduto(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResultadoDto> Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProdutoDto> Filtrar(int idUsuario) => _unitOfWork
             .ProdutoRepository
             .Get(null, o => o.OrderBy(u => u.DataInclusao), "Imagens,Usuario", true)
             .Where(x => x.IdUsuario.Equals(idUsuario))
             .Select(s => new ProdutoDto
             {
                 IdProduto = s.IdProduto,
                 Categoria = s.Categoria,
                 Acao = s.Acao,
                 Descricao = s.Descricao,
                 Titulo = s.Titulo
             });

        public Task<ResultadoDto> Incluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResultadoDto> Salvar(ProdutoDto usuario)
        {
            throw new System.NotImplementedException();
        }

        public ProdutoDto Selecionar(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
