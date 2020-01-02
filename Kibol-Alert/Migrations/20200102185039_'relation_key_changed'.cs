using Microsoft.EntityFrameworkCore.Migrations;

namespace Kibol_Alert.Migrations
{
    public partial class relation_key_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubRelations",
                table: "ClubRelations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubRelations",
                table: "ClubRelations",
                columns: new[] { "FirstClubId", "SecondClubId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubRelations",
                table: "ClubRelations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubRelations",
                table: "ClubRelations",
                columns: new[] { "FirstClubId", "SecondClubId", "Relation" });
        }
    }
}
