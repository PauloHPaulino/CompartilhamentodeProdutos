using CompartilhaUtilidades.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompartilhaUtilidades.Data.Mapping
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(t => t.IdProduto);
            builder.Property(t => t.IdProduto);
            builder.Property(t => t.Titulo)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(t => t.Descricao);
            builder.Property(t => t.Acao);
            builder.Property(t => t.Categoria);
            builder.Property(t => t.DataInclusao);
            builder.HasMany(t => t.Imagens)
                   .WithOne();
            builder.HasOne(bc => bc.Usuario)
                 .WithMany(b => b.Produtos)
                 .HasForeignKey(bc => bc.IdUsuario);
        }
    }
}

