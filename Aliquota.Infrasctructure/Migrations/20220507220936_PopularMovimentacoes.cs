using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Infrasctructure.Migrations
{
    public partial class PopularMovimentacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `movimentacao` VALUES(null, '2021-05-06 21:34', 'APLICACAO', 234.15)");
            migrationBuilder.Sql("INSERT INTO `movimentacao` VALUES(null, '2021-07-08 13:22', 'APLICACAO', 850.50)");
            migrationBuilder.Sql("INSERT INTO `movimentacao` VALUES(null, '2021-09-11 10:25', 'APLICACAO', 522.30)");
            migrationBuilder.Sql("INSERT INTO `movimentacao` VALUES(null, '2022-01-01 08:11', 'APLICACAO', 1001.25)");
            migrationBuilder.Sql("INSERT INTO `movimentacao` VALUES(null, '2022-12-30 10:33', 'RESGATE', 500.50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM `movimentacao` where id<>null ");
        }
    }
}
