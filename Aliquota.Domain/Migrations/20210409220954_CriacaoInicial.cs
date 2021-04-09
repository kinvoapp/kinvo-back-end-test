using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    Rentabilidade_Mes = table.Column<double>(type: "REAL", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resgates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lucro = table.Column<double>(type: "REAL", nullable: false),
                    Valor_IR = table.Column<double>(type: "REAL", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AplicacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resgates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resgates_Aplicacoes_AplicacaoId",
                        column: x => x.AplicacaoId,
                        principalTable: "Aplicacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resgates_AplicacaoId",
                table: "Resgates",
                column: "AplicacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resgates");

            migrationBuilder.DropTable(
                name: "Aplicacoes");
        }
    }
}
