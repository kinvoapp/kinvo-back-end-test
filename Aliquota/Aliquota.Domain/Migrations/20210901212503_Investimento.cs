using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class Investimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    DataInvestimento = table.Column<DateTime>(type: "date", nullable: false),
                    DataResgate = table.Column<DateTime>(type: "date", nullable: true),
                    ValorInvestido = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorResgatado = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ImpostoRecolhido = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ImpostoFaixaAplicavel = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investimentos_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investimentos_ProdutoId",
                table: "Investimentos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investimentos");
        }
    }
}
