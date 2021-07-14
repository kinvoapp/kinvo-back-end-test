using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Persistence.Migrations
{
    public partial class FinancialProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investment_FinancialProduct_FinancialProductId",
                table: "Investment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialProduct",
                table: "FinancialProduct");

            migrationBuilder.RenameTable(
                name: "FinancialProduct",
                newName: "FinancialProducts");

            migrationBuilder.RenameColumn(
                name: "EvaluatorsJson",
                table: "FinancialProducts",
                newName: "EvaluatorsSpecJson");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialProducts",
                table: "FinancialProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investment_FinancialProducts_FinancialProductId",
                table: "Investment",
                column: "FinancialProductId",
                principalTable: "FinancialProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investment_FinancialProducts_FinancialProductId",
                table: "Investment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialProducts",
                table: "FinancialProducts");

            migrationBuilder.RenameTable(
                name: "FinancialProducts",
                newName: "FinancialProduct");

            migrationBuilder.RenameColumn(
                name: "EvaluatorsSpecJson",
                table: "FinancialProduct",
                newName: "EvaluatorsJson");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialProduct",
                table: "FinancialProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investment_FinancialProduct_FinancialProductId",
                table: "Investment",
                column: "FinancialProductId",
                principalTable: "FinancialProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
