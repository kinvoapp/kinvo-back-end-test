using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Data.Migrations
{
    public partial class AdicionarCamposProdutoFinanceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Aplicacao",
                table: "ProdutosFinanceiros",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAplicacao",
                table: "ProdutosFinanceiros",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataResgate",
                table: "ProdutosFinanceiros",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Lucro",
                table: "ProdutosFinanceiros",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aplicacao",
                table: "ProdutosFinanceiros");

            migrationBuilder.DropColumn(
                name: "DataAplicacao",
                table: "ProdutosFinanceiros");

            migrationBuilder.DropColumn(
                name: "DataResgate",
                table: "ProdutosFinanceiros");

            migrationBuilder.DropColumn(
                name: "Lucro",
                table: "ProdutosFinanceiros");
        }
    }
}
