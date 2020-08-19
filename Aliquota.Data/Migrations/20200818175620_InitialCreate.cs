using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AplicacoesRF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    DataAplicacao = table.Column<DateTime>(nullable: true),
                    DataResgate = table.Column<DateTime>(nullable: true),
                    ValorAplicado = table.Column<decimal>(nullable: false),
                    TaxaJurosAnual = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacoesRF", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacoesRF");
        }
    }
}
