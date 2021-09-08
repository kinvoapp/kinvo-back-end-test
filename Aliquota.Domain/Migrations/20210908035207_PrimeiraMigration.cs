using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    investimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aplicação = table.Column<float>(type: "real", nullable: false),
                    lucroTotal = table.Column<float>(type: "real", nullable: false),
                    redimentoPorMes = table.Column<float>(type: "real", nullable: false),
                    dataEntrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataRetirada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    impostoDeRenda = table.Column<float>(type: "real", nullable: false),
                    jurosImpostoDeRenda = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.investimentoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    saldo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investimentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
