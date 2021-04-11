using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Migrations
{
    public partial class @int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<double>(nullable: false),
                    dataAplicacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<double>(nullable: false),
                    dataResgate = table.Column<string>(nullable: true),
                    dataAplicacao = table.Column<string>(nullable: true),
                    ir = table.Column<double>(nullable: false),
                    lucro = table.Column<double>(nullable: false),
                    aliquota = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Aplicacao",
                columns: new[] { "Id", "dataAplicacao", "valor" },
                values: new object[] { 2, "19/09/1999", 2000.0 });

            migrationBuilder.InsertData(
                table: "Aplicacao",
                columns: new[] { "Id", "dataAplicacao", "valor" },
                values: new object[] { 3, "17/04/1987", 3000.0 });

            migrationBuilder.InsertData(
                table: "IR",
                columns: new[] { "Id", "aliquota", "dataAplicacao", "dataResgate", "ir", "lucro", "valor" },
                values: new object[] { 1, 0.14999999999999999, "19/09/1999", "22/12/2021", 290.39999999999998, 1936.0, 1000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacao");

            migrationBuilder.DropTable(
                name: "IR");
        }
    }
}
