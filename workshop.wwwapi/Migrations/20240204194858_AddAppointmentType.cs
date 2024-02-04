using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "appointment type",
                table: "appointment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1998, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                column: "appointment type",
                value: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "appointment type",
                table: "appointment");
        }
    }
}
