using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Infra.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "conta",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    valorAplicacao = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    valorCorrente = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    dtAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtResgate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(nullable: false),
                    valorResgate = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conta", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "conta",
                columns: new[] { "id", "ativo", "dtAplicacao", "dtResgate", "nome", "valorAplicacao", "valorCorrente", "valorResgate" },
                values: new object[,]
                {
                    { new Guid("e83e8294-5c31-4a27-b0bc-14c881ab13b8"), true, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Marcelo Pereira", 400.00m, 1200.00m, 1020.00000m },
                    { new Guid("5ca4b1bc-1a3b-4838-8389-734b465a6552"), true, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Nayra Gomes", 700.00m, 2100.00m, 1785.00000m },
                    { new Guid("5d3ed0c9-7718-4327-81bd-12762f4bc73c"), true, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Daniele Ramos", 600.00m, 1800.00m, 1530.00000m },
                    { new Guid("bc1c6480-d33c-4357-ac04-7857c86021c1"), true, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Anderson Silva", 200.00m, 600.00m, 510.00000m },
                    { new Guid("5178c0cd-c66e-4b95-80fb-0c8b3693ea5d"), true, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Mariana Santos", 800.00m, 2400.00m, 2040.00000m },
                    { new Guid("754ef93a-05f8-45ab-b014-6fedbd7f051c"), true, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "José Henrique", 900.00m, 2700.00m, 2295.00000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conta");
        }
    }
}
