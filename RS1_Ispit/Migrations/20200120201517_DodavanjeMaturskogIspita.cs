using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class DodavanjeMaturskogIspita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaturskiIspit",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkolaID = table.Column<int>(nullable: false),
                    NastavnikID = table.Column<int>(nullable: false),
                    SkolskaGodinaID = table.Column<int>(nullable: false),
                    DatumIspita = table.Column<DateTime>(nullable: false),
                    PredmetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaturskiIspit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaturskiIspit_Nastavnik_NastavnikID",
                        column: x => x.NastavnikID,
                        principalTable: "Nastavnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaturskiIspit_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaturskiIspit_Skola_SkolaID",
                        column: x => x.SkolaID,
                        principalTable: "Skola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaturskiIspit_SkolskaGodina_SkolskaGodinaID",
                        column: x => x.SkolskaGodinaID,
                        principalTable: "SkolskaGodina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaturskiIspitUcenik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaturskiIspitID = table.Column<int>(nullable: false),
                    UcenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaturskiIspitUcenik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaturskiIspitUcenik_MaturskiIspit_MaturskiIspitID",
                        column: x => x.MaturskiIspitID,
                        principalTable: "MaturskiIspit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaturskiIspitUcenik_Ucenik_UcenikID",
                        column: x => x.UcenikID,
                        principalTable: "Ucenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspit_NastavnikID",
                table: "MaturskiIspit",
                column: "NastavnikID");

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspit_PredmetID",
                table: "MaturskiIspit",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspit_SkolaID",
                table: "MaturskiIspit",
                column: "SkolaID");

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspit_SkolskaGodinaID",
                table: "MaturskiIspit",
                column: "SkolskaGodinaID");

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspitUcenik_MaturskiIspitID",
                table: "MaturskiIspitUcenik",
                column: "MaturskiIspitID");

            migrationBuilder.CreateIndex(
                name: "IX_MaturskiIspitUcenik_UcenikID",
                table: "MaturskiIspitUcenik",
                column: "UcenikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaturskiIspitUcenik");

            migrationBuilder.DropTable(
                name: "MaturskiIspit");
        }
    }
}
