using Microsoft.EntityFrameworkCore.Migrations;

namespace Kibol_Alert.Migrations
{
    public partial class brawls_fkv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chants_Clubs_ClubId",
                table: "Chants");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Chants",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chants_Clubs_ClubId",
                table: "Chants",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chants_Clubs_ClubId",
                table: "Chants");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Chants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Chants_Clubs_ClubId",
                table: "Chants",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
