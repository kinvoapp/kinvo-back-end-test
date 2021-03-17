using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone_NuTelephone = table.Column<string>(type: "varchar(150)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ticker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VlProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmTax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxAction = table.Column<int>(type: "int", nullable: false),
                    VlPercentageDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtMinDayDiscount = table.Column<int>(type: "int", nullable: false),
                    QtMaxDayDiscount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tax_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovementApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtLot = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DtRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    TaxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementApplication_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovementApplication_Tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Tax",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovementRescue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtRescue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    TaxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementRescue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementRescue_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovementRescue_Tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Tax",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DtRegister", "NmProduct", "Ticker", "VlProfit" },
                values: new object[] { 1, new DateTime(2021, 3, 17, 1, 44, 56, 156, DateTimeKind.Local).AddTicks(1161), "Aplicação Financeira XPTO", "APTEST4", 3000m });

            migrationBuilder.InsertData(
                table: "Tax",
                columns: new[] { "Id", "NmTax", "ProductId", "QtMaxDayDiscount", "QtMinDayDiscount", "TaxAction", "VlPercentageDiscount" },
                values: new object[] { 1, "[IR] Até 1 ano de aplicação: 22,5% sobre o lucro", 1, 365, 0, 2, 22.5m });

            migrationBuilder.InsertData(
                table: "Tax",
                columns: new[] { "Id", "NmTax", "ProductId", "QtMaxDayDiscount", "QtMinDayDiscount", "TaxAction", "VlPercentageDiscount" },
                values: new object[] { 2, "[IR] De 1 a 2 anos de aplicação: 18,5% sobre o lucro", 1, 1095, 366, 2, 18.5m });

            migrationBuilder.InsertData(
                table: "Tax",
                columns: new[] { "Id", "NmTax", "ProductId", "QtMaxDayDiscount", "QtMinDayDiscount", "TaxAction", "VlPercentageDiscount" },
                values: new object[] { 3, "[IR] Acima 2 anos de aplicação: 15% sobre o lucro", 1, 999999, 1096, 2, 15m });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_CustomerId",
                table: "CustomerProduct",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_ProductId",
                table: "CustomerProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementApplication_ProductId",
                table: "MovementApplication",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementApplication_TaxId",
                table: "MovementApplication",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementRescue_ProductId",
                table: "MovementRescue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementRescue_TaxId",
                table: "MovementRescue",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Tax_ProductId",
                table: "Tax",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProduct");

            migrationBuilder.DropTable(
                name: "MovementApplication");

            migrationBuilder.DropTable(
                name: "MovementRescue");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tax");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
