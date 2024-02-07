using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class editDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    medicine_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    medicine_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.medicine_id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "Presciptions",
                columns: table => new
                {
                    prescription_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presciptions", x => x.prescription_id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fk_doctor_id = table.Column<int>(type: "integer", nullable: false),
                    fk_patient_id = table.Column<int>(type: "integer", nullable: false),
                    fk_presciption_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment_doctor_patient_date", x => new { x.fk_doctor_id, x.fk_patient_id, x.booking });
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_fk_doctor_id",
                        column: x => x.fk_doctor_id,
                        principalTable: "Doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_fk_patient_id",
                        column: x => x.fk_patient_id,
                        principalTable: "Patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Presciptions_fk_presciption_id",
                        column: x => x.fk_presciption_id,
                        principalTable: "Presciptions",
                        principalColumn: "prescription_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicinePrescriptions",
                columns: table => new
                {
                    fk_prescription_id = table.Column<int>(type: "integer", nullable: false),
                    fk_medicine_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicineprescription_prescription_medicine", x => new { x.fk_prescription_id, x.fk_medicine_id });
                    table.ForeignKey(
                        name: "FK_MedicinePrescriptions_Medicines_fk_medicine_id",
                        column: x => x.fk_medicine_id,
                        principalTable: "Medicines",
                        principalColumn: "medicine_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinePrescriptions_Presciptions_fk_prescription_id",
                        column: x => x.fk_prescription_id,
                        principalTable: "Presciptions",
                        principalColumn: "prescription_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "doctor_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Dr. Heinz Doofenshmirtz" },
                    { 2, "Dr Johnny" }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "medicine_id", "medicine_name" },
                values: new object[,]
                {
                    { 1, "Paracetamol" },
                    { 2, "SleepEase Xtra" },
                    { 3, "Energix Boost" },
                    { 4, "FocusPlus Capsules" },
                    { 5, "Calmify Syrup" },
                    { 6, "JointFlex Gel" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "patient_id", "full_name" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Presciptions",
                column: "prescription_id",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "booking", "fk_doctor_id", "fk_patient_id", "fk_presciption_id" },
                values: new object[,]
                {
                    { new DateTime(2022, 4, 6, 22, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1 },
                    { new DateTime(2024, 2, 2, 23, 0, 0, 0, DateTimeKind.Utc), 1, 2, 2 },
                    { new DateTime(2024, 2, 6, 23, 0, 0, 0, DateTimeKind.Utc), 2, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "MedicinePrescriptions",
                columns: new[] { "fk_medicine_id", "fk_prescription_id", "notes", "quantity" },
                values: new object[,]
                {
                    { 1, 1, "two a day", 8 },
                    { 2, 1, "before bedtime", 15 },
                    { 3, 2, "one tablet daily", 30 },
                    { 4, 2, "morning with water", 20 },
                    { 5, 3, "5ml twice daily", 25 },
                    { 6, 3, "apply to joints as needed", 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_fk_patient_id",
                table: "Appointments",
                column: "fk_patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_fk_presciption_id",
                table: "Appointments",
                column: "fk_presciption_id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescriptions_fk_medicine_id",
                table: "MedicinePrescriptions",
                column: "fk_medicine_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "MedicinePrescriptions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Presciptions");
        }
    }
}
