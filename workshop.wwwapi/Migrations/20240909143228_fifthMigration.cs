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

            migrationBuilder.AddColumn<int>(
                name: "prescriptionId",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "prescriptionId" });

            migrationBuilder.CreateTable(
                name: "medicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    instructions = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prescription_medicines",
                columns: table => new
                {
                    prescription_id = table.Column<int>(type: "integer", nullable: false),
                    medicine_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription_medicines", x => new { x.prescription_id, x.medicine_id });
                    table.ForeignKey(
                        name: "FK_prescription_medicines_medicines_medicine_id",
                        column: x => x.medicine_id,
                        principalTable: "medicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescription_medicines_prescriptions_prescription_id",
                        column: x => x.prescription_id,
                        principalTable: "prescriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "prescriptionId", "booking", "id" },
                values: new object[,]
                {
                    { 1, 8, 0, new DateTime(2025, 8, 3, 22, 14, 37, 86, DateTimeKind.Utc).AddTicks(3007), 8 },
                    { 2, 10, 0, new DateTime(2025, 2, 7, 10, 26, 57, 86, DateTimeKind.Utc).AddTicks(3015), 10 },
                    { 3, 2, 0, new DateTime(2025, 5, 8, 15, 0, 23, 86, DateTimeKind.Utc).AddTicks(2926), 2 },
                    { 5, 1, 0, new DateTime(2025, 8, 6, 23, 50, 7, 86, DateTimeKind.Utc).AddTicks(2800), 1 },
                    { 5, 5, 0, new DateTime(2025, 4, 27, 14, 30, 4, 86, DateTimeKind.Utc).AddTicks(2991), 5 },
                    { 6, 4, 0, new DateTime(2025, 3, 17, 6, 44, 53, 86, DateTimeKind.Utc).AddTicks(2956), 4 },
                    { 7, 6, 0, new DateTime(2025, 7, 24, 19, 43, 42, 86, DateTimeKind.Utc).AddTicks(2999), 6 },
                    { 8, 7, 0, new DateTime(2025, 3, 16, 1, 34, 56, 86, DateTimeKind.Utc).AddTicks(3003), 7 },
                    { 10, 3, 0, new DateTime(2025, 6, 6, 14, 50, 20, 86, DateTimeKind.Utc).AddTicks(2948), 3 },
                    { 10, 9, 0, new DateTime(2024, 12, 13, 15, 16, 43, 86, DateTimeKind.Utc).AddTicks(3011), 9 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Elvis Winfrey");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Donald Xavier");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Donald Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Kate Xavier");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Barack Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Arnold Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Kate Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Elvis Mouse");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Donald Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Neo Sandler");

            migrationBuilder.InsertData(
                table: "medicines",
                columns: new[] { "id", "instructions", "name", "quantity" },
                values: new object[,]
                {
                    { 1, "Insert into rectum.", "Dangerous Mushrooms", 58 },
                    { 2, "Consume with any meal.", "Super Drugs", 78 },
                    { 3, "Consume with any meal.", "Yummy Laxatives", 38 },
                    { 4, "Mix with chicken noodle soup.", "Yummy Potion", 56 },
                    { 5, "Put in coworker's food.", "Super Aspirin", 28 },
                    { 6, "Put in coworker's food.", "Ultra Potion", 95 },
                    { 7, "Disolve into drink of your choice.", "Bad Blue Pills", 28 },
                    { 8, "Swallow with water.", "Blazing Heroin", 7 },
                    { 9, "Insert into rectum.", "Blazing Blue Pills", 15 },
                    { 10, "Inject with needle into the bloodstream.", "Dangerous Mushrooms", 17 }
                });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Barack Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Adam Xavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Arnold Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Arnold Mathiasson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Adam Winslow");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Mickey Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Donald Lothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Adam Andersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Oprah Lothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Arnold Xavier");

            migrationBuilder.InsertData(
                table: "prescriptions",
                column: "id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10
                });

            migrationBuilder.InsertData(
                table: "prescription_medicines",
                columns: new[] { "medicine_id", "prescription_id" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 9, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 9, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 10, 3 },
                    { 2, 4 },
                    { 5, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 8, 4 },
                    { 7, 6 },
                    { 10, 6 },
                    { 2, 7 },
                    { 8, 7 },
                    { 1, 8 },
                    { 3, 8 },
                    { 6, 8 },
                    { 10, 8 },
                    { 4, 9 },
                    { 5, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 6, 10 },
                    { 7, 10 },
                    { 8, 10 },
                    { 9, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_prescription_medicines_medicine_id",
                table: "prescription_medicines",
                column: "medicine_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prescription_medicines");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 1, 8, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 2, 10, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 3, 2, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 5, 1, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 5, 5, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 6, 4, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 7, 6, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 8, 7, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 10, 3, 0 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId", "prescriptionId" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 10, 9, 0 });

            migrationBuilder.DropColumn(
                name: "prescriptionId",
                table: "appointments");

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
                keyValue: 8,
                column: "fullName",
                value: "OprahSchwarzenegger");

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
    }
}
