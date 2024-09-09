using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddDocAndAppoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "id",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "doctors");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "appointment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "doctors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "doctors",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Booking",
                table: "appointment",
                newName: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "appointment",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_doctors",
                table: "doctors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment",
                table: "appointment",
                columns: new[] { "DoctorId", "PatientId", "date" });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "TIKOKAS" },
                    { 2, "INSTRAAS" }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "date", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { new DateTime(1998, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { new DateTime(1999, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { new DateTime(1997, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_PatientId",
                table: "appointment",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_doctors_DoctorId",
                table: "appointment",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_patient_PatientId",
                table: "appointment",
                column: "PatientId",
                principalTable: "patient",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointment_doctors_DoctorId",
                table: "appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_appointment_patient_PatientId",
                table: "appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_doctors",
                table: "doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment",
                table: "appointment");

            migrationBuilder.DropIndex(
                name: "IX_appointment_PatientId",
                table: "appointment");

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1998, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1999, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1997, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 });

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "doctors",
                newName: "Doctors");

            migrationBuilder.RenameTable(
                name: "appointment",
                newName: "Appointments");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Doctors",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Appointments",
                newName: "Booking");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Booking",
                table: "Appointments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "id");

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 3, "AMOZP" },
                    { 4, "FaceP" }
                });
        }
    }
}
