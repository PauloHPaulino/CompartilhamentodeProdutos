using System.Threading.Tasks;

namespace CompartilhaUtilidades.Model.Interfaces
{
    public interface IUnitOfWork
    {
		IUsuarioRepository UsuarioRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
