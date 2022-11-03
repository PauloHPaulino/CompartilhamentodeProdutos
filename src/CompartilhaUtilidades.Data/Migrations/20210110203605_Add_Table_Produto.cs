using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompartilhaUtilidades.Data.Migrations
{
    public partial class Add_Table_Produto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Categoria = table.Column<int>(nullable: false),
                    Acao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    UsuarioIdUsuario1 = table.Column<int>(nullable: true),
                    UsuarioIdUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produto_Usuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_Usuario_UsuarioIdUsuario1",
                        column: x => x.UsuarioIdUsuario1,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Legenda = table.Column<string>(nullable: true),
                    ProdutoIdProduto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.id);
                    table.ForeignKey(
                        name: "FK_Imagem_Produto_ProdutoIdProduto",
                        column: x => x.ProdutoIdProduto,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_ProdutoIdProduto",
                table: "Imagem",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_UsuarioIdUsuario",
                table: "Produto",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_UsuarioIdUsuario1",
                table: "Produto",
                column: "UsuarioIdUsuario1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
