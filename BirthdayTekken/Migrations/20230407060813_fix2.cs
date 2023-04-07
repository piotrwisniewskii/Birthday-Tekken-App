using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthdayTekken.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants_Matches",
                table: "Participants_Matches");

            migrationBuilder.DropIndex(
                name: "IX_Participants_Matches_ParticipantId",
                table: "Participants_Matches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants_Matches",
                table: "Participants_Matches",
                columns: new[] { "ParticipantId", "MatchId" });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_Matches_MatchId",
                table: "Participants_Matches",
                column: "MatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants_Matches",
                table: "Participants_Matches");

            migrationBuilder.DropIndex(
                name: "IX_Participants_Matches_MatchId",
                table: "Participants_Matches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants_Matches",
                table: "Participants_Matches",
                columns: new[] { "MatchId", "ParticipantId" });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_Matches_ParticipantId",
                table: "Participants_Matches",
                column: "ParticipantId");
        }
    }
}
