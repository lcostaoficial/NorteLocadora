using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class xt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CategoriaCnhA",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CategoriaCnhB",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CategoriaCnhC",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CategoriaCnhD",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CategoriaCnhE",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Cnh",
                table: "Clientes",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeVencimentoDaCnh",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TelefoneMovel1",
                table: "Clientes",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefoneMovel2",
                table: "Clientes",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefoneMovel3",
                table: "Clientes",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaCnhA",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CategoriaCnhB",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CategoriaCnhC",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CategoriaCnhD",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CategoriaCnhE",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Cnh",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataDeVencimentoDaCnh",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TelefoneMovel1",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TelefoneMovel2",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TelefoneMovel3",
                table: "Clientes");
        }
    }
}
