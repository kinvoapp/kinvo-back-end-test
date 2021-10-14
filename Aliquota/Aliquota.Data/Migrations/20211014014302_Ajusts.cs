using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Data.Migrations
{
    public partial class Ajusts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorImposto",
                table: "ProdutosFinanceiros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorImposto",
                table: "ProdutosFinanceiros",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
