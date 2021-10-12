using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class ThirdMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "productName",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productName",
                table: "Product");
        }
    }
}
