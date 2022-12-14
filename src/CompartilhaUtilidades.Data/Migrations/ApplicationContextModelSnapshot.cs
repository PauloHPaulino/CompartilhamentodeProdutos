// <auto-generated />
using System;
using CompartilhaUtilidades.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompartilhaUtilidades.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompartilhaUtilidades.Model.Entities.ContatoTelefone", b =>
                {
                    b.Property<int>("IdContatoTelefone")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUsuario");

                    b.Property<string>("TelefoneCelular")
                        .IsRequired();

                    b.Property<string>("TelefoneFixo");

                    b.Property<string>("TelefoneRecado");

                    b.HasKey("IdContatoTelefone");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("CompartilhaUtilidades.Model.Entities.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<int>("IdUsuario");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Numero");

                    b.Property<string>("TipoResidencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("IdEndereco");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("CompartilhaUtilidades.Model.Entities.Imagem", b =>
                {
                    b.Property<int>("IdImagem")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdProduto");

                    b.Property<string>("Legenda");

                    b.Property<string>("Url");

                    b.HasKey("IdImagem");

                    b.HasIndex("IdProduto");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("CompartilhaUtilidades.Model.Entities.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acao")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("DataInclusao");

                    b.Property<string>("Descricao");

                    b.Property<int>("IdUsuario");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("IdProduto");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("CompartilhaUtilidades.Model.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CodigoUsuarioEmail")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<DateTime>("DataDoCadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("EmailValidado");

                    b.Property<string>("Hash")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CompartilhaUtilidades.Model.Entities.ContatoTelefone", b =>
                {
                    b.HasOne("CompartilhaUtilidades.Model.Entities.Usuario", "Usuario")
                        .WithMany("Contatos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompartilhaUtilidades.Model.Entities.Endereco", b =>
                {
                    b.HasOne("CompartilhaUtilidades.Model.Entities.Usuario", "Usuario")
                        .WithMany("Endereco")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompartilhaUtilidades.Model.Entities.Imagem", b =>
                {
                    b.HasOne("CompartilhaUtilidades.Model.Entities.Produto", "Produto")
                        .WithMany("Imagens")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompartilhaUtilidades.Model.Entities.Produto", b =>
                {
                    b.HasOne("CompartilhaUtilidades.Model.Entities.Usuario", "Usuario")
                        .WithMany("Produtos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
