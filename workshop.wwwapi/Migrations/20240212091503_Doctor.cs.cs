using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Doctorcs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 14, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3692), 5, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 23, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3689), 4, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 24, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3708), 2, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 26, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3701), 4, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 27, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3703), 5, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 29, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3671), 2, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 1, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3693), 2, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 1, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3695), 5, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 5, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3705), 2, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 3, 6, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3699), 2, 9 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new DateTime(2024, 2, 14, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3692), 5, 2 },
                    { new DateTime(2024, 2, 23, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3689), 4, 4 },
                    { new DateTime(2024, 2, 24, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3708), 2, 3 },
                    { new DateTime(2024, 2, 26, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3701), 4, 9 },
                    { new DateTime(2024, 2, 27, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3703), 5, 3 },
                    { new DateTime(2024, 2, 29, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3671), 2, 5 },
                    { new DateTime(2024, 3, 1, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3693), 2, 7 },
                    { new DateTime(2024, 3, 1, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3695), 5, 3 },
                    { new DateTime(2024, 3, 5, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3705), 2, 7 },
                    { new DateTime(2024, 3, 6, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3699), 2, 9 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "full_name",
                value: "Mick Trump");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "full_name",
                value: "Mick Winslet");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "full_name",
                value: "Barack Hepburn");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "full_name",
                value: "Oprah Winslet");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "full_name",
                value: "Jimi Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "full_name",
                value: "Donald Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "full_name",
                value: "Jimi Windsor");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "full_name",
                value: "Jimi Hendrix");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "full_name",
                value: "Audrey Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "full_name",
                value: "Elvis Hendrix");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "full_name",
                value: "Kate Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "full_name",
                value: "Charles Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "full_name",
                value: "Kate Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "full_name",
                value: "Charles Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "full_name",
                value: "Elvis Windsor");
        }
    }
}
