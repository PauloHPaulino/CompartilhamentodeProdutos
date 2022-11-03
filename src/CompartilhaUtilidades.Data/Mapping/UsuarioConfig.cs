using CompartilhaUtilidades.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompartilhaUtilidades.Data.Mapping
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(t => t.IdUsuario);
            builder.Property(t => t.IdUsuario);
            builder.Property(t => t.Nome)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(t => t.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.Login)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(t => t.Hash).IsRequired();
            builder.Property(t => t.Salt).IsRequired();
            builder.Property(t => t.CodigoUsuarioEmail)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.Sexo)
                .HasMaxLength(20)
                .HasConversion<string>();
            builder.Property(t => t.DataDeNascimento)
                .IsRequired();
            builder.Property(t => t.DataDoCadastro);
            builder.Property(t => t.EmailValidado);
            builder.HasMany(t => t.Endereco)
                   .WithOne();
            builder.HasMany(t => t.Contatos)
                   .WithOne();
            builder.HasMany(t => t.Produtos)
                   .WithOne();

        }
    }
}
