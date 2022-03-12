using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class ChangeFootballerGoalToFootballerInTips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tips_Footballer_stats_FootballerId",
                table: "Tips");

            migrationBuilder.AddForeignKey(
                name: "FK_Tips_Footballers_FootballerId",
                table: "Tips",
                column: "FootballerId",
                principalTable: "Footballers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tips_Footballers_FootballerId",
                table: "Tips");

            migrationBuilder.AddForeignKey(
                name: "FK_Tips_Footballer_stats_FootballerId",
                table: "Tips",
                column: "FootballerId",
                principalTable: "Footballer_stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
