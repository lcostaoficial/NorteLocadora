using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acessorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    PrecoDeCusto = table.Column<decimal>(type: "decimal(18,2)", maxLength: 250, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessorios", x => x.Id);
                });

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
                name: "Notificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Icone = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Rota = table.Column<string>(type: "varchar(8000)", maxLength: 8000, nullable: false),
                    DataDeExibicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lida = table.Column<bool>(type: "bit", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.Id);
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
                    Cor = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Renavam = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    AnoDeModelo = table.Column<int>(type: "int", nullable: false),
                    AnoDeFabricacao = table.Column<int>(type: "int", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    DataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDePagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
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
                    ValorDaParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
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
                    PrecoCombinado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataDeDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuilometragemAtual = table.Column<int>(type: "int", nullable: true),
                    QuilometragemDeDevolucao = table.Column<int>(type: "int", nullable: true),
                    ObservacoesDeSaida = table.Column<string>(type: "varchar(200)", nullable: true),
                    ObservacoesDeChegada = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeContrato = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeNadaConstaDetran = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeNadaConstaCriminal = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeCheckListSaida = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeCheckListChegada = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeIdentificacao = table.Column<string>(type: "varchar(200)", nullable: true),
                    DocumentoDeComprovanteDeEndereco = table.Column<string>(type: "varchar(200)", nullable: true),
                    VeiculoId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Finalizada = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Manutencoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoManutencao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manutencoes_Veiculos_VeiculoId",
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

            migrationBuilder.CreateTable(
                name: "ParcelasDoFinanciamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDePagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_VeiculoId",
                table: "Manutencoes",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessorioLocacao");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "FotosDeGaragem");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Manutencoes");

            migrationBuilder.DropTable(
                name: "Multas");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "ParcelasDoFinanciamento");

            migrationBuilder.DropTable(
                name: "Acessorios");

            migrationBuilder.DropTable(
                name: "Locacoes");

            migrationBuilder.DropTable(
                name: "Financiamentos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
