using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Persistence.Migrations
{
    public partial class InvestmentValuation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Investment");

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Users",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<double>(
                name: "InitialValue",
                table: "Investment",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "EvaluatorsJson",
                table: "FinancialProduct",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialValue",
                table: "Investment");

            migrationBuilder.DropColumn(
                name: "EvaluatorsJson",
                table: "FinancialProduct");

            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Investment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
