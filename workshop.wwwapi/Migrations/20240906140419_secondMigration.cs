using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PKAppointmentDocPatientBooking",
                table: "appointments",
                columns: new[] { "patientId", "doctorId", "booking" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctorId", "patientId", "id" },
                values: new object[,]
                {
                    { new DateTime(2025, 7, 13, 19, 48, 28, 614, DateTimeKind.Local).AddTicks(8668), 5, 1, 1 },
                    { new DateTime(2024, 11, 6, 13, 44, 46, 614, DateTimeKind.Local).AddTicks(8707), 7, 2, 2 },
                    { new DateTime(2025, 5, 6, 14, 37, 53, 614, DateTimeKind.Local).AddTicks(8710), 7, 3, 3 },
                    { new DateTime(2024, 9, 23, 4, 8, 25, 614, DateTimeKind.Local).AddTicks(8713), 9, 4, 4 },
                    { new DateTime(2025, 2, 22, 21, 8, 22, 614, DateTimeKind.Local).AddTicks(8715), 10, 5, 5 },
                    { new DateTime(2025, 6, 23, 20, 31, 43, 614, DateTimeKind.Local).AddTicks(8717), 4, 6, 6 },
                    { new DateTime(2024, 12, 1, 6, 36, 8, 614, DateTimeKind.Local).AddTicks(8719), 4, 7, 7 },
                    { new DateTime(2025, 7, 27, 8, 36, 10, 614, DateTimeKind.Local).AddTicks(8721), 9, 8, 8 },
                    { new DateTime(2024, 12, 16, 5, 58, 41, 614, DateTimeKind.Local).AddTicks(8723), 4, 9, 9 },
                    { new DateTime(2025, 8, 17, 6, 46, 18, 614, DateTimeKind.Local).AddTicks(8726), 4, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "fullName" },
                values: new object[,]
                {
                    { 1, "NeoWinfrey" },
                    { 2, "FelixSchwarzenegger" },
                    { 3, "MickeyWinslow" },
                    { 4, "ArnoldMouse" },
                    { 5, "ElvisObama" },
                    { 6, "FelixMathiasson" },
                    { 7, "MickeyPresley" },
                    { 8, "ArnoldWinslow" },
                    { 9, "DonaldSchwarzenegger" },
                    { 10, "OprahPresley" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "fullName" },
                values: new object[,]
                {
                    { 1, "AdamPresley" },
                    { 2, "ArnoldLothbrok" },
                    { 3, "OprahDuck" },
                    { 4, "DonaldDuck" },
                    { 5, "DonaldPresley" },
                    { 6, "NeoXavier" },
                    { 7, "ArnoldSchwarzenegger" },
                    { 8, "KateSchwarzenegger" },
                    { 9, "AdamSchwarzenegger" },
                    { 10, "ArnoldDuck" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PKAppointmentDocPatientBooking",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 7, 13, 19, 48, 28, 614, DateTimeKind.Local).AddTicks(8668), 5, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 11, 6, 13, 44, 46, 614, DateTimeKind.Local).AddTicks(8707), 7, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 5, 6, 14, 37, 53, 614, DateTimeKind.Local).AddTicks(8710), 7, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 9, 23, 4, 8, 25, 614, DateTimeKind.Local).AddTicks(8713), 9, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 2, 22, 21, 8, 22, 614, DateTimeKind.Local).AddTicks(8715), 10, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 6, 23, 20, 31, 43, 614, DateTimeKind.Local).AddTicks(8717), 4, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 12, 1, 6, 36, 8, 614, DateTimeKind.Local).AddTicks(8719), 4, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 7, 27, 8, 36, 10, 614, DateTimeKind.Local).AddTicks(8721), 9, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 12, 16, 5, 58, 41, 614, DateTimeKind.Local).AddTicks(8723), 4, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 8, 17, 6, 46, 18, 614, DateTimeKind.Local).AddTicks(8726), 4, 10 });

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10);

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
        }
    }
}
