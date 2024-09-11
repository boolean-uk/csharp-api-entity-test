using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class fourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "doctorId", "patientId" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "booking", "id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 7, 15, 48, 17, 765, DateTimeKind.Utc).AddTicks(7994), 1 },
                    { 4, 2, new DateTime(2025, 7, 5, 21, 51, 32, 765, DateTimeKind.Utc).AddTicks(8106), 2 },
                    { 5, 3, new DateTime(2024, 12, 26, 10, 43, 20, 765, DateTimeKind.Utc).AddTicks(8112), 3 },
                    { 5, 9, new DateTime(2025, 3, 31, 13, 31, 18, 765, DateTimeKind.Utc).AddTicks(8162), 9 },
                    { 6, 10, new DateTime(2024, 10, 3, 16, 49, 2, 765, DateTimeKind.Utc).AddTicks(8166), 10 },
                    { 7, 4, new DateTime(2025, 6, 4, 20, 12, 36, 765, DateTimeKind.Utc).AddTicks(8132), 4 },
                    { 7, 6, new DateTime(2025, 6, 27, 8, 54, 24, 765, DateTimeKind.Utc).AddTicks(8141), 6 },
                    { 7, 8, new DateTime(2025, 4, 25, 9, 14, 50, 765, DateTimeKind.Utc).AddTicks(8148), 8 },
                    { 8, 5, new DateTime(2025, 5, 14, 14, 39, 45, 765, DateTimeKind.Utc).AddTicks(8137), 5 },
                    { 8, 7, new DateTime(2025, 3, 21, 11, 40, 4, 765, DateTimeKind.Utc).AddTicks(8145), 7 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "NeoPresley");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "OprahAndersson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "AdamLothbrok");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "BarackLothbrok");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "ArnoldWinslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "DonaldMathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "AdamMathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "OprahMouse");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "MickeyWinfrey");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "OprahWinslow");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "ElvisXavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "DonaldMouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "MickeySchwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "MickeyXavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "ArnoldDuck");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "NeoDuck");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "FelixLothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "DonaldWinfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "DonaldDuck");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 6, 10 });

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
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 8, 7 });

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
    }
}
