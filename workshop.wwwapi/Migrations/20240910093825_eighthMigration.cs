using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class eighthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 4 });

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
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "prescriptions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "booking", "id" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 6, 7, 15, 2, 54, 123, DateTimeKind.Utc).AddTicks(793), 2 },
                    { 2, 3, new DateTime(2024, 12, 11, 12, 0, 38, 123, DateTimeKind.Utc).AddTicks(800), 3 },
                    { 2, 5, new DateTime(2024, 11, 1, 3, 15, 0, 123, DateTimeKind.Utc).AddTicks(807), 5 },
                    { 2, 7, new DateTime(2025, 1, 27, 21, 41, 7, 123, DateTimeKind.Utc).AddTicks(814), 7 },
                    { 3, 10, new DateTime(2025, 7, 16, 19, 41, 28, 123, DateTimeKind.Utc).AddTicks(824), 10 },
                    { 7, 4, new DateTime(2024, 12, 9, 11, 12, 34, 123, DateTimeKind.Utc).AddTicks(804), 4 },
                    { 7, 6, new DateTime(2025, 3, 12, 23, 6, 33, 123, DateTimeKind.Utc).AddTicks(811), 6 },
                    { 7, 8, new DateTime(2025, 2, 9, 10, 1, 12, 123, DateTimeKind.Utc).AddTicks(818), 8 },
                    { 9, 9, new DateTime(2024, 12, 23, 13, 17, 17, 123, DateTimeKind.Utc).AddTicks(820), 9 },
                    { 10, 1, new DateTime(2025, 2, 5, 16, 20, 35, 123, DateTimeKind.Utc).AddTicks(703), 1 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Arnold Winslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Elvis Mouse");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Mickey Andersson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Adam Sandler");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Neo Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Donald Andersson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Barack Sandler");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Felix Sandler");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Neo Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Elvis Mouse");

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow without anything added.", "Ultra Pills", 92 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Snort before tequila shot.", "Super Leaves", 18 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow with water.", "Yummy Heroin", 94 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Hide in cabinet and let the placebo effect do it's job.", "Dangerous Xanax", 2 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Put in coworker's food.", "Dangerous Aspirin", 6 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow with water.", "Stupid Pills", 12 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Disolve into drink of your choice.", "Ultra Mushrooms", 91 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Consume with any meal.", "Blazing Pills", 54 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Insert into rectum.", "Not Pills", 99 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Super Mushrooms", 98 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Oprah Andersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Felix Mathiasson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Charles Sandler");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Donald Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Arnold Lothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Kate Xavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Barack Mathiasson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Arnold Mathiasson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Charles Winslow");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Charles Xavier");

            migrationBuilder.InsertData(
                table: "prescription_medicines",
                columns: new[] { "medicine_id", "prescription_id" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 3, 3 },
                    { 5, 3 },
                    { 9, 3 },
                    { 7, 4 },
                    { 8, 4 },
                    { 1, 5 },
                    { 3, 5 },
                    { 6, 5 },
                    { 10, 5 },
                    { 2, 6 },
                    { 5, 6 },
                    { 2, 7 },
                    { 1, 9 },
                    { 4, 9 },
                    { 7, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "prescriptions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "booking", "id" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2024, 10, 7, 14, 58, 57, 625, DateTimeKind.Utc).AddTicks(9253), 2 },
                    { 3, 5, new DateTime(2025, 9, 7, 6, 50, 14, 625, DateTimeKind.Utc).AddTicks(9266), 5 },
                    { 6, 6, new DateTime(2025, 6, 26, 9, 39, 5, 625, DateTimeKind.Utc).AddTicks(9270), 6 },
                    { 6, 8, new DateTime(2024, 12, 20, 6, 28, 21, 625, DateTimeKind.Utc).AddTicks(9277), 8 },
                    { 7, 3, new DateTime(2025, 6, 20, 11, 53, 12, 625, DateTimeKind.Utc).AddTicks(9259), 3 },
                    { 7, 9, new DateTime(2024, 9, 22, 14, 35, 19, 625, DateTimeKind.Utc).AddTicks(9280), 9 },
                    { 7, 10, new DateTime(2025, 6, 3, 16, 31, 56, 625, DateTimeKind.Utc).AddTicks(9284), 10 },
                    { 9, 1, new DateTime(2025, 6, 23, 1, 49, 38, 625, DateTimeKind.Utc).AddTicks(9200), 1 },
                    { 9, 7, new DateTime(2025, 3, 8, 22, 33, 58, 625, DateTimeKind.Utc).AddTicks(9273), 7 },
                    { 10, 4, new DateTime(2025, 6, 11, 0, 55, 9, 625, DateTimeKind.Utc).AddTicks(9263), 4 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Elvis Winslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Elvis Mathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Adam Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Neo Mouse");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Neo Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Barack Mathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Mickey Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Adam Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Felix Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Donald Winfrey");

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Put in coworker's food.", "Bad Pills", 25 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow with water.", "Crazy Couch drops", 91 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Snort before tequila shot.", "Stupid Leaves", 1 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Insert into rectum.", "Ultra Couch drops", 14 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Mix with chicken noodle soup.", "Stupid Aspirin", 23 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Consume with any meal.", "Super Blue Pills", 14 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Mix with chicken noodle soup.", "Crazy Heroin", 76 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Insert into rectum.", "Ultra Heroin", 63 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Hide in cabinet and let the placebo effect do it's job.", "Not Leaves", 98 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Stupid Xanax", 93 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Kate Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Ragnar Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Barack Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Charles Sandler");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Elvis Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Neo Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Elvis Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Neo Xavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Oprah Lothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Arnold Mathiasson");

            migrationBuilder.InsertData(
                table: "prescription_medicines",
                columns: new[] { "medicine_id", "prescription_id" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 7, 1 },
                    { 3, 2 },
                    { 6, 2 },
                    { 2, 3 },
                    { 4, 3 },
                    { 7, 3 },
                    { 1, 4 },
                    { 3, 4 },
                    { 2, 5 },
                    { 5, 5 },
                    { 8, 5 },
                    { 9, 6 },
                    { 5, 8 },
                    { 9, 8 },
                    { 10, 8 },
                    { 8, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 4, 10 },
                    { 10, 10 }
                });
        }
    }
}
