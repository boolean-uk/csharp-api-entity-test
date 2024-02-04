using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentType2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1999, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                column: "appointment type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1997, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                column: "appointment type",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1999, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                column: "appointment type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1997, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                column: "appointment type",
                value: 0);
        }
    }
}
