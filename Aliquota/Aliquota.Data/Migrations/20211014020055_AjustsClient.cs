using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Data.Migrations
{
    public partial class AjustsClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Carteiras_CarteiraId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CarteiraId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CarteiraId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Carteiras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carteiras_ClienteId",
                table: "Carteiras",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carteiras_Clientes_ClienteId",
                table: "Carteiras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carteiras_Clientes_ClienteId",
                table: "Carteiras");

            migrationBuilder.DropIndex(
                name: "IX_Carteiras_ClienteId",
                table: "Carteiras");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Carteiras");

            migrationBuilder.AddColumn<int>(
                name: "CarteiraId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CarteiraId",
                table: "Clientes",
                column: "CarteiraId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Carteiras_CarteiraId",
                table: "Clientes",
                column: "CarteiraId",
                principalTable: "Carteiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
