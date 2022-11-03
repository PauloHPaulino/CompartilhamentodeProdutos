using CompartilhaUtilidades.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompartilhaUtilidades.Data.Mapping
{
    public class ContatoConfig : IEntityTypeConfiguration<ContatoTelefone>
    {
        public void Configure(EntityTypeBuilder<ContatoTelefone> builder)
        {
            builder.ToTable("Contato");
            builder.HasKey(t => t.IdContatoTelefone);
            builder.Property(t => t.IdContatoTelefone);
            builder.Property(t => t.TelefoneCelular).IsRequired();
            builder.Property(t => t.TelefoneFixo);
            builder.Property(t => t.TelefoneRecado);
            builder.HasOne(bc => bc.Usuario)
                    .WithMany(b => b.Contatos)
                    .HasForeignKey(bc => bc.IdUsuario);
        }
    }
}
