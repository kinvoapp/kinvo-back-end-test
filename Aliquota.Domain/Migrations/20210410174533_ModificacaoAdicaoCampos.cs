using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class ModificacaoAdicaoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Valor_Retirado",
                table: "Resgates",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Resgatada",
                table: "Aplicacoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor_Retirado",
                table: "Resgates");

            migrationBuilder.DropColumn(
                name: "Resgatada",
                table: "Aplicacoes");
        }
    }
}
