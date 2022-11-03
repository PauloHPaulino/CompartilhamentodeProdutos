using Microsoft.EntityFrameworkCore.Migrations;

namespace CompartilhaUtilidades.Data.Migrations
{
    public partial class Update_Table_Produto_Estrutura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Imagem",
                newName: "IdImagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdImagem",
                table: "Imagem",
                newName: "id");
        }
    }
}
