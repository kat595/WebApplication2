using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameclub = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    League_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Creation_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nick = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ifadmin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Footballers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footballers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Footballers_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gameweek = table.Column<int>(type: "int", nullable: false),
                    HomeId = table.Column<int>(type: "int", nullable: false),
                    AwayId = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false),
                    Goal_home = table.Column<int>(type: "int", nullable: false),
                    Goal_away = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchs_Clubs_AwayId",
                        column: x => x.AwayId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matchs_Clubs_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "League_founders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    FounderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League_founders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_League_founders_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_League_founders_Users_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "League_scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League_scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_League_scores_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_League_scores_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeagueUser",
                columns: table => new
                {
                    LeaguesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueUser", x => new { x.LeaguesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_LeagueUser_Leagues_LeaguesId",
                        column: x => x.LeaguesId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeagueUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Footballer_stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FootballerId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    If_goal = table.Column<int>(type: "int", nullable: false),
                    If_cleansheet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footballer_stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Footballer_stats_Footballers_FootballerId",
                        column: x => x.FootballerId,
                        principalTable: "Footballers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Footballer_stats_Matchs_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Odd_home = table.Column<double>(type: "float", nullable: false),
                    Odd_away = table.Column<double>(type: "float", nullable: false),
                    Odd_draw = table.Column<double>(type: "float", nullable: false),
                    Odd_under2 = table.Column<double>(type: "float", nullable: false),
                    Odd_over2 = table.Column<double>(type: "float", nullable: false),
                    Odd_goal_forward = table.Column<double>(type: "float", nullable: false),
                    Odd_goal_midfielder = table.Column<double>(type: "float", nullable: false),
                    Odd_goal_defender = table.Column<double>(type: "float", nullable: false),
                    Odd_cleansheet = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odds_Matchs_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    Tip_score = table.Column<int>(type: "int", nullable: false),
                    Goal_count = table.Column<int>(type: "int", nullable: false),
                    Tip_goal_home = table.Column<int>(type: "int", nullable: false),
                    Tip_goal_away = table.Column<int>(type: "int", nullable: false),
                    ForwardId = table.Column<int>(type: "int", nullable: false),
                    Tip_goal_forwardId = table.Column<int>(type: "int", nullable: false),
                    MidfielderId = table.Column<int>(type: "int", nullable: false),
                    Tip_goal_midfielderId = table.Column<int>(type: "int", nullable: false),
                    DefenderId = table.Column<int>(type: "int", nullable: false),
                    Tip_goal_defenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tips_Footballer_stats_Tip_goal_defenderId",
                        column: x => x.Tip_goal_defenderId,
                        principalTable: "Footballer_stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tips_Footballer_stats_Tip_goal_forwardId",
                        column: x => x.Tip_goal_forwardId,
                        principalTable: "Footballer_stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tips_Footballer_stats_Tip_goal_midfielderId",
                        column: x => x.Tip_goal_midfielderId,
                        principalTable: "Footballer_stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tips_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tips_Matchs_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Footballer_stats_FootballerId",
                table: "Footballer_stats",
                column: "FootballerId");

            migrationBuilder.CreateIndex(
                name: "IX_Footballer_stats_MatchId",
                table: "Footballer_stats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Footballers_ClubId",
                table: "Footballers",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_League_founders_FounderId",
                table: "League_founders",
                column: "FounderId");

            migrationBuilder.CreateIndex(
                name: "IX_League_founders_LeagueId",
                table: "League_founders",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_League_scores_LeagueId",
                table: "League_scores",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_League_scores_UserId",
                table: "League_scores",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueUser_UsersId",
                table: "LeagueUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_AwayId",
                table: "Matchs",
                column: "AwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_HomeId",
                table: "Matchs",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Odds_MatchId",
                table: "Odds",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_LeagueId",
                table: "Tips",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_MatchId",
                table: "Tips",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_Tip_goal_defenderId",
                table: "Tips",
                column: "Tip_goal_defenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_Tip_goal_forwardId",
                table: "Tips",
                column: "Tip_goal_forwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_Tip_goal_midfielderId",
                table: "Tips",
                column: "Tip_goal_midfielderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_UserId",
                table: "Tips",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "League_founders");

            migrationBuilder.DropTable(
                name: "League_scores");

            migrationBuilder.DropTable(
                name: "LeagueUser");

            migrationBuilder.DropTable(
                name: "Odds");

            migrationBuilder.DropTable(
                name: "Tips");

            migrationBuilder.DropTable(
                name: "Footballer_stats");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Footballers");

            migrationBuilder.DropTable(
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
