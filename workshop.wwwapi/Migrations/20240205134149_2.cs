using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "booking", "type" },
                values: new object[] { new DateTime(2024, 2, 7, 13, 41, 48, 952, DateTimeKind.Utc).AddTicks(4134), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "booking", "type" },
                values: new object[] { new DateTime(2024, 2, 8, 13, 41, 48, 952, DateTimeKind.Utc).AddTicks(4166), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "appointments");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 1,
                column: "booking",
                value: new DateTime(2024, 2, 5, 10, 34, 38, 728, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2,
                column: "booking",
                value: new DateTime(2024, 2, 6, 10, 34, 38, 728, DateTimeKind.Utc).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 3,
                column: "booking",
                value: new DateTime(2024, 2, 7, 10, 34, 38, 728, DateTimeKind.Utc).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4,
                column: "booking",
                value: new DateTime(2024, 2, 8, 10, 34, 38, 728, DateTimeKind.Utc).AddTicks(5983));
        }
    }
}
