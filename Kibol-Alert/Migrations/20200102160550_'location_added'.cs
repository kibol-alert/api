using Microsoft.EntityFrameworkCore.Migrations;

namespace Kibol_Alert.Migrations
{
    public partial class location_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brawls_Location_LocationLatitude_LocationLongitude",
                table: "Brawls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Brawls_LocationLatitude_LocationLongitude",
                table: "Brawls");

            migrationBuilder.DropColumn(
                name: "LocationLatitude",
                table: "Brawls");

            migrationBuilder.DropColumn(
                name: "LocationLongitude",
                table: "Brawls");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Location",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GeolocationId",
                table: "Clubs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Brawls",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_GeolocationId",
                table: "Clubs",
                column: "GeolocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Brawls_LocationId",
                table: "Brawls",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brawls_Location_LocationId",
                table: "Brawls",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Location_GeolocationId",
                table: "Clubs",
                column: "GeolocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brawls_Location_LocationId",
                table: "Brawls");

            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Location_GeolocationId",
                table: "Clubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_GeolocationId",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Brawls_LocationId",
                table: "Brawls");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "GeolocationId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Brawls");

            migrationBuilder.AddColumn<float>(
                name: "LocationLatitude",
                table: "Brawls",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "LocationLongitude",
                table: "Brawls",
                type: "real",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                columns: new[] { "Latitude", "Longitude" });

            migrationBuilder.CreateIndex(
                name: "IX_Brawls_LocationLatitude_LocationLongitude",
                table: "Brawls",
                columns: new[] { "LocationLatitude", "LocationLongitude" });

            migrationBuilder.AddForeignKey(
                name: "FK_Brawls_Location_LocationLatitude_LocationLongitude",
                table: "Brawls",
                columns: new[] { "LocationLatitude", "LocationLongitude" },
                principalTable: "Location",
                principalColumns: new[] { "Latitude", "Longitude" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
