using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Data.Migrations
{
    public partial class InicioAplicacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    ValorAplicado = table.Column<decimal>(nullable: false),
                    ValorAtual = table.Column<decimal>(nullable: false),
                    DataAplicacao = table.Column<DateTime>(nullable: false),
                    DataRetirada = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacao");
        }
    }
}
