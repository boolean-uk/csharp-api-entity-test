using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Mg = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.PatientId, x.DoctorId, x.Booking });
                    table.ForeignKey(
                        name: "FK_appointments_doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescribedMedicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Instructions = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    MedicineName = table.Column<string>(type: "text", nullable: false),
                    PrescriptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribedMedicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescribedMedicines_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Mg", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 10, "Bugfixol", 50 },
                    { 2, 30, "Patchorix", 90 },
                    { 3, 15, "Syntaxol", 100 },
                    { 4, 500, "Compilex", 20 },
                    { 5, 5, "PolyMorphix", 40 },
                    { 6, 32, "LambdaRelief", 90 },
                    { 7, 100, "Inheritex", 60 },
                    { 8, 1000, "Reactabool Forte", 10 }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Hannibal", "Lecter" },
                    { 2, "Henry", "Jones Jr." },
                    { 3, "Davy", "Jones" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Jane", "Dough" },
                    { 3, "Hughie", "Dodson" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 1 },
                    { 3, 1, 3 },
                    { 4, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Booking", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { new DateTime(2024, 9, 14, 12, 30, 0, 0, DateTimeKind.Utc), 1, 1 },
                    { new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc), 2, 1 },
                    { new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc), 3, 1 },
                    { new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc), 1, 2 },
                    { new DateTime(2024, 9, 14, 13, 30, 0, 0, DateTimeKind.Utc), 2, 2 },
                    { new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc), 3, 2 },
                    { new DateTime(2024, 9, 14, 13, 30, 0, 0, DateTimeKind.Utc), 1, 3 },
                    { new DateTime(2024, 9, 14, 13, 30, 0, 0, DateTimeKind.Utc), 2, 3 },
                    { new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "PrescribedMedicines",
                columns: new[] { "Id", "Amount", "Instructions", "MedicineName", "PrescriptionId" },
                values: new object[,]
                {
                    { 1, 2, "Take 1 before each TestRun", "Patchorix", 1 },
                    { 2, 1, "Take 2 before and 5 after deploying patch. Double amount if its friday", "Syntaxol", 1 },
                    { 3, 1, "Take as needed", "Compilex", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescribedMedicines_PrescriptionId",
                table: "PrescribedMedicines",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "PrescribedMedicines");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
