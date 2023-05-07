using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessorioLocacao");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Multas");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "ParcelasDoFinanciamento");

            migrationBuilder.DropTable(
                name: "Acessorios");

            migrationBuilder.DropTable(
                name: "Financiamentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acessorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    PrecoDeCusto = table.Column<decimal>(type: "decimal(18,2)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    DataDePagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesas_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Financiamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataDeVencimentoDaPrimeiraParcela = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantidadeDeParcelas = table.Column<int>(type: "int", nullable: false),
                    Quitado = table.Column<bool>(type: "bit", nullable: false),
                    ValorDaParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financiamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financiamentos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Multas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CpfInfrator = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    DataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeInfrator = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(8000)", maxLength: 8000, nullable: false),
                    ValorMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Multas_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    DataDeExibicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Icone = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Lida = table.Column<bool>(type: "bit", nullable: false),
                    Rota = table.Column<string>(type: "varchar(8000)", maxLength: 8000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcessorioLocacao",
                columns: table => new
                {
                    AcessoriosId = table.Column<int>(type: "int", nullable: false),
                    LocacoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessorioLocacao", x => new { x.AcessoriosId, x.LocacoesId });
                    table.ForeignKey(
                        name: "FK_AcessorioLocacao_Acessorios_AcessoriosId",
                        column: x => x.AcessoriosId,
                        principalTable: "Acessorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcessorioLocacao_Locacoes_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "Locacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParcelasDoFinanciamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDePagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinanciamentoId = table.Column<int>(type: "int", nullable: false),
                    Paga = table.Column<bool>(type: "bit", nullable: false),
                    ValorDaParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelasDoFinanciamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelasDoFinanciamento_Financiamentos_FinanciamentoId",
                        column: x => x.FinanciamentoId,
                        principalTable: "Financiamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcessorioLocacao_LocacoesId",
                table: "AcessorioLocacao",
                column: "LocacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_VeiculoId",
                table: "Despesas",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Financiamentos_VeiculoId",
                table: "Financiamentos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Multas_VeiculoId",
                table: "Multas",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelasDoFinanciamento_FinanciamentoId",
                table: "ParcelasDoFinanciamento",
                column: "FinanciamentoId");
        }
    }
}
