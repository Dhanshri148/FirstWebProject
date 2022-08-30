using Microsoft.EntityFrameworkCore.Migrations;

namespace Healthifyme.Web.Migrations
{
    public partial class AddedKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DietitionId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DietitionId",
                table: "Customers",
                column: "DietitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Dietitions_DietitionId",
                table: "Customers",
                column: "DietitionId",
                principalTable: "Dietitions",
                principalColumn: "DietitionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Dietitions_DietitionId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_DietitionId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DietitionId",
                table: "Customers");
        }
    }
}
