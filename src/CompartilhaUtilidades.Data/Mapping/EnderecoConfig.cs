using CompartilhaUtilidades.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompartilhaUtilidades.Data.Mapping
{
    public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(t => t.IdEndereco);
            builder.Property(t => t.IdEndereco);
            builder.Property(t => t.Logradouro)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.Numero).IsRequired();
            builder.Property(t => t.TipoResidencia)
                .HasMaxLength(20)
                .HasConversion<string>()
                .IsRequired();
            builder.Property(t => t.Bairro)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.Cep)
                .HasMaxLength(9)
                .IsRequired();
            builder.Property(t => t.Cidade)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.Estado)
                .HasMaxLength(2)
                .IsRequired();
            builder.HasOne(bc => bc.Usuario)
                   .WithMany(b => b.Endereco)
                   .HasForeignKey(bc => bc.IdUsuario);
        }
    }
}
