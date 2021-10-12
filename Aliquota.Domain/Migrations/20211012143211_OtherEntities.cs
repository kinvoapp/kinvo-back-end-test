using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class OtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    productInvestment = table.Column<double>(nullable: false),
                    productGain = table.Column<double>(nullable: false),
                    productTax = table.Column<double>(nullable: false),
                    dateRescue = table.Column<DateTime>(nullable: false),
                    dateApplication = table.Column<DateTime>(nullable: false),
                    clientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Product_Client_clientId",
                        column: x => x.clientId,
                        principalTable: "Client",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IR_Record",
                columns: table => new
                {
                    recordId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    recordDate = table.Column<DateTime>(nullable: false),
                    recordAmount = table.Column<double>(nullable: false),
                    recordStatus = table.Column<int>(nullable: false),
                    clientId = table.Column<int>(nullable: true),
                    productId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Record", x => x.recordId);
                    table.ForeignKey(
                        name: "FK_IR_Record_Client_clientId",
                        column: x => x.clientId,
                        principalTable: "Client",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IR_Record_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IR_Record_clientId",
                table: "IR_Record",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_IR_Record_productId",
                table: "IR_Record",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_clientId",
                table: "Product",
                column: "clientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IR_Record");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
