using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Repository.Implementacao.Migrations
{
    public partial class SegundaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorResgatado",
                table: "tb_produto",
                newName: "val_resgatado");

            migrationBuilder.RenameColumn(
                name: "DataResgate",
                table: "tb_produto",
                newName: "din_resgate");

            migrationBuilder.AddColumn<decimal>(
                name: "val_imposto",
                table: "tb_produto",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "val_lucroacumulado",
                table: "tb_produto",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "val_imposto",
                table: "tb_produto");

            migrationBuilder.DropColumn(
                name: "val_lucroacumulado",
                table: "tb_produto");

            migrationBuilder.RenameColumn(
                name: "val_resgatado",
                table: "tb_produto",
                newName: "ValorResgatado");

            migrationBuilder.RenameColumn(
                name: "din_resgate",
                table: "tb_produto",
                newName: "DataResgate");
        }
    }
}
