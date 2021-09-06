using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Renda = table.Column<double>(type: "float", nullable: false),
                    Lucro = table.Column<double>(type: "float", nullable: false),
                    DataAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataResgate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IOF = table.Column<double>(type: "float", nullable: true),
                    IR = table.Column<double>(type: "float", nullable: true),
                    ValorIR = table.Column<double>(type: "float", nullable: true),
                    Resgate = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
