using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class ClientForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Client_clientId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Product",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_clientId",
                table: "Product",
                newName: "IX_Product_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Client_ClientId",
                table: "Product",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "clientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Client_ClientId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Product",
                newName: "clientId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ClientId",
                table: "Product",
                newName: "IX_Product_clientId");

            migrationBuilder.AlterColumn<int>(
                name: "clientId",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Client_clientId",
                table: "Product",
                column: "clientId",
                principalTable: "Client",
                principalColumn: "clientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
