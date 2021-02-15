using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Server.Migrations
{
    public partial class adicionandocampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeriodoPrevistoAplicadoEmMeses",
                table: "Aplicacaos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodoPrevistoAplicadoEmMeses",
                table: "Aplicacaos");
        }
    }
}
