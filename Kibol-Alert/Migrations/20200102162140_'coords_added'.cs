using Microsoft.EntityFrameworkCore.Migrations;

namespace Kibol_Alert.Migrations
{
    public partial class coords_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Location_GeolocationId",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_GeolocationId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "GeolocationId",
                table: "Clubs");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Clubs",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Clubs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Clubs");

            migrationBuilder.AddColumn<int>(
                name: "GeolocationId",
                table: "Clubs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_GeolocationId",
                table: "Clubs",
                column: "GeolocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Location_GeolocationId",
                table: "Clubs",
                column: "GeolocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
