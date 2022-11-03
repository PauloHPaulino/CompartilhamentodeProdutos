using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompartilhaUtilidades.Data.Migrations
{
    public partial class AddDataNasciomentoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Usuario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeNascimento",
                table: "Usuario");
        }
    }
}
