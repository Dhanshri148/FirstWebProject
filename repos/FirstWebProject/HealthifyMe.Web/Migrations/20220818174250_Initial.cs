using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthifyMe.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Dietitions",
                columns: table => new
                {
                    DietitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietitionName = table.Column<string>(type: "varchar(100)", nullable: false),
                    DietitionExperience = table.Column<int>(nullable: false),
                    ContactNumber = table.Column<long>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 120, nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dietitions", x => x.DietitionId);
                    table.ForeignKey(
                        name: "FK_Dietitions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dietitions_CategoryId",
                table: "Dietitions",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dietitions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
