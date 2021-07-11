using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class RemoveFielRescueValueAndAddFieldFirstInvestmentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RescueValue",
                table: "Investments");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstInvestmentDate",
                table: "Investments",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstInvestmentDate",
                table: "Investments");

            migrationBuilder.AddColumn<decimal>(
                name: "RescueValue",
                table: "Investments",
                type: "DECIMAL(18,2)",
                nullable: true);
        }
    }
}
