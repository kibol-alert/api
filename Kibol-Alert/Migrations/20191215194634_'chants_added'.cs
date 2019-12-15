using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kibol_Alert.Migrations
{
    public partial class chants_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Clubs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Chants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(nullable: true),
                    Lyrics = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chants_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => new { x.Latitude, x.Longitude });
                });

            migrationBuilder.CreateTable(
                name: "Brawls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstClubName = table.Column<string>(nullable: true),
                    SecondClubName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    LocationLatitude = table.Column<float>(nullable: true),
                    LocationLongitude = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brawls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brawls_Location_LocationLatitude_LocationLongitude",
                        columns: x => new { x.LocationLatitude, x.LocationLongitude },
                        principalTable: "Location",
                        principalColumns: new[] { "Latitude", "Longitude" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brawls_LocationLatitude_LocationLongitude",
                table: "Brawls",
                columns: new[] { "LocationLatitude", "LocationLongitude" });

            migrationBuilder.CreateIndex(
                name: "IX_Chants_ClubId",
                table: "Chants",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brawls");

            migrationBuilder.DropTable(
                name: "Chants");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");
        }
    }
}
