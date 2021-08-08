using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class Infraestrutura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposProdutosFinanceiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    PorcentagemLucro = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProdutosFinanceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosFinanceiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ValorAplicado = table.Column<double>(type: "float", nullable: false),
                    ValorIR = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    DataAplicacao = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    DataResgate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TipoProdutoFinanceiroFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosFinanceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutosFinanceiros_TiposProdutosFinanceiros_TipoProdutoFinanceiroFK",
                        column: x => x.TipoProdutoFinanceiroFK,
                        principalTable: "TiposProdutosFinanceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposProdutosFinanceiros",
                columns: new[] { "Id", "Nome", "PorcentagemLucro" },
                values: new object[] { new Guid("ae6bb3f8-29c2-4482-82ac-228c3a7f4c13"), "CDB", 7.0 });

            migrationBuilder.InsertData(
                table: "TiposProdutosFinanceiros",
                columns: new[] { "Id", "Nome", "PorcentagemLucro" },
                values: new object[] { new Guid("c3802878-f908-4bdb-bfa6-5bb784cd8f57"), "Poupança", 3.0 });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosFinanceiros_TipoProdutoFinanceiroFK",
                table: "ProdutosFinanceiros",
                column: "TipoProdutoFinanceiroFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosFinanceiros");

            migrationBuilder.DropTable(
                name: "TiposProdutosFinanceiros");
        }
    }
}
