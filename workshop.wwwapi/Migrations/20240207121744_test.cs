using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
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
                    name = table.Column<string>(type: "text", nullable: false)
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
                name: "Prescriptions",
                columns: table => new
                {
                    prescription_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_appointment_doctor_id = table.Column<int>(type: "integer", nullable: false),
                    fk_appointment_patient_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.prescription_id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    pk_booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fk_doctor_id = table.Column<int>(type: "integer", nullable: false),
                    fk_patient_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appoitment_doctor_patient_booking", x => new { x.fk_doctor_id, x.fk_patient_id, x.pk_booking });
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
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicines",
                columns: table => new
                {
                    fk_medicine_id = table.Column<int>(type: "integer", nullable: false),
                    fk_prescription_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine_prescription", x => new { x.fk_medicine_id, x.fk_prescription_id });
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_Medicines_fk_medicine_id",
                        column: x => x.fk_medicine_id,
                        principalTable: "Medicines",
                        principalColumn: "medicine_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_Prescriptions_fk_prescription_id",
                        column: x => x.fk_prescription_id,
                        principalTable: "Prescriptions",
                        principalColumn: "prescription_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "doctor_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Donald Middleton" },
                    { 2, "Elvis Windsor" },
                    { 3, "Oprah Winslet" },
                    { 4, "Mick Middleton" },
                    { 5, "Charles Winfrey" },
                    { 6, "Elvis Hepburn" },
                    { 7, "Kate Hepburn" },
                    { 8, "Oprah Trump" },
                    { 9, "Mick Windsor" },
                    { 10, "Mick Winslet" },
                    { 11, "Jimi Hendrix" },
                    { 12, "Kate Hendrix" },
                    { 13, "Audrey Presley" },
                    { 14, "Kate Obama" },
                    { 15, "Oprah Winfrey" },
                    { 16, "Donald Presley" },
                    { 17, "Charles Middleton" },
                    { 18, "Oprah Presley" },
                    { 19, "Kate Trump" }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "medicine_id", "name" },
                values: new object[,]
                {
                    { 1, "Pain killers" },
                    { 2, "Asthma medicine" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "patient_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Jimi Middleton" },
                    { 2, "Charles Presley" },
                    { 3, "Barack Winfrey" },
                    { 4, "Donald Hepburn" },
                    { 5, "Barack Hendrix" },
                    { 6, "Elvis Middleton" },
                    { 7, "Barack Windsor" },
                    { 8, "Charles Hepburn" },
                    { 9, "Donald Winfrey" },
                    { 10, "Mick Presley" },
                    { 11, "Audrey Obama" },
                    { 12, "Audrey Trump" },
                    { 13, "Audrey Middleton" },
                    { 14, "Donald Trump" },
                    { 15, "Charles Hepburn" },
                    { 16, "Elvis Presley" },
                    { 17, "Donald Winslet" },
                    { 18, "Barack Middleton" },
                    { 19, "Barack Jagger" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "pk_booking", "fk_doctor_id", "fk_patient_id" },
                values: new object[,]
                {
                    { new DateTime(2022, 4, 6, 22, 0, 0, 0, DateTimeKind.Utc), 1, 1 },
                    { new DateTime(2023, 5, 7, 22, 0, 0, 0, DateTimeKind.Utc), 1, 2 },
                    { new DateTime(2024, 6, 8, 22, 0, 0, 0, DateTimeKind.Utc), 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_fk_patient_id",
                table: "Appointments",
                column: "fk_patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicines_fk_prescription_id",
                table: "PrescriptionMedicines",
                column: "fk_prescription_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "PrescriptionMedicines");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Prescriptions");
        }
    }
}
