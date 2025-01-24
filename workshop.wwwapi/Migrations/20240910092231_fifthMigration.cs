using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class fifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 2, 4, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 3, 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 4, 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 4, 3, 3 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "perscriptionId", "booking", "id", "type" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 7, 12, 20, 8, 3, 38, DateTimeKind.Utc).AddTicks(5600), 1, 0 },
                    { 1, 2, 2, new DateTime(2025, 5, 11, 12, 0, 15, 38, DateTimeKind.Utc).AddTicks(5691), 2, 0 },
                    { 1, 3, 3, new DateTime(2024, 9, 22, 20, 58, 6, 38, DateTimeKind.Utc).AddTicks(5696), 3, 1 },
                    { 1, 4, 4, new DateTime(2025, 3, 4, 6, 47, 40, 38, DateTimeKind.Utc).AddTicks(5700), 4, 1 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Charles Winslet");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Audrey Jagger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Mick Windsor");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Jimi Obama");

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Apply on your face and then take some alcohol", "Yummy Mold", 3 });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Swallow with water", "Bad Paracetamol", 5 });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Inject into arm and then take some air", "Dangerous Drugs", 7 });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Eat with air", "Super Drugs", 9 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Kate Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Audrey Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Elvis Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Mick Trump");

            migrationBuilder.InsertData(
                table: "perscriptionMedicines",
                columns: new[] { "medicineId", "perscriptionId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 1, 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 1, 3, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 1, 4, 4 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "perscriptionId", "booking", "id", "type" },
                values: new object[,]
                {
                    { 2, 4, 4, new DateTime(2024, 11, 17, 12, 42, 1, 255, DateTimeKind.Utc).AddTicks(5623), 4, 0 },
                    { 3, 2, 2, new DateTime(2025, 2, 20, 17, 12, 10, 255, DateTimeKind.Utc).AddTicks(5613), 2, 0 },
                    { 4, 1, 1, new DateTime(2025, 3, 11, 20, 42, 7, 255, DateTimeKind.Utc).AddTicks(5516), 1, 1 },
                    { 4, 3, 3, new DateTime(2025, 4, 2, 17, 47, 17, 255, DateTimeKind.Utc).AddTicks(5619), 3, 0 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Oprah Trump");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Oprah Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Kate Presley");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Oprah Hepburn");

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Eat with sand", "Ultra Mold", 7 });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Eat with sand", "Dangerous Mold", 8 });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Submerge in juice", "Bad Mold", 3 });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Eat with water", "Dangerous Drugs", 1 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Donald Winslet");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Charles Middleton");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Donald Middleton");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Elvis Hepburn");

            migrationBuilder.InsertData(
                table: "perscriptionMedicines",
                columns: new[] { "medicineId", "perscriptionId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 2 }
                });
        }
    }
}
