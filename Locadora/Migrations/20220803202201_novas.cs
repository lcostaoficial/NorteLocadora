using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class novas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Multas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeInfrator = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    CpfInfrator = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    ValorMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(8000)", maxLength: 8000, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Multas_VeiculoId",
                table: "Multas",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Multas");
        }
    }
}
