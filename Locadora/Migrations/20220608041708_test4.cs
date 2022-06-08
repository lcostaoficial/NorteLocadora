using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentoDeCheckList",
                table: "Locacoes",
                newName: "ObservacoesDeSaida");

            migrationBuilder.AddColumn<string>(
                name: "DocumentoDeCheckListChegada",
                table: "Locacoes",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentoDeCheckListSaida",
                table: "Locacoes",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObservacoesDeChegada",
                table: "Locacoes",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentoDeCheckListChegada",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "DocumentoDeCheckListSaida",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "ObservacoesDeChegada",
                table: "Locacoes");

            migrationBuilder.RenameColumn(
                name: "ObservacoesDeSaida",
                table: "Locacoes",
                newName: "DocumentoDeCheckList");
        }
    }
}
