using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Infraestructure.Migrations
{
    public partial class InitialTableAliquota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AplicacaoFinanceira",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    ValorAplicado = table.Column<decimal>(nullable: false),
                    TaxaRendimento = table.Column<decimal>(nullable: false),
                    DataAplicacao = table.Column<DateTime>(nullable: false),
                    DataResgate = table.Column<DateTime>(nullable: true),
                    ValorRendimentoBruto = table.Column<double>(nullable: true),
                    ValorImpostoDeRendaRecolhido = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacaoFinanceira", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacaoFinanceira");
        }
    }
}
