using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Patientcs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 14, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6548), 2, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 19, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6551), 1, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 21, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6544), 2, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 22, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6542), 5, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 29, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6546), 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 1, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6553), 4, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 2, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6555), 5, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 2, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6559), 3, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 5, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6556), 2, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 9, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6521), 4, 5 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 2, 21, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2070), 1, 6 },
                    { new DateTime(2024, 2, 21, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2074), 1, 5 },
                    { new DateTime(2024, 2, 22, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2051), 3, 10 },
                    { new DateTime(2024, 2, 23, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2070), 4, 2 },
                    { new DateTime(2024, 2, 26, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2072), 2, 8 },
                    { new DateTime(2024, 2, 29, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2073), 4, 8 },
                    { new DateTime(2024, 3, 2, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2068), 5, 8 },
                    { new DateTime(2024, 3, 2, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2076), 4, 4 },
                    { new DateTime(2024, 3, 7, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2069), 2, 4 },
                    { new DateTime(2024, 3, 7, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2074), 3, 9 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "full_name",
                value: "Oprah Winslet");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "full_name",
                value: "Jimi Trump");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "full_name",
                value: "Kate Hepburn");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "full_name",
                value: "Charles Hendrix");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "full_name",
                value: "Kate Windsor");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "full_name",
                value: "Charles Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "full_name",
                value: "Elvis Windsor");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "full_name",
                value: "Audrey Hendrix");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "full_name",
                value: "Mick Middleton");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "full_name",
                value: "Elvis Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "full_name",
                value: "Oprah Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "full_name",
                value: "Kate Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "full_name",
                value: "Kate Hendrix");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "full_name",
                value: "Kate Windsor");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "full_name",
                value: "Barack Winslet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 21, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2070), 1, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 21, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2074), 1, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 22, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2051), 3, 10 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 23, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2070), 4, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 26, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2072), 2, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 29, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2073), 4, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 2, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2068), 5, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 2, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2076), 4, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 7, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2069), 2, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 7, 9, 15, 31, 950, DateTimeKind.Utc).AddTicks(2074), 3, 9 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 2, 14, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6548), 2, 9 },
                    { new DateTime(2024, 2, 19, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6551), 1, 4 },
                    { new DateTime(2024, 2, 21, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6544), 2, 1 },
                    { new DateTime(2024, 2, 22, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6542), 5, 5 },
                    { new DateTime(2024, 2, 29, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6546), 2, 2 },
                    { new DateTime(2024, 3, 1, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6553), 4, 2 },
                    { new DateTime(2024, 3, 2, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6555), 5, 5 },
                    { new DateTime(2024, 3, 2, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6559), 3, 9 },
                    { new DateTime(2024, 3, 5, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6556), 2, 3 },
                    { new DateTime(2024, 3, 9, 9, 15, 2, 765, DateTimeKind.Utc).AddTicks(6521), 4, 5 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "full_name",
                value: "Elvis Hepburn");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "full_name",
                value: "Oprah Hepburn");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "full_name",
                value: "Kate Jagger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "full_name",
                value: "Charles Hepburn");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "full_name",
                value: "Charles Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "full_name",
                value: "Barack Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "full_name",
                value: "Oprah Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "full_name",
                value: "Charles Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "full_name",
                value: "Audrey Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "full_name",
                value: "Jimi Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "full_name",
                value: "Donald Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "full_name",
                value: "Barack Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "full_name",
                value: "Oprah Middleton");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "full_name",
                value: "Donald Middleton");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "full_name",
                value: "Mick Hepburn");
        }
    }
}
