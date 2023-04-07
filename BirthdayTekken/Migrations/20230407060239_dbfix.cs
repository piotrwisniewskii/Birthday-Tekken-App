using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthdayTekken.Migrations
{
    public partial class dbfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Matches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
