using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacaySystem.Migrations
{
    /// <inheritdoc />
    public partial class NewDataVacation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "vacayApplications",
                keyColumn: "VacayApplicationId",
                keyValue: 3,
                columns: new[] { "ApplicationDate", "FkEmployeeId" },
                values: new object[] { new DateTime(2024, 4, 10, 18, 51, 47, 71, DateTimeKind.Local).AddTicks(9470), 3 });

            migrationBuilder.UpdateData(
                table: "vacayApplications",
                keyColumn: "VacayApplicationId",
                keyValue: 4,
                column: "ApplicationDate",
                value: new DateTime(2024, 4, 10, 18, 51, 47, 71, DateTimeKind.Local).AddTicks(9546));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "vacayApplications",
                keyColumn: "VacayApplicationId",
                keyValue: 3,
                columns: new[] { "ApplicationDate", "FkEmployeeId" },
                values: new object[] { new DateTime(2024, 4, 10, 18, 47, 21, 593, DateTimeKind.Local).AddTicks(888), 5 });

            migrationBuilder.UpdateData(
                table: "vacayApplications",
                keyColumn: "VacayApplicationId",
                keyValue: 4,
                column: "ApplicationDate",
                value: new DateTime(2024, 4, 10, 18, 47, 21, 593, DateTimeKind.Local).AddTicks(987));
        }
    }
}
