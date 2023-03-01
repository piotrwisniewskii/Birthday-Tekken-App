using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthdayTekken.Migrations
{
    public partial class DbFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchMakers",
                table: "MatchMakers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchMakers",
                table: "MatchMakers",
                columns: new[] { "MatchMakerId", "ParticipantId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchMakers",
                table: "MatchMakers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchMakers",
                table: "MatchMakers",
                column: "MatchMakerId");
        }
    }
}
