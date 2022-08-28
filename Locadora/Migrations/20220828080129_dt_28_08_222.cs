using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class dt_28_08_222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Notificacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    DataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDePagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentoDeComprovante = table.Column<string>(type: "varchar(200)", nullable: true),
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
                    DataDeVencimentoDaPrimeiraParcela = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantidadeDeParcelas = table.Column<int>(type: "int", nullable: false),
                    Quitado = table.Column<bool>(type: "bit", nullable: false),
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
                name: "ParcelasDoFinanciamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDePagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorDaParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Paga = table.Column<bool>(type: "bit", nullable: false),
                    FinanciamentoId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Despesas_VeiculoId",
                table: "Despesas",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Financiamentos_VeiculoId",
                table: "Financiamentos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelasDoFinanciamento_FinanciamentoId",
                table: "ParcelasDoFinanciamento",
                column: "FinanciamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "ParcelasDoFinanciamento");

            migrationBuilder.DropTable(
                name: "Financiamentos");

            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Notificacoes");
        }
    }
}
