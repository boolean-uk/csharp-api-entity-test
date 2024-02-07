using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToDatatablesMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id_fk", "patient_id_fk" },
                keyValues: new object[] { new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id_fk", "patient_id_fk" },
                keyValues: new object[] { new DateTime(2020, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id_fk", "patient_id_fk" },
                keyValues: new object[] { new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id_fk", "patient_id_fk", "DoctorId", "id", "PatientId" },
                values: new object[,]
                {
                    { new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 3, null },
                    { new DateTime(2020, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, 1, null, 2, null },
                    { new DateTime(2020, 4, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id_fk", "patient_id_fk" },
                keyValues: new object[] { new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id_fk", "patient_id_fk" },
                keyValues: new object[] { new DateTime(2020, 1, 13, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id_fk", "patient_id_fk" },
                keyValues: new object[] { new DateTime(2020, 4, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id_fk", "patient_id_fk", "DoctorId", "id", "PatientId" },
                values: new object[,]
                {
                    { new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 3, null },
                    { new DateTime(2020, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, null, 2, null },
                    { new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null, 1, null }
                });
        }
    }
}
