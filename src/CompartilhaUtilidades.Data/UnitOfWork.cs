using CompartilhaUtilidades.Data.Repositories;
using CompartilhaUtilidades.Model.Interfaces;
using System.Threading.Tasks;

namespace CompartilhaUtilidades.Data
{
	public class UnitOfWork : IUnitOfWork
    {
		public ApplicationContext Context { get; internal set; }

		private IUsuarioRepository usuarioRepository;

		private IProdutoRepository produtoRepository;

        public UnitOfWork(ApplicationContext context)
        {
			Context = context;
        }

		public IUsuarioRepository UsuarioRepository
		{
			get
			{
				if (usuarioRepository == null)
                {
                    usuarioRepository = new UsuarioRepository(Context);
                }

				return usuarioRepository;
			}
		}

		public IProdutoRepository ProdutoRepository
		{
			get
			{
				if (produtoRepository == null)
				{
					produtoRepository = new ProdutoRepository(Context);
				}

				return produtoRepository;
			}
		}
		  

        public async Task<bool> SaveChangesAsync()
		{
			return await Context.SaveChangesAsync() > 0;
		}
    }
}
