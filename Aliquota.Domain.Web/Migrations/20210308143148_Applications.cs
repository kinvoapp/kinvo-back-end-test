using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Web.Migrations
{
    public partial class Applications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfitValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WithholdedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyInterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpectedMonthlyPeriod = table.Column<int>(type: "int", nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithdrawDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
