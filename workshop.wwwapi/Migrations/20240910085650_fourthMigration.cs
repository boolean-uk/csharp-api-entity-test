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
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 1, 3, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 4, 2, 2 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 2, 4, 4 },
                columns: new[] { "booking", "type" },
                values: new object[] { new DateTime(2024, 11, 17, 12, 42, 1, 255, DateTimeKind.Utc).AddTicks(5623), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 4, 1, 1 },
                columns: new[] { "booking", "type" },
                values: new object[] { new DateTime(2025, 3, 11, 20, 42, 7, 255, DateTimeKind.Utc).AddTicks(5516), 1 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "perscriptionId", "booking", "id", "type" },
                values: new object[,]
                {
                    { 3, 2, 2, new DateTime(2025, 2, 20, 17, 12, 10, 255, DateTimeKind.Utc).AddTicks(5613), 2, 0 },
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
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 3, 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 4, 3, 3 });

            migrationBuilder.DeleteData(
                table: "perscriptionMedicines",
                keyColumns: new[] { "medicineId", "perscriptionId" },
                keyValues: new object[] { 1, 1 });

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

            migrationBuilder.DropColumn(
                name: "type",
                table: "appointments");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 2, 4, 4 },
                column: "booking",
                value: new DateTime(2024, 10, 21, 10, 38, 53, 64, DateTimeKind.Utc).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "perscriptionId" },
                keyValues: new object[] { 4, 1, 1 },
                column: "booking",
                value: new DateTime(2025, 3, 30, 1, 2, 35, 64, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "perscriptionId", "booking", "id" },
                values: new object[,]
                {
                    { 1, 3, 3, new DateTime(2025, 1, 21, 17, 29, 19, 64, DateTimeKind.Utc).AddTicks(9854), 3 },
                    { 4, 2, 2, new DateTime(2024, 10, 23, 5, 30, 53, 64, DateTimeKind.Utc).AddTicks(9848), 2 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Barack Middleton");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Donald Hendrix");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Barack Windsor");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Charles Winfrey");

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Eat with chinese chicken stock", "Blazing Paracetamol", 3 });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Apply on your face and then take some air", "Dangerous Paracetamol", 5 });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Dilute with cooking Oil", "Super Laxatives", 8 });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instruction", "name", "quantity" },
                values: new object[] { "Eat with cocaine", "Dangerous Mold", 3 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Jimi Trump");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Barack Trump");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Donald Hepburn");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Barack Presley");

            migrationBuilder.InsertData(
                table: "perscriptionMedicines",
                columns: new[] { "medicineId", "perscriptionId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 4 }
                });
        }
    }
}
