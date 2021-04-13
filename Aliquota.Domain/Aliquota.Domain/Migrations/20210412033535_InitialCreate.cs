using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewOperations",
                columns: table => new
                {
                    iD = table.Column<Guid>(type: "TEXT", nullable: false),
                    dateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    clientCPF = table.Column<string>(type: "TEXT", nullable: true),
                    amount = table.Column<float>(type: "REAL", nullable: false),
                    profitPerMonth = table.Column<float>(type: "REAL", nullable: false),
                    operationType = table.Column<int>(type: "INTEGER", nullable: false),
                    withdrawn = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewOperations", x => x.iD);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewOperations");
        }
    }
}
