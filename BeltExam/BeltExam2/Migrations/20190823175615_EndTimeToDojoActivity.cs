using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeltExam2.Migrations
{
    public partial class EndTimeToDojoActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "DojoActivitiesDb",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "DojoActivitiesDb");
        }
    }
}
