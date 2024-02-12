using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class inits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "appointment_type",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "appointment_type", "booking_date_time" },
                values: new object[] { 0, new DateTime(2024, 2, 12, 12, 29, 25, 589, DateTimeKind.Utc).AddTicks(1315) });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 3,
                column: "appointment_type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4,
                column: "appointment_type",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "appointment_type",
                table: "appointments");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2,
                column: "booking_date_time",
                value: new DateTime(2024, 2, 12, 11, 57, 2, 943, DateTimeKind.Utc).AddTicks(8579));
        }
    }
}
