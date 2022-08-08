using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteDemo.Web.Migrations
{
    public partial class AddedPhotoOfFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Foods",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Foods");
        }
    }
}
