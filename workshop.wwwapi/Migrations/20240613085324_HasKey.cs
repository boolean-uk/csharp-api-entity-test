using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class HasKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                column: "id");

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "bookings", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2871), 1, 1 },
                    { 2, new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2876), 2, 2 },
                    { 3, new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2877), 3, 3 },
                    { 4, new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2878), 4, 4 },
                    { 5, new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2880), 1, 4 },
                    { 6, new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2881), 2, 3 },
                    { 7, new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2882), 3, 2 },
                    { 8, new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2883), 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "doctor_id", "patient_id" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctor_id", "patient_id", "bookings", "id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6199), 1 },
                    { 1, 4, new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6208), 5 },
                    { 2, 2, new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6204), 2 },
                    { 2, 3, new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6209), 6 },
                    { 3, 2, new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6211), 7 },
                    { 3, 3, new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6206), 3 },
                    { 4, 1, new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6215), 8 },
                    { 4, 4, new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6207), 4 }
                });
        }
    }
}
