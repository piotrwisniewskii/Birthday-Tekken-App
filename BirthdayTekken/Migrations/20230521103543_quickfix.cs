using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthdayTekken.Migrations
{
    public partial class quickfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayersNumber",
                table: "Tournaments");

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Participants_Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_Matches_TournamentId",
                table: "Participants_Matches",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Matches_Tournaments_TournamentId",
                table: "Participants_Matches",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Matches_Tournaments_TournamentId",
                table: "Participants_Matches");

            migrationBuilder.DropIndex(
                name: "IX_Participants_Matches_TournamentId",
                table: "Participants_Matches");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Participants_Matches");

            migrationBuilder.AddColumn<int>(
                name: "PlayersNumber",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
