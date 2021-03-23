using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class TesteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicacao",
                columns: table => new
                {
                    AplicacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValorInicial = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataAplicada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataRetirada = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ValorFinalBruto = table.Column<decimal>(type: "TEXT", nullable: true),
                    ValorImpostoRenda = table.Column<decimal>(type: "TEXT", nullable: true),
                    ValorLucroLiquido = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacao", x => x.AplicacaoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacao");
        }
    }
}
