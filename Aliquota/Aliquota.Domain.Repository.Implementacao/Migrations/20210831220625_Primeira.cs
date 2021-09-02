using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Domain.Repository.Implementacao.Migrations
{
    public partial class Primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_cliente = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "tb_situacaoproduto",
                columns: table => new
                {
                    id_situacaoproduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_situacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_situacaoproduto", x => x.id_situacaoproduto);
                });

            migrationBuilder.CreateTable(
                name: "tb_tipoproduto",
                columns: table => new
                {
                    id_tipoproduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_tipoproduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    val_rentabilidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tipoproduto", x => x.id_tipoproduto);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto",
                columns: table => new
                {
                    id_produto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoProduto = table.Column<int>(type: "int", nullable: false),
                    IdSituacaoProduto = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    val_investido = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    val_atual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorResgatado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    din_investimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataResgate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto", x => x.id_produto);
                    table.ForeignKey(
                        name: "FK_tb_produto_tb_cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "tb_cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produto_tb_situacaoproduto_IdSituacaoProduto",
                        column: x => x.IdSituacaoProduto,
                        principalTable: "tb_situacaoproduto",
                        principalColumn: "id_situacaoproduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produto_tb_tipoproduto_IdTipoProduto",
                        column: x => x.IdTipoProduto,
                        principalTable: "tb_tipoproduto",
                        principalColumn: "id_tipoproduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_IdCliente",
                table: "tb_produto",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_IdSituacaoProduto",
                table: "tb_produto",
                column: "IdSituacaoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_IdTipoProduto",
                table: "tb_produto",
                column: "IdTipoProduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_produto");

            migrationBuilder.DropTable(
                name: "tb_cliente");

            migrationBuilder.DropTable(
                name: "tb_situacaoproduto");

            migrationBuilder.DropTable(
                name: "tb_tipoproduto");
        }
    }
}
