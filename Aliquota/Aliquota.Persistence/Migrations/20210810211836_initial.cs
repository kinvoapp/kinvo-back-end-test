using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialProducts",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    MinimalInvestedAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Profitability = table.Column<int>(nullable: false),
                    Deadline = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Withdraw",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    InvestedTime = table.Column<decimal>(type: "decimal(18)", nullable: false),
                    LiquidIncome = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Profit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdraw", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    FinancialProductId = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investments_FinancialProducts_FinancialProductId",
                        column: x => x.FinancialProductId,
                        principalTable: "FinancialProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FinancialProducts",
                columns: new[] { "Id", "Deadline", "MinimalInvestedAmount", "MonthlyIncome", "Name", "Profitability" },
                values: new object[,]
                {
                    { 1m, 0, 17.10m, 0.0289m, "ABEV1", 3 },
                    { 2m, 2, 100.69m, -0.0048m, "ABEV2", 2 },
                    { 3m, 1, 2.48m, 0.3m, "ABEV3", 1 },
                    { 4m, 0, 32.78m, -0.064m, "ABEV4", 0 },
                    { 5m, 2, 48.88m, 0.0397m, "ABEV5", 2 }
                });

            migrationBuilder.InsertData(
                table: "Investments",
                columns: new[] { "Id", "Amount", "FinancialProductId", "Start" },
                values: new object[,]
                {
                    { 1m, 1000m, 1m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5m, 2500m, 1m, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2m, 5000m, 2m, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6m, 3000m, 2m, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3m, 10000m, 3m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4m, 9500m, 4m, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7m, 7500m, 4m, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investments_FinancialProductId",
                table: "Investments",
                column: "FinancialProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "Withdraw");

            migrationBuilder.DropTable(
                name: "FinancialProducts");
        }
    }
}