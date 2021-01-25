using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Infra.Data.Migrations
{
    public partial class AddProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "value",
                table: "application",
                newName: "initial_value");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "application",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "current_value",
                table: "application",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "application",
                columns: new[] { "id", "active", "created_at", "current_value", "initial_value", "name", "withdrawn_at" },
                values: new object[] { new Guid("f498ec2d-a9f1-47a9-b479-6cf1430f6e0a"), true, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 300.00m, 100.00m, "Sample application", null });

            migrationBuilder.InsertData(
                table: "application",
                columns: new[] { "id", "active", "created_at", "current_value", "initial_value", "name", "withdrawn_at" },
                values: new object[] { new Guid("85d83f27-9945-42b3-9021-0e316c8a8b3a"), true, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 300.00m, 100.00m, "Second application", null });

            migrationBuilder.InsertData(
                table: "application",
                columns: new[] { "id", "active", "created_at", "current_value", "initial_value", "name", "withdrawn_at" },
                values: new object[] { new Guid("d19039ef-cfc0-4413-911a-4bd69fb96f0c"), true, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 300.00m, 100.00m, "Third application", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "application",
                keyColumn: "id",
                keyValue: new Guid("85d83f27-9945-42b3-9021-0e316c8a8b3a"));

            migrationBuilder.DeleteData(
                table: "application",
                keyColumn: "id",
                keyValue: new Guid("d19039ef-cfc0-4413-911a-4bd69fb96f0c"));

            migrationBuilder.DeleteData(
                table: "application",
                keyColumn: "id",
                keyValue: new Guid("f498ec2d-a9f1-47a9-b479-6cf1430f6e0a"));

            migrationBuilder.DropColumn(
                name: "active",
                table: "application");

            migrationBuilder.DropColumn(
                name: "current_value",
                table: "application");

            migrationBuilder.RenameColumn(
                name: "initial_value",
                table: "application",
                newName: "value");
        }
    }
}
