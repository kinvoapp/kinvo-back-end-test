using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<double>(nullable: false),
                    dataAplicacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<double>(nullable: false),
                    dataResgate = table.Column<DateTime>(nullable: false),
                    dataAplicacao = table.Column<DateTime>(nullable: false),
                    ir = table.Column<double>(nullable: false),
                    lucro = table.Column<double>(nullable: false),
                    aliquota = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Aplicacao",
                columns: new[] { "Id", "dataAplicacao", "valor" },
                values: new object[] { 1, new DateTime(1999, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000.0 });

            migrationBuilder.InsertData(
                table: "IR",
                columns: new[] { "Id", "aliquota", "dataAplicacao", "dataResgate", "ir", "lucro", "valor" },
                values: new object[] { 1, 0.14999999999999999, new DateTime(1999, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 290.39999999999998, 1936.0, 1000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacao");

            migrationBuilder.DropTable(
                name: "IR");
        }
    }
}
