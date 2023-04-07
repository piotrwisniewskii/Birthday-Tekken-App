using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthdayTekken.Migrations
{
    public partial class fix5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Matches_Matches_MatchId",
                table: "Participants_Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Matches_Participants_ParticipantId",
                table: "Participants_Matches");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Matches_Matches_MatchId",
                table: "Participants_Matches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Matches_Participants_ParticipantId",
                table: "Participants_Matches",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Matches_Matches_MatchId",
                table: "Participants_Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Matches_Participants_ParticipantId",
                table: "Participants_Matches");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Matches_Matches_MatchId",
                table: "Participants_Matches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Matches_Participants_ParticipantId",
                table: "Participants_Matches",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
