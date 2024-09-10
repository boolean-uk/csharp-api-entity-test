using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class eleventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescription_medicines_prescriptions_prescription_id",
                table: "prescription_medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_prescriptions",
                table: "prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

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
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 4 });

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
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "appointmentId",
                keyColumnType: "integer",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "appointmentId",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "appointmentId",
                keyColumnType: "integer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "appointmentId",
                keyColumnType: "integer",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "appointmentId",
                keyColumnType: "integer",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "appointmentId",
                keyColumnType: "integer",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "appointmentId",
                keyColumnType: "integer",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "appointmentId",
                keyColumnType: "integer",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "appointmentId",
                keyColumnType: "integer",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "appointmentId",
                keyColumnType: "integer",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "appointmentId",
                table: "prescriptions");

            migrationBuilder.AddColumn<int>(
                name: "prescription_id",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_prescriptions",
                table: "prescriptions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "prescription_id" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "prescription_id", "booking", "id" },
                values: new object[,]
                {
                    { 2, 3, 3, new DateTime(2025, 6, 22, 11, 33, 13, 955, DateTimeKind.Utc).AddTicks(1960), 3 },
                    { 4, 6, 6, new DateTime(2024, 11, 4, 14, 56, 43, 955, DateTimeKind.Utc).AddTicks(1995), 6 },
                    { 4, 9, 9, new DateTime(2025, 8, 7, 17, 16, 17, 955, DateTimeKind.Utc).AddTicks(2011), 9 },
                    { 5, 2, 2, new DateTime(2025, 8, 18, 9, 37, 4, 955, DateTimeKind.Utc).AddTicks(1952), 2 },
                    { 5, 4, 4, new DateTime(2025, 5, 20, 2, 6, 52, 955, DateTimeKind.Utc).AddTicks(1982), 4 },
                    { 6, 1, 1, new DateTime(2024, 10, 18, 5, 38, 48, 955, DateTimeKind.Utc).AddTicks(1844), 1 },
                    { 6, 10, 10, new DateTime(2025, 8, 1, 3, 8, 56, 955, DateTimeKind.Utc).AddTicks(2015), 10 },
                    { 7, 5, 5, new DateTime(2024, 12, 21, 11, 34, 39, 955, DateTimeKind.Utc).AddTicks(1987), 5 },
                    { 7, 8, 8, new DateTime(2024, 9, 16, 1, 49, 53, 955, DateTimeKind.Utc).AddTicks(2002), 8 },
                    { 8, 7, 7, new DateTime(2024, 11, 5, 18, 26, 9, 955, DateTimeKind.Utc).AddTicks(1999), 7 }
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
                value: "Adam Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Arnold Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Elvis Mouse");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Charles Mouse");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Felix Lothbrok");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Felix Xavier");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Barack Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Elvis Lothbrok");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Arnold Andersson");

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Lick over a long period of time.", "Not Laxatives", 7 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Lick over a long period of time.", "Stupid Drugs", 89 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Chew on it for 3 hours.", "Yummy Aspirin", 87 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow with water.", "Super Mushrooms", 25 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Disolve into drink of your choice.", "Bad Pills", 99 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Lick over a long period of time.", "Ultra Laxatives", 86 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Yummy Morphine", 90 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Hide in cabinet and let the placebo effect do it's job.", "Bad Mushrooms", 99 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow with water.", "Bad Potion", 62 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Insert into rectum.", "Not Heroin", 63 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Neo Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Kate Lothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Oprah Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Neo Andersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Ragnar Winslow");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Barack Duck");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Adam Sandler");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Mickey Lothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Donald Andersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Kate Schwarzenegger");

            migrationBuilder.InsertData(
                table: "prescriptions",
                column: "id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10
                });

            migrationBuilder.InsertData(
                table: "prescription_medicines",
                columns: new[] { "medicine_id", "prescription_id" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 5, 1 },
                    { 8, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 9, 3 },
                    { 10, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 5, 4 },
                    { 2, 5 },
                    { 6, 6 },
                    { 8, 6 },
                    { 4, 7 },
                    { 7, 7 },
                    { 9, 7 },
                    { 1, 8 },
                    { 7, 8 },
                    { 10, 8 },
                    { 4, 9 },
                    { 6, 10 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_medicines_prescriptions_prescription_id",
                table: "prescription_medicines",
                column: "prescription_id",
                principalTable: "prescriptions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescription_medicines_prescriptions_prescription_id",
                table: "prescription_medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_prescriptions",
                table: "prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 2, 3, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 4, 6, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 4, 9, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 5, 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 5, 4, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 6, 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 6, 10, 10 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 7, 5, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 7, 8, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescription_id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 8, 7, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 3 });

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
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "prescription_id",
                table: "appointments");

            migrationBuilder.AddColumn<int>(
                name: "appointmentId",
                table: "prescriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_prescriptions",
                table: "prescriptions",
                column: "appointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "doctorId", "patientId" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "booking", "id" },
                values: new object[,]
                {
                    { 2, 3, new DateTime(2025, 9, 2, 13, 14, 4, 557, DateTimeKind.Utc).AddTicks(4852), 3 },
                    { 2, 5, new DateTime(2024, 12, 1, 19, 56, 57, 557, DateTimeKind.Utc).AddTicks(4861), 5 },
                    { 3, 8, new DateTime(2025, 7, 14, 3, 31, 12, 557, DateTimeKind.Utc).AddTicks(4872), 8 },
                    { 3, 9, new DateTime(2025, 5, 25, 0, 18, 15, 557, DateTimeKind.Utc).AddTicks(4876), 9 },
                    { 7, 6, new DateTime(2025, 6, 19, 2, 16, 37, 557, DateTimeKind.Utc).AddTicks(4865), 6 },
                    { 7, 7, new DateTime(2025, 5, 12, 1, 11, 22, 557, DateTimeKind.Utc).AddTicks(4869), 7 },
                    { 8, 10, new DateTime(2025, 8, 1, 13, 42, 49, 557, DateTimeKind.Utc).AddTicks(4879), 10 },
                    { 9, 1, new DateTime(2025, 3, 1, 12, 5, 58, 557, DateTimeKind.Utc).AddTicks(4758), 1 },
                    { 10, 2, new DateTime(2024, 12, 19, 12, 32, 27, 557, DateTimeKind.Utc).AddTicks(4847), 2 },
                    { 10, 4, new DateTime(2025, 3, 27, 3, 14, 25, 557, DateTimeKind.Utc).AddTicks(4857), 4 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Kate Mathiasson");

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
                value: "Neo Winfrey");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Oprah Presley");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Felix Mathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Elvis Winslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Elvis Andersson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Mickey Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Charles Sandler");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Arnold Presley");

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Consume with any meal.", "Bad Mushrooms", 19 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow without anything added.", "Crazy Xanax", 78 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Put in coworker's food.", "Super Pills", 54 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Snort before tequila shot.", "Ultra Pills", 29 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Put in coworker's food.", "Crazy Couch drops", 3 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Inject with needle into the bloodstream.", "Blazing Laxatives", 77 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Super Pills", 1 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Inject with needle into the bloodstream.", "Dangerous Morphine", 28 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Snort before tequila shot.", "Ultra Laxatives", 99 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Hide in cabinet and let the placebo effect do it's job.", "Stupid Laxatives", 48 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Kate Andersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Barack Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Felix Sandler");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Charles Duck");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Donald Sandler");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Donald Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Neo Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Donald Xavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Barack Sandler");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Neo Mathiasson");

            migrationBuilder.InsertData(
                table: "prescriptions",
                columns: new[] { "appointmentId", "id" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 2, 9 },
                    { 3, 8 },
                    { 4, 7 },
                    { 5, 6 },
                    { 6, 5 },
                    { 7, 4 },
                    { 8, 3 },
                    { 9, 2 },
                    { 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "prescription_medicines",
                columns: new[] { "medicine_id", "prescription_id" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 1 },
                    { 7, 1 },
                    { 1, 2 },
                    { 4, 2 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 4 },
                    { 3, 5 },
                    { 6, 5 },
                    { 10, 5 },
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 },
                    { 2, 8 },
                    { 4, 8 },
                    { 5, 9 },
                    { 6, 9 },
                    { 8, 9 },
                    { 9, 9 },
                    { 3, 10 },
                    { 5, 10 },
                    { 10, 10 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_medicines_prescriptions_prescription_id",
                table: "prescription_medicines",
                column: "prescription_id",
                principalTable: "prescriptions",
                principalColumn: "appointmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
