using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrameworksAndDrivers.Migrations
{
    public partial class POW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinanceProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceProductMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FinanceProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceProductMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinanceProductMoves_FinanceProducts_FinanceProductId",
                        column: x => x.FinanceProductId,
                        principalTable: "FinanceProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinanceProductMoves_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinanceProductWallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FinanceProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceProductWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinanceProductWallets_FinanceProducts_FinanceProductId",
                        column: x => x.FinanceProductId,
                        principalTable: "FinanceProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinanceProductWallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTradeMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FistFinanceProductMoveId = table.Column<int>(type: "int", nullable: true),
                    SecondFinanceProductMoveId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinanceProductWalletId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTradeMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTradeMoves_FinanceProductMoves_FistFinanceProductMoveId",
                        column: x => x.FistFinanceProductMoveId,
                        principalTable: "FinanceProductMoves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTradeMoves_FinanceProductMoves_SecondFinanceProductMoveId",
                        column: x => x.SecondFinanceProductMoveId,
                        principalTable: "FinanceProductMoves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTradeMoves_FinanceProductWallets_FinanceProductWalletId",
                        column: x => x.FinanceProductWalletId,
                        principalTable: "FinanceProductWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTradeMoves_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinanceProductMoves_FinanceProductId",
                table: "FinanceProductMoves",
                column: "FinanceProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceProductMoves_UserId",
                table: "FinanceProductMoves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceProductWallets_FinanceProductId",
                table: "FinanceProductWallets",
                column: "FinanceProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceProductWallets_UserId",
                table: "FinanceProductWallets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTradeMoves_FinanceProductWalletId",
                table: "ProductTradeMoves",
                column: "FinanceProductWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTradeMoves_FistFinanceProductMoveId",
                table: "ProductTradeMoves",
                column: "FistFinanceProductMoveId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTradeMoves_SecondFinanceProductMoveId",
                table: "ProductTradeMoves",
                column: "SecondFinanceProductMoveId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTradeMoves_UserId",
                table: "ProductTradeMoves",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTradeMoves");

            migrationBuilder.DropTable(
                name: "FinanceProductMoves");

            migrationBuilder.DropTable(
                name: "FinanceProductWallets");

            migrationBuilder.DropTable(
                name: "FinanceProducts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
