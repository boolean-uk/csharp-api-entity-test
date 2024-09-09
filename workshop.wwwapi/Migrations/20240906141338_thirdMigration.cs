using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class thirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PKAppointmentDocPatientBooking",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 7, 13, 19, 48, 28, 614, DateTimeKind.Local).AddTicks(8668), 5, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 11, 6, 13, 44, 46, 614, DateTimeKind.Local).AddTicks(8707), 7, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 5, 6, 14, 37, 53, 614, DateTimeKind.Local).AddTicks(8710), 7, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 9, 23, 4, 8, 25, 614, DateTimeKind.Local).AddTicks(8713), 9, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 2, 22, 21, 8, 22, 614, DateTimeKind.Local).AddTicks(8715), 10, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 6, 23, 20, 31, 43, 614, DateTimeKind.Local).AddTicks(8717), 4, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 12, 1, 6, 36, 8, 614, DateTimeKind.Local).AddTicks(8719), 4, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 7, 27, 8, 36, 10, 614, DateTimeKind.Local).AddTicks(8721), 9, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 12, 16, 5, 58, 41, 614, DateTimeKind.Local).AddTicks(8723), 4, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 8, 17, 6, 46, 18, 614, DateTimeKind.Local).AddTicks(8726), 4, 10 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentDocPatientBooking",
                table: "appointments",
                columns: new[] { "patientId", "doctorId", "booking" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctorId", "patientId", "id" },
                values: new object[,]
                {
                    { new DateTime(2025, 1, 12, 17, 21, 30, 176, DateTimeKind.Local).AddTicks(7484), 3, 1, 1 },
                    { new DateTime(2024, 11, 24, 11, 11, 14, 176, DateTimeKind.Local).AddTicks(7565), 1, 2, 2 },
                    { new DateTime(2025, 3, 12, 12, 57, 9, 176, DateTimeKind.Local).AddTicks(7569), 2, 3, 3 },
                    { new DateTime(2024, 10, 12, 23, 7, 44, 176, DateTimeKind.Local).AddTicks(7576), 2, 4, 4 },
                    { new DateTime(2025, 3, 18, 10, 54, 33, 176, DateTimeKind.Local).AddTicks(7584), 6, 5, 5 },
                    { new DateTime(2025, 3, 22, 4, 49, 13, 176, DateTimeKind.Local).AddTicks(7608), 3, 6, 6 },
                    { new DateTime(2025, 2, 21, 16, 37, 34, 176, DateTimeKind.Local).AddTicks(7611), 8, 7, 7 },
                    { new DateTime(2024, 11, 28, 14, 23, 27, 176, DateTimeKind.Local).AddTicks(7614), 2, 8, 8 },
                    { new DateTime(2024, 9, 28, 12, 45, 27, 176, DateTimeKind.Local).AddTicks(7618), 10, 9, 9 },
                    { new DateTime(2025, 9, 4, 21, 9, 5, 176, DateTimeKind.Local).AddTicks(7621), 4, 10, 10 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "ArnoldSchwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "NeoPresley");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "NeoSchwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "AdamXavier");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "ElvisWinslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "FelixMouse");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "ElvisAndersson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "AdamLothbrok");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "ElvisWinslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "FelixAndersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "BarackMouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "RagnarDuck");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "OprahLothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "MickeySchwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "ElvisSchwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "ElvisAndersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "NeoSandler");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "OprahSchwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "AdamObama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "CharlesObama");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctorId",
                table: "appointments",
                column: "doctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_patientId",
                table: "appointments",
                column: "patientId",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patientId",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentDocPatientBooking",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_doctorId",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 1, 12, 17, 21, 30, 176, DateTimeKind.Local).AddTicks(7484), 3, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 11, 24, 11, 11, 14, 176, DateTimeKind.Local).AddTicks(7565), 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 3, 12, 12, 57, 9, 176, DateTimeKind.Local).AddTicks(7569), 2, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 10, 12, 23, 7, 44, 176, DateTimeKind.Local).AddTicks(7576), 2, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 3, 18, 10, 54, 33, 176, DateTimeKind.Local).AddTicks(7584), 6, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 3, 22, 4, 49, 13, 176, DateTimeKind.Local).AddTicks(7608), 3, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 2, 21, 16, 37, 34, 176, DateTimeKind.Local).AddTicks(7611), 8, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 11, 28, 14, 23, 27, 176, DateTimeKind.Local).AddTicks(7614), 2, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2024, 9, 28, 12, 45, 27, 176, DateTimeKind.Local).AddTicks(7618), 10, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctorId", "patientId" },
                keyValues: new object[] { new DateTime(2025, 9, 4, 21, 9, 5, 176, DateTimeKind.Local).AddTicks(7621), 4, 10 });

            migrationBuilder.AddPrimaryKey(
                name: "PKAppointmentDocPatientBooking",
                table: "appointments",
                columns: new[] { "patientId", "doctorId", "booking" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctorId", "patientId", "id" },
                values: new object[,]
                {
                    { new DateTime(2025, 7, 13, 19, 48, 28, 614, DateTimeKind.Local).AddTicks(8668), 5, 1, 1 },
                    { new DateTime(2024, 11, 6, 13, 44, 46, 614, DateTimeKind.Local).AddTicks(8707), 7, 2, 2 },
                    { new DateTime(2025, 5, 6, 14, 37, 53, 614, DateTimeKind.Local).AddTicks(8710), 7, 3, 3 },
                    { new DateTime(2024, 9, 23, 4, 8, 25, 614, DateTimeKind.Local).AddTicks(8713), 9, 4, 4 },
                    { new DateTime(2025, 2, 22, 21, 8, 22, 614, DateTimeKind.Local).AddTicks(8715), 10, 5, 5 },
                    { new DateTime(2025, 6, 23, 20, 31, 43, 614, DateTimeKind.Local).AddTicks(8717), 4, 6, 6 },
                    { new DateTime(2024, 12, 1, 6, 36, 8, 614, DateTimeKind.Local).AddTicks(8719), 4, 7, 7 },
                    { new DateTime(2025, 7, 27, 8, 36, 10, 614, DateTimeKind.Local).AddTicks(8721), 9, 8, 8 },
                    { new DateTime(2024, 12, 16, 5, 58, 41, 614, DateTimeKind.Local).AddTicks(8723), 4, 9, 9 },
                    { new DateTime(2025, 8, 17, 6, 46, 18, 614, DateTimeKind.Local).AddTicks(8726), 4, 10, 10 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "NeoWinfrey");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "FelixSchwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "MickeyWinslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "ArnoldMouse");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "ElvisObama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "FelixMathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "MickeyPresley");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "ArnoldWinslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "DonaldSchwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "OprahPresley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "AdamPresley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "ArnoldLothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "OprahDuck");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "DonaldDuck");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "DonaldPresley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "NeoXavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "ArnoldSchwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "KateSchwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "AdamSchwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "ArnoldDuck");
        }
    }
}
