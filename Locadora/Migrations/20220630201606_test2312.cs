using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class test2312 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quilometragem",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quilometragem",
                table: "Veiculos");
        }
    }
}
