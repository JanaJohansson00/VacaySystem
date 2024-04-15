using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacaySystem.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FkVacayApplicationId",
                table: "Employees",
                newName: "VacayApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VacayApplicationId",
                table: "Employees",
                newName: "FkVacayApplicationId");
        }
    }
}
