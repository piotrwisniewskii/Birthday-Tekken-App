using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthdayTekken.Migrations
{
    public partial class quickfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants_Tournaments",
                table: "Participants_Tournaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants_Tournaments",
                table: "Participants_Tournaments",
                columns: new[] { "ParticipantId", "TournamentId", "MatchMakerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants_Tournaments",
                table: "Participants_Tournaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants_Tournaments",
                table: "Participants_Tournaments",
                columns: new[] { "ParticipantId", "TournamentId" });
        }
    }
}
