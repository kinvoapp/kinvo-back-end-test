using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Persistence.Migrations
{
    public partial class PortfolioBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Users");

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Portfolios",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Portfolios");

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Users",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
