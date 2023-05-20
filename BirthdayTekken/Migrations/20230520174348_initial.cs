using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirthdayTekken.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureURL",
                table: "Participants");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Participants",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Participants");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureURL",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
