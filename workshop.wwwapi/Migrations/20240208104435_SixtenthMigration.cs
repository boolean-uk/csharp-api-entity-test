using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SixtenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "perscriptionid",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "booking", "perscriptionid" },
                values: new object[] { new DateTime(2024, 2, 9, 10, 44, 34, 577, DateTimeKind.Utc).AddTicks(5634), 1 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "booking", "perscriptionid" },
                values: new object[] { new DateTime(2024, 2, 10, 10, 44, 34, 577, DateTimeKind.Utc).AddTicks(5654), 2 });

            migrationBuilder.InsertData(
                table: "medicines",
                columns: new[] { "id", "name", "notes", "quantity" },
                values: new object[,]
                {
                    { 1, "Ibuprofen", "Maximum 3 pills per day", 15 },
                    { 2, "Wondermedicine", "Infinite", 10 }
                });

            migrationBuilder.InsertData(
                table: "perscriptions",
                column: "id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "medicineperscriptions",
                columns: new[] { "medicineid", "perscriptionid" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_perscriptionid",
                table: "appointments",
                column: "perscriptionid");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_perscriptions_perscriptionid",
                table: "appointments",
                column: "perscriptionid",
                principalTable: "perscriptions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_perscriptions_perscriptionid",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_perscriptionid",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "medicineperscriptions",
                keyColumns: new[] { "medicineid", "perscriptionid" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "medicineperscriptions",
                keyColumns: new[] { "medicineid", "perscriptionid" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "medicineperscriptions",
                keyColumns: new[] { "medicineid", "perscriptionid" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "perscriptions",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "perscriptions",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "perscriptionid",
                table: "appointments");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 9, 9, 40, 41, 835, DateTimeKind.Utc).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 10, 9, 40, 41, 835, DateTimeKind.Utc).AddTicks(3970));
        }
    }
}
