using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoFinanceiro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rendimento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoFinanceiro", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Aplicacao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoFinanceiro_ID = table.Column<int>(type: "int", nullable: false),
                    Cliente_ID = table.Column<int>(type: "int", nullable: false),
                    DataAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRetirada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: true),
                    InvestidorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aplicacao_Cliente_InvestidorID",
                        column: x => x.InvestidorID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aplicacao_ProdutoFinanceiro_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "ProdutoFinanceiro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacao_InvestidorID",
                table: "Aplicacao",
                column: "InvestidorID");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacao_ProdutoID",
                table: "Aplicacao",
                column: "ProdutoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ProdutoFinanceiro");
        }
    }
}
