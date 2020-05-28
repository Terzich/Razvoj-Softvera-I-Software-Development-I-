using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class MijenjanjeTipaPodatka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "BrojBodova",
                table: "MaturskiIspitUcenik",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "BrojBodova",
                table: "MaturskiIspitUcenik",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
