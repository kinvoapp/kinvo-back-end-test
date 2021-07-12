using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Persistence.Migrations
{
    public partial class Investments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investment_FinancialProducts_FinancialProductId",
                table: "Investment");

            migrationBuilder.DropForeignKey(
                name: "FK_Investment_Portfolios_PortfolioId",
                table: "Investment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investment",
                table: "Investment");

            migrationBuilder.RenameTable(
                name: "Investment",
                newName: "Investments");

            migrationBuilder.RenameIndex(
                name: "IX_Investment_PortfolioId",
                table: "Investments",
                newName: "IX_Investments_PortfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_Investment_FinancialProductId",
                table: "Investments",
                newName: "IX_Investments_FinancialProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investments",
                table: "Investments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_FinancialProducts_FinancialProductId",
                table: "Investments",
                column: "FinancialProductId",
                principalTable: "FinancialProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Portfolios_PortfolioId",
                table: "Investments",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_FinancialProducts_FinancialProductId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Portfolios_PortfolioId",
                table: "Investments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investments",
                table: "Investments");

            migrationBuilder.RenameTable(
                name: "Investments",
                newName: "Investment");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_PortfolioId",
                table: "Investment",
                newName: "IX_Investment_PortfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_FinancialProductId",
                table: "Investment",
                newName: "IX_Investment_FinancialProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investment",
                table: "Investment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investment_FinancialProducts_FinancialProductId",
                table: "Investment",
                column: "FinancialProductId",
                principalTable: "FinancialProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investment_Portfolios_PortfolioId",
                table: "Investment",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
