using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class DoradaEntityKlasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "BrojBodova",
                table: "MaturskiIspitUcenik",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "PristupioMaturskomIspitu",
                table: "MaturskiIspitUcenik",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojBodova",
                table: "MaturskiIspitUcenik");

            migrationBuilder.DropColumn(
                name: "PristupioMaturskomIspitu",
                table: "MaturskiIspitUcenik");
        }
    }
}
