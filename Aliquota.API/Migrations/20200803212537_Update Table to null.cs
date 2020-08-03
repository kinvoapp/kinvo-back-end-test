using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.API.Migrations
{
    public partial class UpdateTabletonull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRetornado",
                table: "Investimento",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRetornado",
                table: "Investimento",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
