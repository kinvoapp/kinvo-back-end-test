using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Data.Migrations
{
    public partial class AjustMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carteiras_Clientes_ClienteId",
                table: "Carteiras");

            migrationBuilder.DropTable(
                name: "Extratos");

            migrationBuilder.DropIndex(
                name: "IX_Carteiras_ClienteId",
                table: "Carteiras");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Carteiras");

            migrationBuilder.AddColumn<int>(
                name: "CarteiraId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ComprovantesResgates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorResgate = table.Column<double>(type: "float", nullable: false),
                    ValorDoImposto = table.Column<double>(type: "float", nullable: false),
                    DataResgate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodoInvestimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarteiraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprovantesResgates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprovantesResgates_Carteiras_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Carteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CarteiraId",
                table: "Clientes",
                column: "CarteiraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComprovantesResgates_CarteiraId",
                table: "ComprovantesResgates",
                column: "CarteiraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Carteiras_CarteiraId",
                table: "Clientes",
                column: "CarteiraId",
                principalTable: "Carteiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Carteiras_CarteiraId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "ComprovantesResgates");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CarteiraId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CarteiraId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Carteiras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Extratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarteiraId = table.Column<int>(type: "int", nullable: true),
                    DataResgate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodoInvestimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorDoImposto = table.Column<double>(type: "float", nullable: false),
                    ValorResgate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extratos_Carteiras_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Carteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carteiras_ClienteId",
                table: "Carteiras",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Extratos_CarteiraId",
                table: "Extratos",
                column: "CarteiraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carteiras_Clientes_ClienteId",
                table: "Carteiras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
