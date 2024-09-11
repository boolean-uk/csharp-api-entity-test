using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class TablePrescriptionNullableAppointmentRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_appointments_AppointmentId",
                table: "Prescriptions");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Prescriptions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Id", "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 9, 8, 34, 46, 126, DateTimeKind.Utc).AddTicks(3870), 1, 2 },
                    { 2, new DateTime(2024, 2, 9, 8, 34, 46, 126, DateTimeKind.Utc).AddTicks(3883), 2, 1 },
                    { 3, new DateTime(2024, 2, 9, 8, 34, 46, 126, DateTimeKind.Utc).AddTicks(3884), 2, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_appointments_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_appointments_AppointmentId",
                table: "Prescriptions");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Prescriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Id", "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 8, 12, 40, 50, 776, DateTimeKind.Utc).AddTicks(63), 1, 2 },
                    { 2, new DateTime(2024, 2, 8, 12, 40, 50, 776, DateTimeKind.Utc).AddTicks(67), 2, 1 },
                    { 3, new DateTime(2024, 2, 8, 12, 40, 50, 776, DateTimeKind.Utc).AddTicks(69), 2, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_appointments_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
