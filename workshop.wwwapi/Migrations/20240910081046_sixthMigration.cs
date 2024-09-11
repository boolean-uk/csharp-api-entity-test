using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class sixthMigration : Migration
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
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 1, 8, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 2, 10, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 3, 2, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 5, 1, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 5, 5, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 6, 4, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 7, 6, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 8, 7, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 10, 3, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 10, 9, 0 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 2 });

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
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 3 });

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
                keyValues: new object[] { 6, 4 });

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
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 9 });

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
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "prescriptions",
                keyColumn: "id",
                keyValue: 5);

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
                name: "prescriptionId",
                table: "appointments");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "prescriptions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                    { 1, 2, new DateTime(2025, 8, 7, 21, 14, 37, 248, DateTimeKind.Utc).AddTicks(3014), 2 },
                    { 2, 10, new DateTime(2025, 8, 17, 13, 38, 23, 248, DateTimeKind.Utc).AddTicks(3110), 10 },
                    { 3, 7, new DateTime(2024, 11, 6, 16, 31, 31, 248, DateTimeKind.Utc).AddTicks(3099), 7 },
                    { 5, 5, new DateTime(2025, 5, 14, 2, 58, 28, 248, DateTimeKind.Utc).AddTicks(3086), 5 },
                    { 6, 3, new DateTime(2025, 6, 23, 14, 50, 17, 248, DateTimeKind.Utc).AddTicks(3037), 3 },
                    { 7, 4, new DateTime(2024, 10, 19, 4, 20, 49, 248, DateTimeKind.Utc).AddTicks(3047), 4 },
                    { 7, 8, new DateTime(2025, 2, 2, 23, 52, 32, 248, DateTimeKind.Utc).AddTicks(3102), 8 },
                    { 8, 6, new DateTime(2025, 4, 18, 14, 12, 57, 248, DateTimeKind.Utc).AddTicks(3095), 6 },
                    { 8, 9, new DateTime(2025, 5, 19, 2, 33, 43, 248, DateTimeKind.Utc).AddTicks(3106), 9 },
                    { 9, 1, new DateTime(2024, 12, 27, 22, 59, 38, 248, DateTimeKind.Utc).AddTicks(2908), 1 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Arnold Xavier");

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
                value: "Barack Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Felix Sandler");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Barack Winslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Donald Sandler");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Donald Lothbrok");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Elvis Lothbrok");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Arnold Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Mickey Duck");

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instructions", "name" },
                values: new object[] { "Put in coworker's food.", "Ultra Couch drops" });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow with water.", "Stupid Blue Pills", 83 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Mix with chicken noodle soup.", "Crazy Xanax", 7 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow with water.", "Dangerous Laxatives", 33 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Insert into rectum.", "Yummy Mushrooms", 6 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Consume with any meal.", "Yummy Leaves", 45 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Snort before tequila shot.", "Good Couch drops", 80 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Chew on it for 3 hours.", "Ultra Leaves", 60 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Disolve into drink of your choice.", "Dangerous Leaves", 80 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Chew on it for 3 hours.", "Yummy Leaves", 28 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Felix Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Arnold Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Felix Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Neo Winslow");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Elvis Andersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Donald Sandler");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Ragnar Xavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Barack Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Barack Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Felix Lothbrok");

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
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 7, 2 },
                    { 10, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 3, 4 },
                    { 1, 5 },
                    { 6, 5 },
                    { 8, 5 },
                    { 4, 6 },
                    { 8, 6 },
                    { 4, 7 },
                    { 5, 7 },
                    { 7, 8 },
                    { 9, 8 },
                    { 2, 9 },
                    { 3, 9 },
                    { 6, 9 },
                    { 7, 9 },
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
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 9, 1 });

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
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 3 });

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
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 6 });

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
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 9 });

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
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 10 });

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
                keyValue: 6);

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

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "prescriptions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "prescriptionId",
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
                columns: new[] { "doctorId", "patientId", "prescriptionId" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "prescriptionId", "booking", "id" },
                values: new object[,]
                {
                    { 1, 8, 0, new DateTime(2025, 8, 3, 22, 14, 37, 86, DateTimeKind.Utc).AddTicks(3007), 8 },
                    { 2, 10, 0, new DateTime(2025, 2, 7, 10, 26, 57, 86, DateTimeKind.Utc).AddTicks(3015), 10 },
                    { 3, 2, 0, new DateTime(2025, 5, 8, 15, 0, 23, 86, DateTimeKind.Utc).AddTicks(2926), 2 },
                    { 5, 1, 0, new DateTime(2025, 8, 6, 23, 50, 7, 86, DateTimeKind.Utc).AddTicks(2800), 1 },
                    { 5, 5, 0, new DateTime(2025, 4, 27, 14, 30, 4, 86, DateTimeKind.Utc).AddTicks(2991), 5 },
                    { 6, 4, 0, new DateTime(2025, 3, 17, 6, 44, 53, 86, DateTimeKind.Utc).AddTicks(2956), 4 },
                    { 7, 6, 0, new DateTime(2025, 7, 24, 19, 43, 42, 86, DateTimeKind.Utc).AddTicks(2999), 6 },
                    { 8, 7, 0, new DateTime(2025, 3, 16, 1, 34, 56, 86, DateTimeKind.Utc).AddTicks(3003), 7 },
                    { 10, 3, 0, new DateTime(2025, 6, 6, 14, 50, 20, 86, DateTimeKind.Utc).AddTicks(2948), 3 },
                    { 10, 9, 0, new DateTime(2024, 12, 13, 15, 16, 43, 86, DateTimeKind.Utc).AddTicks(3011), 9 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Elvis Winfrey");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Donald Xavier");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Donald Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Kate Xavier");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Barack Duck");

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
                value: "Kate Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Elvis Mouse");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Donald Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Neo Sandler");

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instructions", "name" },
                values: new object[] { "Insert into rectum.", "Dangerous Mushrooms" });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Consume with any meal.", "Super Drugs", 78 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Consume with any meal.", "Yummy Laxatives", 38 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Mix with chicken noodle soup.", "Yummy Potion", 56 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Put in coworker's food.", "Super Aspirin", 28 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Put in coworker's food.", "Ultra Potion", 95 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Disolve into drink of your choice.", "Bad Blue Pills", 28 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow with water.", "Blazing Heroin", 7 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Insert into rectum.", "Blazing Blue Pills", 15 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Inject with needle into the bloodstream.", "Dangerous Mushrooms", 17 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Barack Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Adam Xavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Arnold Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Arnold Mathiasson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Adam Winslow");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Mickey Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Donald Lothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Adam Andersson");

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
                value: "Arnold Xavier");

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
                    { 4, 1 },
                    { 1, 2 },
                    { 9, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 10, 3 },
                    { 5, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 8, 4 },
                    { 7, 6 },
                    { 10, 6 },
                    { 2, 7 },
                    { 1, 8 },
                    { 3, 8 },
                    { 4, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 6, 10 },
                    { 7, 10 },
                    { 8, 10 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_medicines_prescriptions_prescription_id",
                table: "prescription_medicines",
                column: "prescription_id",
                principalTable: "prescriptions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
