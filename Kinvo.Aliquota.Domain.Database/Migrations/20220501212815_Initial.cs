using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kinvo.Aliquota.Domain.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Income = table.Column<float>(type: "real", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeApplications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    AppliedValue = table.Column<long>(type: "bigint", nullable: false),
                    DailyProfit = table.Column<long>(type: "bigint", nullable: true),
                    TotalProfit = table.Column<long>(type: "bigint", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeApplications_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomeApplications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DateIncomeApplications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppliedValue = table.Column<long>(type: "bigint", nullable: false),
                    IncomeApplicationId = table.Column<long>(type: "bigint", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateIncomeApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateIncomeApplications_IncomeApplications_IncomeApplicationId",
                        column: x => x.IncomeApplicationId,
                        principalTable: "IncomeApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DateWithdrawals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WithdrawalValue = table.Column<long>(type: "bigint", nullable: false),
                    IncomeApplicationId = table.Column<long>(type: "bigint", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateWithdrawals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateWithdrawals_IncomeApplications_IncomeApplicationId",
                        column: x => x.IncomeApplicationId,
                        principalTable: "IncomeApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateIncomeApplications_IncomeApplicationId",
                table: "DateIncomeApplications",
                column: "IncomeApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DateWithdrawals_IncomeApplicationId",
                table: "DateWithdrawals",
                column: "IncomeApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeApplications_ClientId",
                table: "IncomeApplications",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeApplications_ProductId",
                table: "IncomeApplications",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateIncomeApplications");

            migrationBuilder.DropTable(
                name: "DateWithdrawals");

            migrationBuilder.DropTable(
                name: "IncomeApplications");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
