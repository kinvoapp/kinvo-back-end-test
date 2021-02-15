using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Server.Migrations
{
    public partial class novoscampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Aplicacaos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorSacado",
                table: "Aplicacaos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Aplicacaos");

            migrationBuilder.DropColumn(
                name: "ValorSacado",
                table: "Aplicacaos");
        }
    }
}
