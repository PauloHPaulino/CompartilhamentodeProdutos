using CompartilhaUtilidades.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompartilhaUtilidades.Model.Interfaces
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoDto> Filtrar(int idUsuario);
        ProdutoDto Selecionar(int id);
        Task<ResultadoDto> Incluir(int id);
        Task<ResultadoDto> Excluir(int id);
        Task<ResultadoDto> Salvar(ProdutoDto usuario);
        ProdutoDto CompartilharProduto(int id);
    }
}
