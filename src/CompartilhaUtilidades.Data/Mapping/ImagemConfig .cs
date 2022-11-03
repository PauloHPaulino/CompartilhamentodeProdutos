using CompartilhaUtilidades.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompartilhaUtilidades.Data.Mapping
{
    public class ImagemConfig : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.ToTable("Imagem");
            builder.HasKey(t => t.IdImagem);
            builder.Property(t => t.IdImagem);
            builder.Property(t => t.Legenda);
            builder.Property(t => t.Url);
            builder.HasOne(bc => bc.Produto)
                      .WithMany(b => b.Imagens)
                      .HasForeignKey(bc => bc.IdProduto);
        }
    }
}
