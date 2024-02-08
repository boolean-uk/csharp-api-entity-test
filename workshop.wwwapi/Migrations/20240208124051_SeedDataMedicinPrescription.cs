using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMedicinPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_Prescriptions_PrescriptionId",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_PrescriptionId",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8171), 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8177), 2, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8178), 2, 2 });

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "AppoinmentId",
                table: "Prescriptions",
                newName: "AppointmentId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_appointments_booking_patient_id_doctor_id",
                table: "appointments",
                columns: new[] { "booking", "patient_id", "doctor_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Name", "Note", "Quantity" },
                values: new object[,]
                {
                    { 1, "Ibuprofen", "Against Pain, take twice", 5 },
                    { 2, "Melatonin", "For sleep, take 2 hour before bed", 100 },
                    { 3, "Treo", "For fever and pain, take every 4-6 hours", 50 },
                    { 4, "Pencillin", "Antibiotic for infection, take three times a day", 30 }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Id", "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 8, 12, 40, 50, 776, DateTimeKind.Utc).AddTicks(63), 1, 2 },
                    { 2, new DateTime(2024, 2, 8, 12, 40, 50, 776, DateTimeKind.Utc).AddTicks(67), 2, 1 },
                    { 3, new DateTime(2024, 2, 8, 12, 40, 50, 776, DateTimeKind.Utc).AddTicks(69), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "AppointmentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "MedicinePrescription",
                columns: new[] { "MedicinesId", "PrescriptionsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 2 },
                    { 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_appointments_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_appointments_AppointmentId",
                table: "Prescriptions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_appointments_booking_patient_id_doctor_id",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "Prescriptions");

            migrationBuilder.DeleteData(
                table: "MedicinePrescription",
                keyColumns: new[] { "MedicinesId", "PrescriptionsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MedicinePrescription",
                keyColumns: new[] { "MedicinesId", "PrescriptionsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MedicinePrescription",
                keyColumns: new[] { "MedicinesId", "PrescriptionsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MedicinePrescription",
                keyColumns: new[] { "MedicinesId", "PrescriptionsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "MedicinePrescription",
                keyColumns: new[] { "MedicinesId", "PrescriptionsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MedicinePrescription",
                keyColumns: new[] { "MedicinesId", "PrescriptionsId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Prescriptions",
                newName: "AppoinmentId");

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "booking", "patient_id", "doctor_id" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id", "PrescriptionId" },
                values: new object[,]
                {
                    { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8171), 1, 2, null },
                    { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8177), 2, 1, null },
                    { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8178), 2, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PrescriptionId",
                table: "appointments",
                column: "PrescriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_Prescriptions_PrescriptionId",
                table: "appointments",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id");
        }
    }
}
