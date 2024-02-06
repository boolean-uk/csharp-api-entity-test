using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class PGSSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 9, 11 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 14, 13 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 10, 16 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 7, 18 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 12, 24 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 8, 25 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 13, 28 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 5, 29 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "DoctorId", "PatientId", "appointmentDate", "id" },
                values: new object[,]
                {
                    { 12, 5, "03/09/2024 11:50:00", 12 },
                    { 5, 9, "12/01/2024 11:00:00", 5 },
                    { 13, 11, "11/21/2024 10:50:00", 13 },
                    { 3, 16, "07/18/2024 10:50:00", 3 },
                    { 4, 18, "09/16/2024 08:10:00", 4 },
                    { 10, 31, "11/18/2024 10:00:00", 10 },
                    { 7, 32, "08/06/2024 10:20:00", 7 },
                    { 14, 34, "05/12/2024 09:20:00", 14 },
                    { 6, 36, "02/01/2024 09:40:00", 6 },
                    { 8, 38, "12/20/2024 09:00:00", 8 },
                    { 9, 38, "07/25/2024 08:00:00", 9 },
                    { 11, 39, "12/23/2024 08:30:00", 11 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Emma Windsor");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Jimi Hepburn");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Arthur Hendrix");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Audrey Jagger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Barack Presley");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "Audrey Jacobsen");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "Arthur Hepburn");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "name",
                value: "Mick Winfrey");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 11,
                column: "name",
                value: "Oprah Olsen");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 13,
                column: "name",
                value: "Jimi Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 14,
                column: "name",
                value: "Jimi Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Audrey Hendrix");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Donald Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Donald Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Kate Hendrix");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Mick Jacobsen");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "Kate Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "Donald Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "name",
                value: "Oprah Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 11,
                column: "name",
                value: "Jimi Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 12,
                column: "name",
                value: "Emma Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 13,
                column: "name",
                value: "Arthur Trump");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 14,
                column: "name",
                value: "Mick Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 15,
                column: "name",
                value: "Arthur Windsor");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 16,
                column: "name",
                value: "Barack Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 17,
                column: "name",
                value: "Donald Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 18,
                column: "name",
                value: "Kate Windsor");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 19,
                column: "name",
                value: "Jimi Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 20,
                column: "name",
                value: "Jimi Hendrix");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 21,
                column: "name",
                value: "Arthur Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 22,
                column: "name",
                value: "Donald Middleton");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 23,
                column: "name",
                value: "Arthur Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 24,
                column: "name",
                value: "Elvis Olsen");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 25,
                column: "name",
                value: "Barack Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 26,
                column: "name",
                value: "Barack Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 27,
                column: "name",
                value: "Jimi Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 28,
                column: "name",
                value: "Arthur Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 29,
                column: "name",
                value: "Jimi Middleton");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 30,
                column: "name",
                value: "Arthur Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 31,
                column: "name",
                value: "Barack Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 32,
                column: "name",
                value: "Elvis Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 33,
                column: "name",
                value: "Audrey Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 34,
                column: "name",
                value: "Jimi Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 35,
                column: "name",
                value: "Kate Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 36,
                column: "name",
                value: "Oprah Windsor");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 37,
                column: "name",
                value: "Kate Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 38,
                column: "name",
                value: "Arthur Jacobsen");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 39,
                column: "name",
                value: "Mick Hepburn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 13, 11 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 3, 16 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 10, 31 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 7, 32 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 14, 34 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 6, 36 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 8, 38 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 9, 38 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 11, 39 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "DoctorId", "PatientId", "appointmentDate", "id" },
                values: new object[,]
                {
                    { 11, 4, "12/15/2024 08:30:00", 11 },
                    { 3, 10, "11/12/2024 08:30:00", 3 },
                    { 6, 11, "05/11/2024 08:00:00", 6 },
                    { 9, 11, "08/02/2024 10:20:00", 9 },
                    { 14, 13, "01/23/2024 10:20:00", 14 },
                    { 4, 15, "07/18/2024 11:50:00", 4 },
                    { 10, 16, "05/10/2024 10:50:00", 10 },
                    { 7, 18, "05/15/2024 10:10:00", 7 },
                    { 12, 24, "06/06/2024 09:10:00", 12 },
                    { 8, 25, "11/22/2024 09:30:00", 8 },
                    { 13, 28, "03/25/2024 08:30:00", 13 },
                    { 5, 29, "06/22/2024 09:50:00", 5 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Arthur Presley");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Arthur Jagger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Barack Presley");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Arthur Windsor");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Oprah Olsen");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "Mick Trump");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "Elvis Windsor");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "name",
                value: "Charles Winfrey");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 11,
                column: "name",
                value: "Oprah Jacobsen");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 13,
                column: "name",
                value: "Kate Olsen");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 14,
                column: "name",
                value: "Charles Trump");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Audrey Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Elvis Middleton");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Barack Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Mick Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Elvis Jacobsen");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "Audrey Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "Audrey Trump");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "name",
                value: "Arthur Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 11,
                column: "name",
                value: "Donald Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 12,
                column: "name",
                value: "Donald Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 13,
                column: "name",
                value: "Kate Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 14,
                column: "name",
                value: "Charles Trump");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 15,
                column: "name",
                value: "Charles Jacobsen");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 16,
                column: "name",
                value: "Barack Hendrix");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 17,
                column: "name",
                value: "Oprah Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 18,
                column: "name",
                value: "Charles Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 19,
                column: "name",
                value: "Kate Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 20,
                column: "name",
                value: "Barack Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 21,
                column: "name",
                value: "Jimi Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 22,
                column: "name",
                value: "Kate Olsen");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 23,
                column: "name",
                value: "Barack Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 24,
                column: "name",
                value: "Charles Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 25,
                column: "name",
                value: "Jimi Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 26,
                column: "name",
                value: "Charles Windsor");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 27,
                column: "name",
                value: "Jimi Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 28,
                column: "name",
                value: "Barack Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 29,
                column: "name",
                value: "Kate Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 30,
                column: "name",
                value: "Mick Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 31,
                column: "name",
                value: "Elvis Trump");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 32,
                column: "name",
                value: "Charles Olsen");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 33,
                column: "name",
                value: "Kate Olsen");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 34,
                column: "name",
                value: "Kate Trump");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 35,
                column: "name",
                value: "Donald Jagger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 36,
                column: "name",
                value: "Kate Jacobsen");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 37,
                column: "name",
                value: "Jimi Trump");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 38,
                column: "name",
                value: "Mick Windsor");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 39,
                column: "name",
                value: "Arthur Hepburn");
        }
    }
}
