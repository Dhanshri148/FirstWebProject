using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthifyMe.Web.Migrations
{
    public partial class AddedDietAndExercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DietChartId",
                table: "Dietitions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Dietitions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fees",
                table: "Dietitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DietCharts",
                columns: table => new
                {
                    DietChartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietCharts", x => x.DietChartId);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseCategories",
                columns: table => new
                {
                    ExerciseCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategories", x => x.ExerciseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseName = table.Column<string>(nullable: true),
                    ExerciseCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseCategories_ExerciseCategoryId",
                        column: x => x.ExerciseCategoryId,
                        principalTable: "ExerciseCategories",
                        principalColumn: "ExerciseCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dietitions_DietChartId",
                table: "Dietitions",
                column: "DietChartId");

            migrationBuilder.CreateIndex(
                name: "IX_Dietitions_ExerciseId",
                table: "Dietitions",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseCategoryId",
                table: "Exercises",
                column: "ExerciseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dietitions_DietCharts_DietChartId",
                table: "Dietitions",
                column: "DietChartId",
                principalTable: "DietCharts",
                principalColumn: "DietChartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dietitions_Exercises_ExerciseId",
                table: "Dietitions",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dietitions_DietCharts_DietChartId",
                table: "Dietitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Dietitions_Exercises_ExerciseId",
                table: "Dietitions");

            migrationBuilder.DropTable(
                name: "DietCharts");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseCategories");

            migrationBuilder.DropIndex(
                name: "IX_Dietitions_DietChartId",
                table: "Dietitions");

            migrationBuilder.DropIndex(
                name: "IX_Dietitions_ExerciseId",
                table: "Dietitions");

            migrationBuilder.DropColumn(
                name: "DietChartId",
                table: "Dietitions");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Dietitions");

            migrationBuilder.DropColumn(
                name: "Fees",
                table: "Dietitions");
        }
    }
}
