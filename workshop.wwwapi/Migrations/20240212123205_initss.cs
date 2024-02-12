using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class initss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2,
                column: "booking_date_time",
                value: new DateTime(2024, 2, 12, 12, 32, 5, 146, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4,
                column: "appointment_type",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2,
                column: "booking_date_time",
                value: new DateTime(2024, 2, 12, 12, 29, 25, 589, DateTimeKind.Utc).AddTicks(1315));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4,
                column: "appointment_type",
                value: 0);
        }
    }
}
