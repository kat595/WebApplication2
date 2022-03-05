using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class AddClubToFootballer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Footballers_Clubs_ClubId",
                table: "Footballers");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Footballers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Footballers_Clubs_ClubId",
                table: "Footballers",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Footballers_Clubs_ClubId",
                table: "Footballers");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Footballers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Footballers_Clubs_ClubId",
                table: "Footballers",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");
        }
    }
}
