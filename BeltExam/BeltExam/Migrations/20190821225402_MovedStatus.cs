using Microsoft.EntityFrameworkCore.Migrations;

namespace BeltExam.Migrations
{
    public partial class MovedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BidStatus",
                table: "Bids");

            migrationBuilder.AddColumn<int>(
                name: "HighestBid",
                table: "Bids",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "BidStatus",
                table: "Auctions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestBid",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "BidStatus",
                table: "Auctions");

            migrationBuilder.AddColumn<bool>(
                name: "BidStatus",
                table: "Bids",
                nullable: false,
                defaultValue: false);
        }
    }
}
