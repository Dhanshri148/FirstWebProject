using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteDemo.Web.Migrations
{
    public partial class AddedFoodPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FoodPrice",
                table: "Foods",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodPrice",
                table: "Foods");
        }
    }
}
