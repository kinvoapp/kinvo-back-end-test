using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Aliquiota.Migrations
{
    public partial class DbKinvo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    idBanco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.idBanco);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Cpf = table.Column<decimal>(type: "Numeric(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Rendimento = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    BancoidBanco = table.Column<int>(nullable: false),
                    Tempo_Rendimento_Dias = table.Column<int>(nullable: false),
                    Taxa_Menor_IR = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Taxa_Maior_IR = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Taxa_Entre_IR = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Ano_Menor_IR = table.Column<int>(nullable: false),
                    Ano_Maior_IR = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Bancos_BancoidBanco",
                        column: x => x.BancoidBanco,
                        principalTable: "Bancos",
                        principalColumn: "idBanco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    IdConta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroConta = table.Column<decimal>(type: "Numeric(9)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    BancoidBanco = table.Column<int>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    ClienteIdCliente = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.IdConta);
                    table.ForeignKey(
                        name: "FK_Contas_Bancos_BancoidBanco",
                        column: x => x.BancoidBanco,
                        principalTable: "Bancos",
                        principalColumn: "idBanco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contas_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    IdInvestimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValorInvestido = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ValorResgatadoBruto = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ValorResgatadoLiquido = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ValorRecolhidoIR = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    DataAplicacao = table.Column<DateTime>(nullable: false),
                    DataResgate = table.Column<DateTime>(nullable: false),
                    ProdutoIdProduto = table.Column<int>(nullable: true),
                    ContaIdConta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.IdInvestimento);
                    table.ForeignKey(
                        name: "FK_Investimentos_Contas_ContaIdConta",
                        column: x => x.ContaIdConta,
                        principalTable: "Contas",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investimentos_Produtos_ProdutoIdProduto",
                        column: x => x.ProdutoIdProduto,
                        principalTable: "Produtos",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_BancoidBanco",
                table: "Contas",
                column: "BancoidBanco");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_ClienteIdCliente",
                table: "Contas",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Investimentos_ContaIdConta",
                table: "Investimentos",
                column: "ContaIdConta");

            migrationBuilder.CreateIndex(
                name: "IX_Investimentos_ProdutoIdProduto",
                table: "Investimentos",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_BancoidBanco",
                table: "Produtos",
                column: "BancoidBanco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investimentos");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
