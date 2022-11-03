using CompartilhaUtilidades.Data.Mapping;
using CompartilhaUtilidades.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CompartilhaUtilidades.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly ILogger<ApplicationContext> _logger;
        public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<ContatoTelefone>Contatos { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Imagem> Imagens { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options, ILogger<ApplicationContext> logger)
			: base(options)
		{
            _logger = logger;
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            _logger.Log(LogLevel.Information, "OnModelCreating...");
			modelBuilder.ApplyConfiguration(new UsuarioConfig());
			modelBuilder.ApplyConfiguration(new ContatoConfig());
			modelBuilder.ApplyConfiguration(new EnderecoConfig());
			modelBuilder.ApplyConfiguration(new ProdutoConfig());
			modelBuilder.ApplyConfiguration(new ImagemConfig());
		}
	}
}
