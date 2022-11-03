using Microsoft.EntityFrameworkCore.Migrations;

namespace CompartilhaUtilidades.Data.Migrations
{
    public partial class Altera_Mapeamento_Tabelas_Atualizadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagem_Produto_ProdutoIdProduto",
                table: "Imagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Usuario_UsuarioIdUsuario",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Usuario_UsuarioIdUsuario1",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_UsuarioIdUsuario",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_UsuarioIdUsuario1",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Imagem_ProdutoIdProduto",
                table: "Imagem");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario1",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ProdutoIdProduto",
                table: "Imagem");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Produto",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Produto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "Imagem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdUsuario",
                table: "Produto",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_IdProduto",
                table: "Imagem",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagem_Produto_IdProduto",
                table: "Imagem",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Usuario_IdUsuario",
                table: "Produto",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagem_Produto_IdProduto",
                table: "Imagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Usuario_IdUsuario",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_IdUsuario",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Imagem_IdProduto",
                table: "Imagem");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "Imagem");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Produto",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario1",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoIdProduto",
                table: "Imagem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_UsuarioIdUsuario",
                table: "Produto",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_UsuarioIdUsuario1",
                table: "Produto",
                column: "UsuarioIdUsuario1");

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_ProdutoIdProduto",
                table: "Imagem",
                column: "ProdutoIdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagem_Produto_ProdutoIdProduto",
                table: "Imagem",
                column: "ProdutoIdProduto",
                principalTable: "Produto",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Usuario_UsuarioIdUsuario",
                table: "Produto",
                column: "UsuarioIdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Usuario_UsuarioIdUsuario1",
                table: "Produto",
                column: "UsuarioIdUsuario1",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
