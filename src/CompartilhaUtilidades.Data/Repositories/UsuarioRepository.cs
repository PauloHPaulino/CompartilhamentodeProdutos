using CompartilhaUtilidades.Model.Entities;
using CompartilhaUtilidades.Model.Interfaces;

namespace CompartilhaUtilidades.Data.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationContext _context;
        public UsuarioRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }

        //public async Task<Usuario> PesquisaPorNome(string nome)
        //{
        //    await _context.Set<Usuario>().FirstOrDefaultAsync(x => x.Nome.Contains(nome));
        //}
    }
}
