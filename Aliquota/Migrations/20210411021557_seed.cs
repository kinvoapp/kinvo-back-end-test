using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aplicacao",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Aplicacao",
                columns: new[] { "Id", "dataAplicacao", "valor" },
                values: new object[] { 2, new DateTime(1999, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000.0 });

            migrationBuilder.InsertData(
                table: "Aplicacao",
                columns: new[] { "Id", "dataAplicacao", "valor" },
                values: new object[] { 3, new DateTime(1999, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aplicacao",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Aplicacao",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Aplicacao",
                columns: new[] { "Id", "dataAplicacao", "valor" },
                values: new object[] { 1, new DateTime(1999, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000.0 });
        }
    }
}
