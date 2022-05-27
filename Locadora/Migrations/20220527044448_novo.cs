using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    NomeMae = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Rua = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naturalidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Nacionalidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoNascimento = table.Column<int>(type: "int", nullable: false),
                    Profissao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Rg = table.Column<string>(type: "varchar(200)", nullable: true),
                    OrgaoExpedidorRg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoOrgaoExpedidor = table.Column<int>(type: "int", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    TelefoneMovel = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    TelefoneFixo = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteEstrangeiro = table.Column<bool>(type: "bit", nullable: false),
                    DocumentoIdentificacaoEstrangeiro = table.Column<string>(type: "varchar(200)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Senha = table.Column<string>(type: "varchar(200)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    TipoDeVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    AnoDeModelo = table.Column<int>(type: "int", nullable: false),
                    AnoDeFabricacao = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FotosDeGaragem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataDeRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Caminho = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosDeGaragem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotosDeGaragem_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRetirada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPrevistaDeDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDeDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuilometragemAtual = table.Column<int>(type: "int", nullable: true),
                    QuilometragemDeDevolucao = table.Column<int>(type: "int", nullable: true),
                    PrecoCombinado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DocumentoDeContrato = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeNadaConstaDetran = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeNadaConstaCriminal = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeCheckList = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeIdentificacao = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeComprovanteDeEndereco = table.Column<string>(type: "varchar(200)", nullable: true),
                    VeiculoId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Devolvido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacoes_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FotosDeGaragem_VeiculoId",
                table: "FotosDeGaragem",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_ClienteId",
                table: "Locacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_VeiculoId",
                table: "Locacoes",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotosDeGaragem");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
