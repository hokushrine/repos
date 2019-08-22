using Microsoft.EntityFrameworkCore.Migrations;

namespace BeltExam.Migrations
{
    public partial class MoveHighestBidToAuction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestBid",
                table: "Bids");

            migrationBuilder.AddColumn<int>(
                name: "HighestBid",
                table: "Auctions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestBid",
                table: "Auctions");

            migrationBuilder.AddColumn<int>(
                name: "HighestBid",
                table: "Bids",
                nullable: false,
                defaultValue: 0);
        }
    }
}
