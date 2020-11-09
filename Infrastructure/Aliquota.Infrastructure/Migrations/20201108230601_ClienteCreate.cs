using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Infrastructure.Migrations
{
    public partial class ClienteCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                schema: "dbo",
                table: "ProdutosFinanceiros",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosFinanceiros_ClienteId",
                schema: "dbo",
                table: "ProdutosFinanceiros",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosFinanceiros_Clientes_ClienteId",
                schema: "dbo",
                table: "ProdutosFinanceiros",
                column: "ClienteId",
                principalSchema: "dbo",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosFinanceiros_Clientes_ClienteId",
                schema: "dbo",
                table: "ProdutosFinanceiros");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_ProdutosFinanceiros_ClienteId",
                schema: "dbo",
                table: "ProdutosFinanceiros");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                schema: "dbo",
                table: "ProdutosFinanceiros");
        }
    }
}
