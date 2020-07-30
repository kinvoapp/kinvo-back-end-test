using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquiota.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aplicacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    DataResgate = table.Column<DateTime>(nullable: true),
                    RentabilidadeDiaria = table.Column<double>(nullable: false),
                    ValorAplicado = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aplicacoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_UsuarioId",
                table: "Aplicacoes",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
