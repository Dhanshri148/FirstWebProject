using Microsoft.EntityFrameworkCore.Migrations;

namespace Healthifyme.Web.Migrations
{
    public partial class PaymentAndOtherOneTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DietCategoryId",
                table: "DietCharts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DietReceipeName",
                table: "DietCharts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceipeLink",
                table: "DietCharts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Customers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DietCategories",
                columns: table => new
                {
                    DietCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietCategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietCategories", x => x.DietCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietCharts_DietCategoryId",
                table: "DietCharts",
                column: "DietCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PaymentId",
                table: "Customers",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Payments_PaymentId",
                table: "Customers",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DietCharts_DietCategories_DietCategoryId",
                table: "DietCharts",
                column: "DietCategoryId",
                principalTable: "DietCategories",
                principalColumn: "DietCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Payments_PaymentId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_DietCharts_DietCategories_DietCategoryId",
                table: "DietCharts");

            migrationBuilder.DropTable(
                name: "DietCategories");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_DietCharts_DietCategoryId",
                table: "DietCharts");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PaymentId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DietCategoryId",
                table: "DietCharts");

            migrationBuilder.DropColumn(
                name: "DietReceipeName",
                table: "DietCharts");

            migrationBuilder.DropColumn(
                name: "ReceipeLink",
                table: "DietCharts");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Customers");
        }
    }
}
