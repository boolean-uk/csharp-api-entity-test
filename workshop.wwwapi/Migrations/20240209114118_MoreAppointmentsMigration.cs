using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class MoreAppointmentsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "booking", "doctor_id_fk", "patient_id_fk" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 2, 15, 0, 0, 0, DateTimeKind.Utc), 1, 2 },
                    { 3, new DateTime(2023, 2, 6, 15, 0, 0, 0, DateTimeKind.Utc), 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
