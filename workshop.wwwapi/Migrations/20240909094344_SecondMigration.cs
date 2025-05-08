using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "patients");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "doctors");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "appointments");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "patients",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "patients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "doctors",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "doctors",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_patients",
                table: "patients",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_doctors",
                table: "doctors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "DoctorId", "PatientId" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "DoctorId", "PatientId", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1512) },
                    { 1, 4, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1517) },
                    { 2, 2, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1514) },
                    { 2, 3, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1518) },
                    { 3, 2, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1518) },
                    { 3, 3, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1515) },
                    { 4, 1, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1519) },
                    { 4, 4, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1516) }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "fullName" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Doe" },
                    { 3, "John Smith" },
                    { 4, "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "fullName" },
                values: new object[,]
                {
                    { 1, "Anna Drijver" },
                    { 2, "Tom Cruise" },
                    { 3, "Gerogina Verbaan" },
                    { 4, "Daan Schuurmans" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_patients",
                table: "patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_doctors",
                table: "doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 4, 4 });

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

            migrationBuilder.RenameTable(
                name: "patients",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "doctors",
                newName: "Doctors");

            migrationBuilder.RenameTable(
                name: "appointments",
                newName: "Appointments");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "Patients",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Patients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "Doctors",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                columns: new[] { "DoctorId", "PatientId" });
        }
    }
}
