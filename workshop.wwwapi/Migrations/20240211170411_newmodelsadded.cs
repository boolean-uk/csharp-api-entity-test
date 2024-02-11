using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class newmodelsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumn: "id",
                keyValue: 1,
                column: "booking",
                value: new DateTime(2024, 2, 11, 17, 4, 11, 125, DateTimeKind.Utc).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumn: "id",
                keyValue: 2,
                column: "booking",
                value: new DateTime(2024, 2, 11, 17, 4, 11, 125, DateTimeKind.Utc).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumn: "id",
                keyValue: 3,
                column: "booking",
                value: new DateTime(2024, 2, 11, 17, 4, 11, 125, DateTimeKind.Utc).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumn: "id",
                keyValue: 4,
                column: "booking",
                value: new DateTime(2024, 2, 11, 17, 4, 11, 125, DateTimeKind.Utc).AddTicks(2674));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumn: "id",
                keyValue: 1,
                column: "booking",
                value: new DateTime(2024, 1, 31, 13, 12, 59, 167, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumn: "id",
                keyValue: 2,
                column: "booking",
                value: new DateTime(2024, 1, 31, 13, 12, 59, 167, DateTimeKind.Utc).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumn: "id",
                keyValue: 3,
                column: "booking",
                value: new DateTime(2024, 1, 31, 13, 12, 59, 167, DateTimeKind.Utc).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumn: "id",
                keyValue: 4,
                column: "booking",
                value: new DateTime(2024, 1, 31, 13, 12, 59, 167, DateTimeKind.Utc).AddTicks(7404));
        }
    }
}
