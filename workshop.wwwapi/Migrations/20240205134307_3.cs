using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "booking", "type" },
                values: new object[] { new DateTime(2024, 2, 5, 13, 43, 7, 266, DateTimeKind.Utc).AddTicks(1839), 1 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "booking", "type" },
                values: new object[] { new DateTime(2024, 2, 6, 13, 43, 7, 266, DateTimeKind.Utc).AddTicks(1841), 1 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 3,
                column: "booking",
                value: new DateTime(2024, 2, 7, 13, 43, 7, 266, DateTimeKind.Utc).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4,
                column: "booking",
                value: new DateTime(2024, 2, 8, 13, 43, 7, 266, DateTimeKind.Utc).AddTicks(1854));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "booking", "type" },
                values: new object[] { new DateTime(2024, 2, 5, 13, 41, 48, 952, DateTimeKind.Utc).AddTicks(4123), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "booking", "type" },
                values: new object[] { new DateTime(2024, 2, 6, 13, 41, 48, 952, DateTimeKind.Utc).AddTicks(4126), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 3,
                column: "booking",
                value: new DateTime(2024, 2, 7, 13, 41, 48, 952, DateTimeKind.Utc).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4,
                column: "booking",
                value: new DateTime(2024, 2, 8, 13, 41, 48, 952, DateTimeKind.Utc).AddTicks(4166));
        }
    }
}
