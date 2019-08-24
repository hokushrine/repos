using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeltExam2.Migrations
{
    public partial class ChangeDurationTypeOfDojoActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "DojoActivitiesDb",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Duration",
                table: "DojoActivitiesDb",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
