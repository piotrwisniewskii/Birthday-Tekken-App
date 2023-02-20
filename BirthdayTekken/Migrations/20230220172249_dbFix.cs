using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthdayTekken.Migrations
{
    public partial class dbFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Tournaments_Participant_ParticipantId",
                table: "Participants_Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.AddColumn<int>(
                name: "MatchMakerId",
                table: "Participants_Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_Tournaments_MatchMakerId",
                table: "Participants_Tournaments",
                column: "MatchMakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Tournaments_Matches_MatchMakerId",
                table: "Participants_Tournaments",
                column: "MatchMakerId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Tournaments_Participants_ParticipantId",
                table: "Participants_Tournaments",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Tournaments_Matches_MatchMakerId",
                table: "Participants_Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Tournaments_Participants_ParticipantId",
                table: "Participants_Tournaments");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Participants_Tournaments_MatchMakerId",
                table: "Participants_Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "MatchMakerId",
                table: "Participants_Tournaments");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Tournaments_Participant_ParticipantId",
                table: "Participants_Tournaments",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
