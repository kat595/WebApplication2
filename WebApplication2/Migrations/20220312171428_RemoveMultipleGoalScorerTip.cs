using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class RemoveMultipleGoalScorerTip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tips_Footballer_stats_Tip_goal_defenderId",
                table: "Tips");

            migrationBuilder.DropForeignKey(
                name: "FK_Tips_Footballer_stats_Tip_goal_forwardId",
                table: "Tips");

            migrationBuilder.DropForeignKey(
                name: "FK_Tips_Footballer_stats_Tip_goal_midfielderId",
                table: "Tips");

            migrationBuilder.DropIndex(
                name: "IX_Tips_Tip_goal_defenderId",
                table: "Tips");

            migrationBuilder.DropIndex(
                name: "IX_Tips_Tip_goal_forwardId",
                table: "Tips");

            migrationBuilder.DropColumn(
                name: "DefenderId",
                table: "Tips");

            migrationBuilder.DropColumn(
                name: "ForwardId",
                table: "Tips");

            migrationBuilder.DropColumn(
                name: "MidfielderId",
                table: "Tips");

            migrationBuilder.DropColumn(
                name: "Tip_goal_defenderId",
                table: "Tips");

            migrationBuilder.DropColumn(
                name: "Tip_goal_forwardId",
                table: "Tips");

            migrationBuilder.RenameColumn(
                name: "Tip_goal_midfielderId",
                table: "Tips",
                newName: "FootballerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tips_Tip_goal_midfielderId",
                table: "Tips",
                newName: "IX_Tips_FootballerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tips_Footballer_stats_FootballerId",
                table: "Tips",
                column: "FootballerId",
                principalTable: "Footballer_stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tips_Footballer_stats_FootballerId",
                table: "Tips");

            migrationBuilder.RenameColumn(
                name: "FootballerId",
                table: "Tips",
                newName: "Tip_goal_midfielderId");

            migrationBuilder.RenameIndex(
                name: "IX_Tips_FootballerId",
                table: "Tips",
                newName: "IX_Tips_Tip_goal_midfielderId");

            migrationBuilder.AddColumn<int>(
                name: "DefenderId",
                table: "Tips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ForwardId",
                table: "Tips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MidfielderId",
                table: "Tips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tip_goal_defenderId",
                table: "Tips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tip_goal_forwardId",
                table: "Tips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tips_Tip_goal_defenderId",
                table: "Tips",
                column: "Tip_goal_defenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_Tip_goal_forwardId",
                table: "Tips",
                column: "Tip_goal_forwardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tips_Footballer_stats_Tip_goal_defenderId",
                table: "Tips",
                column: "Tip_goal_defenderId",
                principalTable: "Footballer_stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tips_Footballer_stats_Tip_goal_forwardId",
                table: "Tips",
                column: "Tip_goal_forwardId",
                principalTable: "Footballer_stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tips_Footballer_stats_Tip_goal_midfielderId",
                table: "Tips",
                column: "Tip_goal_midfielderId",
                principalTable: "Footballer_stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
