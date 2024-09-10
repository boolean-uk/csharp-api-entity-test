using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class thirteenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 2, 7, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 3, 9, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 4, 4, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 4, 10, 10 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 5, 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 5, 6, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 9, 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 9, 3, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 10, 5, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 10, 8, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.RenameColumn(
                name: "type",
                table: "appointments",
                newName: "AppointmentType");

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "prescription_id", "booking", "id", "AppointmentType" },
                values: new object[,]
                {
                    { 2, 1, 1, new DateTime(2025, 5, 19, 7, 30, 35, 297, DateTimeKind.Utc).AddTicks(7011), 1, 0 },
                    { 3, 7, 7, new DateTime(2025, 6, 4, 21, 36, 42, 297, DateTimeKind.Utc).AddTicks(7196), 7, 0 },
                    { 4, 8, 8, new DateTime(2024, 9, 26, 22, 56, 29, 297, DateTimeKind.Utc).AddTicks(7206), 8, 0 },
                    { 6, 9, 9, new DateTime(2025, 1, 17, 11, 39, 32, 297, DateTimeKind.Utc).AddTicks(7210), 9, 0 },
                    { 7, 3, 3, new DateTime(2025, 5, 30, 0, 51, 14, 297, DateTimeKind.Utc).AddTicks(7145), 3, 1 },
                    { 7, 4, 4, new DateTime(2025, 8, 12, 21, 22, 45, 297, DateTimeKind.Utc).AddTicks(7175), 4, 0 },
                    { 7, 6, 6, new DateTime(2024, 12, 23, 22, 48, 57, 297, DateTimeKind.Utc).AddTicks(7191), 6, 1 },
                    { 9, 2, 2, new DateTime(2025, 5, 22, 13, 7, 40, 297, DateTimeKind.Utc).AddTicks(7138), 2, 1 },
                    { 9, 5, 5, new DateTime(2025, 8, 12, 18, 7, 54, 297, DateTimeKind.Utc).AddTicks(7185), 5, 0 },
                    { 10, 10, 10, new DateTime(2024, 11, 2, 1, 41, 13, 297, DateTimeKind.Utc).AddTicks(7215), 10, 0 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Mickey Mathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Oprah Winfrey");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Kate Winslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Kate Winslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Adam Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Arnold Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Mickey Mathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Adam Mathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Barack Xavier");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Ragnar Mathiasson");

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Inject with needle into the bloodstream.", "Ultra Aspirin", 98 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Lick over a long period of time.", "Ultra Aspirin", 2 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Inject with needle into the bloodstream.", "Yummy Drugs", 80 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Crazy Potion", 6 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow with water.", "Good Potion", 17 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow without anything added.", "Crazy Blue Pills", 40 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Lick over a long period of time.", "Crazy Mushrooms", 71 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Super Couch drops", 69 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Super Xanax", 20 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Hide in cabinet and let the placebo effect do it's job.", "Not Xanax", 65 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Felix Mathiasson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Neo Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Oprah Lothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Kate Andersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Donald Duck");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Charles Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Oprah Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Neo Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Oprah Andersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Donald Andersson");

            migrationBuilder.InsertData(
                table: "prescription_medicines",
                columns: new[] { "medicine_id", "prescription_id" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 10, 1 },
                    { 9, 2 },
                    { 3, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 8, 4 },
                    { 4, 5 },
                    { 6, 5 },
                    { 7, 5 },
                    { 4, 6 },
                    { 5, 6 },
                    { 10, 6 },
                    { 8, 7 },
                    { 5, 8 },
                    { 10, 8 },
                    { 1, 9 },
                    { 5, 10 },
                    { 6, 10 },
                    { 9, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 2, 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 3, 7, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 4, 8, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 6, 9, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 7, 3, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 7, 4, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 7, 6, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 9, 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 9, 5, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyValues: new object[] { 10, 10, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.RenameColumn(
                name: "AppointmentType",
                table: "appointments",
                newName: "type");

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "prescription_id", "booking", "id", "type" },
                values: new object[,]
                {
                    { 2, 7, 7, new DateTime(2024, 9, 22, 8, 42, 41, 237, DateTimeKind.Utc).AddTicks(7264), 7, 0 },
                    { 3, 9, 9, new DateTime(2024, 11, 13, 15, 6, 23, 237, DateTimeKind.Utc).AddTicks(7272), 9, 1 },
                    { 4, 4, 4, new DateTime(2025, 7, 28, 10, 27, 46, 237, DateTimeKind.Utc).AddTicks(7222), 4, 1 },
                    { 4, 10, 10, new DateTime(2025, 7, 30, 20, 45, 34, 237, DateTimeKind.Utc).AddTicks(7277), 10, 1 },
                    { 5, 2, 2, new DateTime(2025, 8, 29, 14, 22, 57, 237, DateTimeKind.Utc).AddTicks(7183), 2, 1 },
                    { 5, 6, 6, new DateTime(2025, 6, 13, 3, 19, 52, 237, DateTimeKind.Utc).AddTicks(7259), 6, 1 },
                    { 9, 1, 1, new DateTime(2024, 12, 8, 5, 22, 15, 237, DateTimeKind.Utc).AddTicks(7064), 1, 0 },
                    { 9, 3, 3, new DateTime(2025, 7, 5, 2, 19, 34, 237, DateTimeKind.Utc).AddTicks(7212), 3, 0 },
                    { 10, 5, 5, new DateTime(2024, 10, 30, 16, 51, 20, 237, DateTimeKind.Utc).AddTicks(7253), 5, 0 },
                    { 10, 8, 8, new DateTime(2025, 1, 6, 3, 57, 2, 237, DateTimeKind.Utc).AddTicks(7268), 8, 0 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Neo Andersson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Neo Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Donald Andersson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Neo Sandler");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Mickey Presley");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Charles Xavier");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Arnold Presley");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Charles Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Felix Winfrey");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Barack Mathiasson");

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Chew on it for 3 hours.", "Blazing Laxatives", 36 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Mix with chicken noodle soup.", "Crazy Blue Pills", 85 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Disolve into drink of your choice.", "Bad Drugs", 73 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Not Xanax", 75 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Mix with chicken noodle soup.", "Ultra Mushrooms", 66 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Hide in cabinet and let the placebo effect do it's job.", "Crazy Aspirin", 80 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Mix with chicken noodle soup.", "Yummy Xanax", 74 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Blazing Heroin", 12 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Blazing Xanax", 93 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Put in coworker's food.", "Not Potion", 93 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Donald Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Charles Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Kate Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Donald Xavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Neo Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Adam Duck");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Kate Winslow");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Ragnar Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Neo Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Barack Winfrey");

            migrationBuilder.InsertData(
                table: "prescription_medicines",
                columns: new[] { "medicine_id", "prescription_id" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 5, 2 },
                    { 7, 2 },
                    { 10, 2 },
                    { 6, 3 },
                    { 10, 3 },
                    { 5, 4 },
                    { 7, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 5, 5 },
                    { 8, 5 },
                    { 9, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 8, 6 },
                    { 9, 7 },
                    { 3, 8 },
                    { 6, 8 },
                    { 3, 9 },
                    { 6, 9 },
                    { 4, 10 },
                    { 10, 10 }
                });
        }
    }
}
