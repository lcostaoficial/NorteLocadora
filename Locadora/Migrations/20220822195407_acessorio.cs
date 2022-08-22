using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class acessorio : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessorioLocacao");

            migrationBuilder.DropTable(
                name: "Acessorios");
        }
    }
}
