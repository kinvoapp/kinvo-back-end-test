using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Aliquota.Domain.Migrations
{
    public partial class Criar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Cliente = table.Column<string>(type: "text", nullable: false),
                    Lucro = table.Column<double>(type: "double", nullable: false),
                    TempoEmDias = table.Column<int>(type: "int", nullable: false),
                    TempoEmAnos = table.Column<int>(type: "int", nullable: false),
                    DataDeInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataDeResgate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investimentos");
        }
    }
}
