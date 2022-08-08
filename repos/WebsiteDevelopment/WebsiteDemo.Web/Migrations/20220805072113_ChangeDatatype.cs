using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsiteDemo.Web.Migrations
{
    public partial class ChangeDatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
