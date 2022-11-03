using CompartilhaUtilidades.Model.Entities;
using CompartilhaUtilidades.Model.Interfaces;

namespace CompartilhaUtilidades.Data.Repositories
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        private readonly ApplicationContext _context;
        public ProdutoRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
