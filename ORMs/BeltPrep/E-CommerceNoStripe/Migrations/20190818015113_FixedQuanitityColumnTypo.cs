using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceNoStripe.Migrations
{
    public partial class FixedQuanitityColumnTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quanity",
                table: "Products",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "Quanity");
        }
    }
}
