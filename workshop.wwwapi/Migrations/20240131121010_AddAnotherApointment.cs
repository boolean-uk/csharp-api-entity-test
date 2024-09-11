using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddAnotherApointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 10, 28, 43, 168, DateTimeKind.Utc).AddTicks(7706), 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 10, 28, 43, 168, DateTimeKind.Utc).AddTicks(7709), 2, 2 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3855), 1, 2 },
                    { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3860), 2, 2 },
                    { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3861), 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctor_id",
                table: "appointments",
                column: "doctor_id",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_patient_id",
                table: "appointments",
                column: "patient_id",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctor_id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patient_id",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_patient_id",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3855), 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3860), 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3861), 1, 2 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 1, 31, 10, 28, 43, 168, DateTimeKind.Utc).AddTicks(7706), 1, 2 },
                    { new DateTime(2024, 1, 31, 10, 28, 43, 168, DateTimeKind.Utc).AddTicks(7709), 2, 2 }
                });
        }
    }
}
