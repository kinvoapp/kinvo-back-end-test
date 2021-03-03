using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class Initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAplicacao = table.Column<DateTime>(nullable: false),
                    DataResgate = table.Column<DateTime>(nullable: false),
                    QuantiaInicial = table.Column<decimal>(nullable: false),
                    QuantiaFinal = table.Column<decimal>(nullable: false),
                    Lucro = table.Column<decimal>(nullable: false),
                    Juros = table.Column<decimal>(nullable: false),
                    ValorFinalDeduzidoINSS = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacao");
        }
    }
}
