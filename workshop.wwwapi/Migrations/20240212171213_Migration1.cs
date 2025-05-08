using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.booking, x.doctor_id, x.patient_id });
                    table.ForeignKey(
                        name: "FK_appointments_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentDoctorId = table.Column<int>(type: "integer", nullable: false),
                    AppointmentPatientId = table.Column<int>(type: "integer", nullable: false),
                    AppointmentBooking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescriptions_appointments_AppointmentBooking_AppointmentDo~",
                        columns: x => new { x.AppointmentBooking, x.AppointmentDoctorId, x.AppointmentPatientId },
                        principalTable: "appointments",
                        principalColumns: new[] { "booking", "doctor_id", "patient_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicine",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "integer", nullable: false),
                    PrescriptionId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicine", x => new { x.PrescriptionId, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicine_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicine_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "MedicineId", "Name" },
                values: new object[,]
                {
                    { 1, "Amoxicillin" },
                    { 2, "Ibuprofen" },
                    { 3, "Paracetamol" },
                    { 4, "Ciprofloxacin" },
                    { 5, "Azithromycin" }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Charles Jagger" },
                    { 2, "Elvis Windsor" },
                    { 3, "Elvis Winfrey" },
                    { 4, "Donald Winfrey" },
                    { 5, "Audrey Presley" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Charles Trump" },
                    { 2, "Mick Hepburn" },
                    { 3, "Kate Presley" },
                    { 4, "Jimi Presley" },
                    { 5, "Elvis Obama" },
                    { 6, "Kate Windsor" },
                    { 7, "Kate Presley" },
                    { 8, "Elvis Windsor" },
                    { 9, "Audrey Hendrix" },
                    { 10, "Oprah Presley" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id", "Type" },
                values: new object[,]
                {
                    { new DateTime(2024, 2, 20, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9769), 5, 5, 1 },
                    { new DateTime(2024, 2, 24, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9768), 5, 9, 0 },
                    { new DateTime(2024, 2, 29, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9766), 4, 2, 0 },
                    { new DateTime(2024, 3, 4, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9768), 3, 6, 1 },
                    { new DateTime(2024, 3, 5, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9771), 5, 10, 0 },
                    { new DateTime(2024, 3, 6, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9767), 4, 8, 1 },
                    { new DateTime(2024, 3, 6, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9770), 1, 8, 1 },
                    { new DateTime(2024, 3, 8, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9753), 5, 5, 0 },
                    { new DateTime(2024, 3, 8, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9771), 5, 8, 1 },
                    { new DateTime(2024, 3, 12, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9772), 2, 6, 0 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "PrescriptionId", "AppointmentBooking", "AppointmentDoctorId", "AppointmentPatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 8, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9753), 5, 5 },
                    { 2, new DateTime(2024, 2, 29, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9766), 4, 2 },
                    { 3, new DateTime(2024, 3, 6, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9767), 4, 8 },
                    { 4, new DateTime(2024, 2, 24, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9768), 5, 9 },
                    { 5, new DateTime(2024, 3, 4, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9768), 3, 6 },
                    { 6, new DateTime(2024, 2, 20, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9769), 5, 5 },
                    { 7, new DateTime(2024, 3, 6, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9770), 1, 8 },
                    { 8, new DateTime(2024, 3, 8, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9771), 5, 8 },
                    { 9, new DateTime(2024, 3, 5, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9771), 5, 10 },
                    { 10, new DateTime(2024, 3, 12, 17, 12, 13, 475, DateTimeKind.Utc).AddTicks(9772), 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicine",
                columns: new[] { "MedicineId", "PrescriptionId", "Notes", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Take once daily", 1 },
                    { 2, 1, "Take once daily", 2 },
                    { 5, 1, "Take once daily", 1 },
                    { 2, 2, "Take once daily", 1 },
                    { 4, 2, "Take once daily", 4 },
                    { 1, 3, "Take once daily", 2 },
                    { 2, 3, "Take once daily", 2 },
                    { 5, 3, "Take once daily", 2 },
                    { 5, 4, "Take once daily", 1 },
                    { 3, 5, "Take once daily", 3 },
                    { 4, 5, "Take once daily", 1 },
                    { 2, 6, "Take once daily", 1 },
                    { 3, 6, "Take once daily", 2 },
                    { 1, 7, "Take once daily", 1 },
                    { 4, 8, "Take once daily", 4 },
                    { 1, 9, "Take once daily", 1 },
                    { 5, 9, "Take once daily", 3 },
                    { 3, 10, "Take once daily", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicine_MedicineId",
                table: "PrescriptionMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AppointmentBooking_AppointmentDoctorId_Appoin~",
                table: "Prescriptions",
                columns: new[] { "AppointmentBooking", "AppointmentDoctorId", "AppointmentPatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionMedicine");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
