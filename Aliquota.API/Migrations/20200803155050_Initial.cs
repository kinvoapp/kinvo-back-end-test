using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carteira",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacaoCarteira = table.Column<DateTime>(nullable: false),
                    NomeCliente = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    TaxaAnual = table.Column<decimal>(nullable: false),
                    Vencimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ValorInvestimento = table.Column<decimal>(nullable: false),
                    ValorLucro = table.Column<decimal>(nullable: false),
                    DataInvestimento = table.Column<DateTime>(nullable: false),
                    DataRetornado = table.Column<DateTime>(nullable: false),
                    ProdutoId = table.Column<long>(nullable: false),
                    CarteiraId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investimento_Carteira_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Carteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investimento_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investimento_CarteiraId",
                table: "Investimento",
                column: "CarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Investimento_ProdutoId",
                table: "Investimento",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investimento");

            migrationBuilder.DropTable(
                name: "Carteira");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
