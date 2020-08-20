using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.AppConSql.Migrations
{
    public partial class CreaSqlDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Rendimentos",
                columns: table => new
                {
                    RendimentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "Date", nullable: false),
                    Percentual = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rendimentos", x => x.RendimentoId);
                });

            migrationBuilder.CreateTable(
                name: "Aplicacoes",
                columns: table => new
                {
                    AplicacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataMov = table.Column<DateTime>(type: "Date", nullable: false),
                    ValorAplicado = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DataAtual = table.Column<DateTime>(type: "Date", nullable: false),
                    ValorAtual = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacoes", x => x.AplicacaoId);
                    table.ForeignKey(
                        name: "FK_Aplicacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resgates",
                columns: table => new
                {
                    ResgateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataMov = table.Column<DateTime>(type: "Date", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IR = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resgates", x => x.ResgateId);
                    table.ForeignKey(
                        name: "FK_Resgates_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_ClienteId",
                table: "Aplicacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Rendimentos_Data",
                table: "Rendimentos",
                column: "Data",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resgates_ClienteId",
                table: "Resgates",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacoes");

            migrationBuilder.DropTable(
                name: "Rendimentos");

            migrationBuilder.DropTable(
                name: "Resgates");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
