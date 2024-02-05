using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class extension2_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "appointment_type",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "appointment_id", "patient_id" },
                keyValues: new object[] { 1, 1, 1 },
                column: "appointment_type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "appointment_id", "patient_id" },
                keyValues: new object[] { 1, 2, 1 },
                column: "appointment_type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "appointment_id", "patient_id" },
                keyValues: new object[] { 1, 3, 5 },
                column: "appointment_type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "appointment_id", "patient_id" },
                keyValues: new object[] { 1, 4, 5 },
                column: "appointment_type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "appointment_id", "patient_id" },
                keyValues: new object[] { 1, 5, 5 },
                column: "appointment_type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "appointment_id", "patient_id" },
                keyValues: new object[] { 3, 6, 5 },
                column: "appointment_type",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "appointment_type",
                table: "appointments");
        }
    }
}
