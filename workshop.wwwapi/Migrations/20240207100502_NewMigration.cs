using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "medicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.id);
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
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    appointment_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    appointment_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.id);
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
                name: "prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    appointment_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_prescriptions_appointments_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "appointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescription_medicines",
                columns: table => new
                {
                    prescription_id = table.Column<int>(type: "integer", nullable: false),
                    medicine_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    note_from_doctor = table.Column<string>(type: "text", nullable: false)
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
                table: "doctors",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Specialist Doctor Joseph Morecola" },
                    { 2, "Professor Percival Sugarlove" },
                    { 3, "Doctor Eleanor Colagood" },
                    { 4, "Doctor Charlotte Sodamore" },
                    { 5, "Dr. Dorian Snackright" },
                    { 6, "Doc. Beatrice Chocomore" },
                    { 7, "Specialist Lavinia Colamore" },
                    { 8, "Doctor Alexander Candycraze" },
                    { 9, "Dr. Oliver Sugargood" },
                    { 10, "Master Dr. Genevieve Candycraze" },
                    { 11, "Prof. Dr. Charlotte Snackright" },
                    { 12, "Supreme Dr. Felicity Snackgood" },
                    { 13, "M.D. Ophelia Chocomore" },
                    { 14, "PhD Dr. Charles Sugarmore" },
                    { 15, "Professor Miranda Sodagood" },
                    { 16, "Specialist Indiana Candygood" },
                    { 17, "Prof. Dr. Beatrice Sugargood" },
                    { 18, "Master Dr. Anastasia Snackgood" },
                    { 19, "Doc. Nathaniel Jones" },
                    { 20, "PhD Dr. Anastasia Carbcrave" }
                });

            migrationBuilder.InsertData(
                table: "medicines",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Painkillers" },
                    { 2, "Sleeping Pills" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Anna Smith" },
                    { 2, "Frank Moore" },
                    { 3, "Anna Martinez" },
                    { 4, "John Garcia" },
                    { 5, "Emily Robinson" },
                    { 6, "Ben Garcia" },
                    { 7, "Ian Miller" },
                    { 8, "Jack Moore" },
                    { 9, "Jack Moore" },
                    { 10, "Beth Jackson" },
                    { 11, "Claire Johnson" },
                    { 12, "Ian Robinson" },
                    { 13, "Dave Moore" },
                    { 14, "Beth White" },
                    { 15, "Claire Taylor" },
                    { 16, "Ben Johnson" },
                    { 17, "Grace Williams" },
                    { 18, "Chris Smith" },
                    { 19, "Chris Taylor" },
                    { 20, "Dave Thomas" },
                    { 21, "John Moore" },
                    { 22, "Chris Garcia" },
                    { 23, "Julia Garcia" },
                    { 24, "Diane Anderson" },
                    { 25, "Emily Thompson" },
                    { 26, "Ben Williams" },
                    { 27, "Chris Harris" },
                    { 28, "Claire Brown" },
                    { 29, "Jack Martinez" },
                    { 30, "Julia Williams" },
                    { 31, "Anna Davis" },
                    { 32, "John Davis" },
                    { 33, "Frank Martin" },
                    { 34, "Beth Brown" },
                    { 35, "Dave Brown" },
                    { 36, "Frank Anderson" },
                    { 37, "Jack Johnson" },
                    { 38, "Anna Thomas" },
                    { 39, "Grace Jackson" },
                    { 40, "Emily White" },
                    { 41, "Grace Miller" },
                    { 42, "Emily Martin" },
                    { 43, "John Davis" },
                    { 44, "Greg Johnson" },
                    { 45, "Ian Wilson" },
                    { 46, "Diane Garcia" },
                    { 47, "Ben Robinson" },
                    { 48, "Grace Thomas" },
                    { 49, "Emily Garcia" },
                    { 50, "Anna Davis" },
                    { 51, "Chris White" },
                    { 52, "Emily Garcia" },
                    { 53, "Jack Martin" },
                    { 54, "Dave Martin" },
                    { 55, "Emily Wilson" },
                    { 56, "John White" },
                    { 57, "Julia Moore" },
                    { 58, "Anna Thompson" },
                    { 59, "Diane Taylor" },
                    { 60, "Chris Harris" },
                    { 61, "Anna Martinez" },
                    { 62, "Julia Williams" },
                    { 63, "John Thompson" },
                    { 64, "Dave White" },
                    { 65, "Beth Jackson" },
                    { 66, "Ben White" },
                    { 67, "Beth Brown" },
                    { 68, "Emily Robinson" },
                    { 69, "Jack Johnson" },
                    { 70, "Chris Martin" },
                    { 71, "Emily Wilson" },
                    { 72, "Chris Davis" },
                    { 73, "Frank Thomas" },
                    { 74, "Julia Williams" },
                    { 75, "Ian Martinez" },
                    { 76, "Jack Martin" },
                    { 77, "Ben Miller" },
                    { 78, "Dave Brown" },
                    { 79, "Diane Thomas" },
                    { 80, "Greg Smith" },
                    { 81, "Jack Martin" },
                    { 82, "Chris Anderson" },
                    { 83, "Beth Thomas" },
                    { 84, "Grace Wilson" },
                    { 85, "John Robinson" },
                    { 86, "Emily Moore" },
                    { 87, "Beth Taylor" },
                    { 88, "Dave Brown" },
                    { 89, "Beth Thompson" },
                    { 90, "Frank Taylor" },
                    { 91, "Greg Johnson" },
                    { 92, "Dave Martin" },
                    { 93, "Claire Martinez" },
                    { 94, "Greg Anderson" },
                    { 95, "Claire Moore" },
                    { 96, "Dave Miller" },
                    { 97, "Greg Thompson" },
                    { 98, "Emily Miller" },
                    { 99, "Chris Moore" },
                    { 100, "Chris Williams" },
                    { 101, "Diane Moore" },
                    { 102, "Chris Brown" },
                    { 103, "Ben Garcia" },
                    { 104, "Greg Thomas" },
                    { 105, "Greg Jackson" },
                    { 106, "Dave Johnson" },
                    { 107, "Dave Miller" },
                    { 108, "Frank Brown" },
                    { 109, "Greg Smith" },
                    { 110, "Diane Harris" },
                    { 111, "Greg Thomas" },
                    { 112, "Diane Brown" },
                    { 113, "Beth Anderson" },
                    { 114, "Chris Brown" },
                    { 115, "John White" },
                    { 116, "Ian Wilson" },
                    { 117, "Julia Jackson" },
                    { 118, "Julia Taylor" },
                    { 119, "Frank Wilson" },
                    { 120, "Diane Smith" },
                    { 121, "John Garcia" },
                    { 122, "John White" },
                    { 123, "Ian Williams" },
                    { 124, "Greg Harris" },
                    { 125, "Dave Harris" },
                    { 126, "Dave Miller" },
                    { 127, "Dave Wilson" },
                    { 128, "Greg Moore" },
                    { 129, "Emily Taylor" },
                    { 130, "Claire Williams" },
                    { 131, "John Johnson" },
                    { 132, "Emily Wilson" },
                    { 133, "Emily Martin" },
                    { 134, "Emily Davis" },
                    { 135, "Ben Miller" },
                    { 136, "John Thompson" },
                    { 137, "Dave Davis" },
                    { 138, "Claire Davis" },
                    { 139, "Frank Martin" },
                    { 140, "Greg Thomas" },
                    { 141, "Anna Martin" },
                    { 142, "Dave Martin" },
                    { 143, "Diane Jackson" },
                    { 144, "Diane Anderson" },
                    { 145, "Jack Johnson" },
                    { 146, "Chris Brown" },
                    { 147, "Jack Davis" },
                    { 148, "Diane White" },
                    { 149, "Chris Martin" },
                    { 150, "Emily Harris" },
                    { 151, "Jack Miller" },
                    { 152, "Diane Wilson" },
                    { 153, "Julia Brown" },
                    { 154, "Dave Jackson" },
                    { 155, "Anna Brown" },
                    { 156, "Emily Anderson" },
                    { 157, "Frank Harris" },
                    { 158, "Dave Martin" },
                    { 159, "Grace Jackson" },
                    { 160, "John Miller" },
                    { 161, "Greg Garcia" },
                    { 162, "Ian Robinson" },
                    { 163, "Anna Martin" },
                    { 164, "Emily Moore" },
                    { 165, "Julia Wilson" },
                    { 166, "Emily Smith" },
                    { 167, "Jack Johnson" },
                    { 168, "Emily White" },
                    { 169, "Grace Smith" },
                    { 170, "Ian Anderson" },
                    { 171, "Emily Jackson" },
                    { 172, "Beth Wilson" },
                    { 173, "Diane White" },
                    { 174, "Jack Williams" },
                    { 175, "Anna Robinson" },
                    { 176, "Jack Brown" },
                    { 177, "John Robinson" },
                    { 178, "Ian Wilson" },
                    { 179, "Emily Brown" },
                    { 180, "Frank Robinson" },
                    { 181, "Dave Miller" },
                    { 182, "Diane Johnson" },
                    { 183, "Claire Anderson" },
                    { 184, "Jack Martinez" },
                    { 185, "Beth Thomas" },
                    { 186, "Ian Jackson" },
                    { 187, "Greg Moore" },
                    { 188, "John Anderson" },
                    { 189, "Ben Harris" },
                    { 190, "Beth Robinson" },
                    { 191, "Ian Martinez" },
                    { 192, "Dave Johnson" },
                    { 193, "Jack Jackson" },
                    { 194, "Greg Miller" },
                    { 195, "Julia Smith" },
                    { 196, "Frank Miller" },
                    { 197, "Beth Moore" },
                    { 198, "Jack Martinez" },
                    { 199, "Julia Johnson" },
                    { 200, "John Moore" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "appointment_time", "doctor_id", "patient_id", "appointment_type" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 16, 30, 0, 0, DateTimeKind.Utc), 1, 1, "FollowUp" },
                    { 2, new DateTime(2024, 8, 9, 18, 0, 0, 0, DateTimeKind.Utc), 15, 103, "GeneralCheckUp" },
                    { 3, new DateTime(2024, 11, 22, 6, 0, 0, 0, DateTimeKind.Utc), 20, 119, "SpecialistAdvice" },
                    { 4, new DateTime(2025, 11, 30, 12, 0, 0, 0, DateTimeKind.Utc), 14, 160, "FollowUp" },
                    { 5, new DateTime(2025, 10, 25, 13, 0, 0, 0, DateTimeKind.Utc), 13, 60, "FollowUp" },
                    { 6, new DateTime(2025, 12, 8, 6, 0, 0, 0, DateTimeKind.Utc), 2, 137, "SpecialistAdvice" },
                    { 7, new DateTime(2025, 6, 2, 7, 0, 0, 0, DateTimeKind.Utc), 12, 40, "SpecialistAdvice" },
                    { 8, new DateTime(2025, 12, 16, 7, 0, 0, 0, DateTimeKind.Utc), 10, 126, "SpecialistAdvice" },
                    { 9, new DateTime(2025, 3, 4, 18, 0, 0, 0, DateTimeKind.Utc), 7, 77, "GeneralCheckUp" },
                    { 10, new DateTime(2025, 2, 10, 19, 0, 0, 0, DateTimeKind.Utc), 14, 126, "GeneralCheckUp" },
                    { 11, new DateTime(2024, 2, 10, 8, 0, 0, 0, DateTimeKind.Utc), 7, 195, "SpecialistAdvice" },
                    { 12, new DateTime(2025, 2, 7, 10, 0, 0, 0, DateTimeKind.Utc), 6, 168, "GeneralCheckUp" },
                    { 13, new DateTime(2025, 1, 7, 12, 0, 0, 0, DateTimeKind.Utc), 11, 164, "SpecialistAdvice" },
                    { 14, new DateTime(2024, 4, 20, 14, 0, 0, 0, DateTimeKind.Utc), 12, 90, "FollowUp" },
                    { 15, new DateTime(2024, 4, 21, 13, 0, 0, 0, DateTimeKind.Utc), 18, 40, "GeneralCheckUp" },
                    { 16, new DateTime(2025, 1, 4, 10, 0, 0, 0, DateTimeKind.Utc), 14, 76, "NutritinalCounseling" },
                    { 17, new DateTime(2024, 11, 1, 7, 0, 0, 0, DateTimeKind.Utc), 20, 29, "SpecialistAdvice" },
                    { 18, new DateTime(2025, 9, 14, 12, 0, 0, 0, DateTimeKind.Utc), 10, 104, "GeneralCheckUp" },
                    { 19, new DateTime(2024, 2, 29, 6, 0, 0, 0, DateTimeKind.Utc), 3, 81, "GeneralCheckUp" },
                    { 20, new DateTime(2025, 10, 24, 14, 0, 0, 0, DateTimeKind.Utc), 6, 74, "FollowUp" },
                    { 21, new DateTime(2024, 3, 17, 9, 0, 0, 0, DateTimeKind.Utc), 6, 123, "GeneralCheckUp" },
                    { 22, new DateTime(2024, 10, 29, 16, 0, 0, 0, DateTimeKind.Utc), 12, 196, "FollowUp" },
                    { 23, new DateTime(2024, 12, 28, 10, 0, 0, 0, DateTimeKind.Utc), 17, 188, "SpecialistAdvice" },
                    { 24, new DateTime(2024, 5, 15, 12, 0, 0, 0, DateTimeKind.Utc), 13, 104, "SpecialistAdvice" },
                    { 25, new DateTime(2024, 9, 28, 11, 0, 0, 0, DateTimeKind.Utc), 20, 117, "SpecialistAdvice" },
                    { 26, new DateTime(2025, 10, 18, 8, 0, 0, 0, DateTimeKind.Utc), 9, 64, "SpecialistAdvice" },
                    { 27, new DateTime(2025, 5, 4, 10, 0, 0, 0, DateTimeKind.Utc), 13, 93, "FollowUp" },
                    { 28, new DateTime(2024, 8, 8, 9, 0, 0, 0, DateTimeKind.Utc), 1, 115, "GeneralCheckUp" },
                    { 29, new DateTime(2024, 8, 3, 10, 0, 0, 0, DateTimeKind.Utc), 6, 191, "SpecialistAdvice" },
                    { 30, new DateTime(2024, 10, 3, 13, 0, 0, 0, DateTimeKind.Utc), 10, 90, "GeneralCheckUp" },
                    { 31, new DateTime(2025, 6, 12, 13, 0, 0, 0, DateTimeKind.Utc), 3, 117, "FollowUp" },
                    { 32, new DateTime(2024, 6, 26, 6, 0, 0, 0, DateTimeKind.Utc), 1, 86, "SpecialistAdvice" },
                    { 33, new DateTime(2025, 5, 29, 13, 0, 0, 0, DateTimeKind.Utc), 11, 87, "GeneralCheckUp" },
                    { 34, new DateTime(2024, 10, 20, 17, 0, 0, 0, DateTimeKind.Utc), 11, 60, "SpecialistAdvice" },
                    { 35, new DateTime(2025, 7, 19, 19, 0, 0, 0, DateTimeKind.Utc), 15, 193, "FollowUp" },
                    { 36, new DateTime(2025, 2, 21, 9, 0, 0, 0, DateTimeKind.Utc), 15, 156, "SpecialistAdvice" },
                    { 37, new DateTime(2025, 4, 5, 8, 0, 0, 0, DateTimeKind.Utc), 9, 132, "FollowUp" },
                    { 38, new DateTime(2024, 6, 16, 7, 0, 0, 0, DateTimeKind.Utc), 9, 106, "SpecialistAdvice" },
                    { 39, new DateTime(2025, 5, 14, 8, 0, 0, 0, DateTimeKind.Utc), 10, 60, "GeneralCheckUp" },
                    { 40, new DateTime(2025, 8, 6, 12, 0, 0, 0, DateTimeKind.Utc), 20, 176, "SpecialistAdvice" },
                    { 41, new DateTime(2024, 5, 28, 17, 0, 0, 0, DateTimeKind.Utc), 20, 122, "SpecialistAdvice" },
                    { 42, new DateTime(2025, 4, 24, 13, 0, 0, 0, DateTimeKind.Utc), 10, 10, "NutritinalCounseling" },
                    { 43, new DateTime(2024, 11, 1, 11, 0, 0, 0, DateTimeKind.Utc), 11, 9, "SpecialistAdvice" },
                    { 44, new DateTime(2024, 6, 2, 9, 0, 0, 0, DateTimeKind.Utc), 13, 160, "NutritinalCounseling" },
                    { 45, new DateTime(2025, 4, 6, 11, 0, 0, 0, DateTimeKind.Utc), 8, 86, "NutritinalCounseling" },
                    { 46, new DateTime(2024, 2, 13, 15, 0, 0, 0, DateTimeKind.Utc), 11, 128, "FollowUp" },
                    { 47, new DateTime(2024, 7, 25, 8, 0, 0, 0, DateTimeKind.Utc), 12, 11, "NutritinalCounseling" },
                    { 48, new DateTime(2025, 3, 30, 19, 0, 0, 0, DateTimeKind.Utc), 10, 27, "NutritinalCounseling" },
                    { 49, new DateTime(2025, 1, 4, 7, 0, 0, 0, DateTimeKind.Utc), 15, 87, "NutritinalCounseling" },
                    { 50, new DateTime(2025, 9, 11, 6, 0, 0, 0, DateTimeKind.Utc), 7, 86, "SpecialistAdvice" },
                    { 51, new DateTime(2024, 3, 25, 8, 0, 0, 0, DateTimeKind.Utc), 5, 40, "FollowUp" },
                    { 52, new DateTime(2025, 12, 15, 6, 0, 0, 0, DateTimeKind.Utc), 7, 25, "GeneralCheckUp" },
                    { 53, new DateTime(2024, 6, 8, 7, 0, 0, 0, DateTimeKind.Utc), 3, 166, "GeneralCheckUp" },
                    { 54, new DateTime(2024, 10, 15, 8, 0, 0, 0, DateTimeKind.Utc), 14, 134, "SpecialistAdvice" },
                    { 55, new DateTime(2025, 12, 3, 13, 0, 0, 0, DateTimeKind.Utc), 5, 45, "FollowUp" },
                    { 56, new DateTime(2024, 4, 1, 10, 0, 0, 0, DateTimeKind.Utc), 14, 183, "GeneralCheckUp" },
                    { 57, new DateTime(2025, 1, 25, 12, 0, 0, 0, DateTimeKind.Utc), 2, 76, "SpecialistAdvice" },
                    { 58, new DateTime(2024, 2, 5, 6, 0, 0, 0, DateTimeKind.Utc), 5, 158, "NutritinalCounseling" },
                    { 59, new DateTime(2025, 11, 21, 18, 0, 0, 0, DateTimeKind.Utc), 3, 149, "SpecialistAdvice" },
                    { 60, new DateTime(2024, 3, 30, 16, 0, 0, 0, DateTimeKind.Utc), 14, 192, "SpecialistAdvice" },
                    { 61, new DateTime(2025, 6, 29, 9, 0, 0, 0, DateTimeKind.Utc), 13, 161, "GeneralCheckUp" },
                    { 62, new DateTime(2024, 2, 12, 8, 0, 0, 0, DateTimeKind.Utc), 13, 167, "FollowUp" },
                    { 63, new DateTime(2024, 4, 15, 19, 0, 0, 0, DateTimeKind.Utc), 9, 29, "NutritinalCounseling" },
                    { 64, new DateTime(2024, 11, 28, 8, 0, 0, 0, DateTimeKind.Utc), 13, 185, "SpecialistAdvice" },
                    { 65, new DateTime(2025, 7, 22, 9, 0, 0, 0, DateTimeKind.Utc), 5, 23, "SpecialistAdvice" },
                    { 66, new DateTime(2024, 12, 3, 18, 0, 0, 0, DateTimeKind.Utc), 19, 132, "SpecialistAdvice" },
                    { 67, new DateTime(2024, 1, 16, 13, 0, 0, 0, DateTimeKind.Utc), 13, 32, "NutritinalCounseling" },
                    { 68, new DateTime(2025, 6, 27, 18, 0, 0, 0, DateTimeKind.Utc), 15, 34, "NutritinalCounseling" },
                    { 69, new DateTime(2025, 3, 22, 17, 0, 0, 0, DateTimeKind.Utc), 14, 105, "GeneralCheckUp" },
                    { 70, new DateTime(2024, 6, 8, 9, 0, 0, 0, DateTimeKind.Utc), 1, 118, "SpecialistAdvice" },
                    { 71, new DateTime(2025, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 4, 115, "GeneralCheckUp" },
                    { 72, new DateTime(2025, 9, 30, 6, 0, 0, 0, DateTimeKind.Utc), 13, 65, "FollowUp" },
                    { 73, new DateTime(2025, 5, 4, 19, 0, 0, 0, DateTimeKind.Utc), 17, 35, "NutritinalCounseling" },
                    { 74, new DateTime(2025, 9, 10, 10, 0, 0, 0, DateTimeKind.Utc), 19, 147, "SpecialistAdvice" },
                    { 75, new DateTime(2025, 10, 5, 11, 0, 0, 0, DateTimeKind.Utc), 14, 76, "GeneralCheckUp" },
                    { 76, new DateTime(2024, 1, 24, 14, 0, 0, 0, DateTimeKind.Utc), 7, 29, "GeneralCheckUp" },
                    { 77, new DateTime(2025, 12, 7, 18, 0, 0, 0, DateTimeKind.Utc), 20, 147, "GeneralCheckUp" },
                    { 78, new DateTime(2025, 5, 23, 15, 0, 0, 0, DateTimeKind.Utc), 5, 113, "NutritinalCounseling" },
                    { 79, new DateTime(2025, 11, 29, 18, 0, 0, 0, DateTimeKind.Utc), 13, 37, "SpecialistAdvice" },
                    { 80, new DateTime(2025, 10, 30, 7, 0, 0, 0, DateTimeKind.Utc), 17, 6, "SpecialistAdvice" },
                    { 81, new DateTime(2025, 10, 16, 13, 0, 0, 0, DateTimeKind.Utc), 1, 141, "GeneralCheckUp" },
                    { 82, new DateTime(2024, 3, 21, 15, 0, 0, 0, DateTimeKind.Utc), 12, 92, "FollowUp" },
                    { 83, new DateTime(2025, 10, 28, 10, 0, 0, 0, DateTimeKind.Utc), 1, 37, "GeneralCheckUp" },
                    { 84, new DateTime(2025, 3, 23, 17, 0, 0, 0, DateTimeKind.Utc), 9, 2, "NutritinalCounseling" },
                    { 85, new DateTime(2024, 11, 2, 12, 0, 0, 0, DateTimeKind.Utc), 19, 59, "FollowUp" },
                    { 86, new DateTime(2024, 11, 12, 18, 0, 0, 0, DateTimeKind.Utc), 15, 3, "GeneralCheckUp" },
                    { 87, new DateTime(2025, 8, 25, 11, 0, 0, 0, DateTimeKind.Utc), 6, 74, "GeneralCheckUp" },
                    { 88, new DateTime(2025, 1, 1, 10, 0, 0, 0, DateTimeKind.Utc), 3, 1, "FollowUp" },
                    { 89, new DateTime(2025, 9, 18, 18, 0, 0, 0, DateTimeKind.Utc), 18, 11, "GeneralCheckUp" },
                    { 90, new DateTime(2025, 9, 5, 16, 0, 0, 0, DateTimeKind.Utc), 19, 187, "GeneralCheckUp" },
                    { 91, new DateTime(2025, 6, 23, 10, 0, 0, 0, DateTimeKind.Utc), 6, 138, "GeneralCheckUp" },
                    { 92, new DateTime(2025, 7, 26, 16, 0, 0, 0, DateTimeKind.Utc), 1, 35, "FollowUp" },
                    { 93, new DateTime(2024, 4, 19, 8, 0, 0, 0, DateTimeKind.Utc), 17, 41, "FollowUp" },
                    { 94, new DateTime(2025, 10, 2, 9, 0, 0, 0, DateTimeKind.Utc), 4, 110, "GeneralCheckUp" },
                    { 95, new DateTime(2025, 6, 4, 6, 0, 0, 0, DateTimeKind.Utc), 11, 193, "GeneralCheckUp" },
                    { 96, new DateTime(2025, 5, 10, 10, 0, 0, 0, DateTimeKind.Utc), 6, 103, "NutritinalCounseling" },
                    { 97, new DateTime(2024, 4, 4, 15, 0, 0, 0, DateTimeKind.Utc), 4, 160, "GeneralCheckUp" },
                    { 98, new DateTime(2025, 10, 31, 10, 0, 0, 0, DateTimeKind.Utc), 15, 188, "NutritinalCounseling" },
                    { 99, new DateTime(2025, 4, 17, 13, 0, 0, 0, DateTimeKind.Utc), 2, 68, "GeneralCheckUp" },
                    { 100, new DateTime(2025, 3, 16, 16, 0, 0, 0, DateTimeKind.Utc), 15, 9, "FollowUp" }
                });

            migrationBuilder.InsertData(
                table: "prescriptions",
                columns: new[] { "id", "appointment_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 },
                    { 17, 17 },
                    { 18, 18 },
                    { 19, 19 },
                    { 20, 20 },
                    { 21, 21 },
                    { 22, 22 },
                    { 23, 23 },
                    { 24, 24 },
                    { 25, 25 },
                    { 26, 26 },
                    { 27, 27 },
                    { 28, 28 },
                    { 29, 29 },
                    { 30, 30 },
                    { 31, 31 },
                    { 32, 32 },
                    { 33, 33 },
                    { 34, 34 },
                    { 35, 35 },
                    { 36, 36 },
                    { 37, 37 },
                    { 38, 38 },
                    { 39, 39 },
                    { 40, 40 },
                    { 41, 41 },
                    { 42, 42 },
                    { 43, 43 },
                    { 44, 44 },
                    { 45, 45 },
                    { 46, 46 },
                    { 47, 47 },
                    { 48, 48 },
                    { 49, 49 },
                    { 50, 50 },
                    { 51, 51 },
                    { 52, 52 },
                    { 53, 53 },
                    { 54, 54 },
                    { 55, 55 },
                    { 56, 56 },
                    { 57, 57 },
                    { 58, 58 },
                    { 59, 59 },
                    { 60, 60 }
                });

            migrationBuilder.InsertData(
                table: "prescription_medicines",
                columns: new[] { "medicine_id", "prescription_id", "note_from_doctor", "quantity" },
                values: new object[,]
                {
                    { 1, 1, "take together with a bag of chips", 2 },
                    { 1, 2, "take together with a bag of chips", 1 },
                    { 2, 2, "don't spend it all at once", 2 },
                    { 2, 3, "take together with a bag of chips", 3 },
                    { 1, 4, "wash it down with a glass of coke", 2 },
                    { 2, 4, "taste even better when you put them in cinnamon rolls", 1 },
                    { 1, 5, "wash it down with a glass of coke", 1 },
                    { 1, 6, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 7, "don't spend it all at once", 1 },
                    { 2, 7, "take together with a bag of chips", 2 },
                    { 1, 8, "taste even better when you put them in cinnamon rolls", 2 },
                    { 2, 9, "don't spend it all at once", 1 },
                    { 1, 10, "don't spend it all at once", 2 },
                    { 2, 10, "take together with a bag of chips", 2 },
                    { 2, 11, "taste even better when you put them in cinnamon rolls", 2 },
                    { 2, 12, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 13, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 3 },
                    { 1, 14, "don't spend it all at once", 2 },
                    { 2, 15, "don't spend it all at once", 1 },
                    { 2, 16, "wash it down with a glass of coke", 1 },
                    { 2, 17, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 18, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 2, 18, "don't spend it all at once", 2 },
                    { 2, 19, "take together with a bag of chips", 1 },
                    { 2, 20, "don't spend it all at once", 1 },
                    { 2, 21, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 3 },
                    { 2, 22, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 23, "wash it down with a glass of coke", 3 },
                    { 1, 24, "taste even better when you put them in cinnamon rolls", 2 },
                    { 2, 24, "wash it down with a glass of coke", 1 },
                    { 2, 25, "take together with a bag of chips", 3 },
                    { 1, 26, "don't spend it all at once", 1 },
                    { 2, 26, "wash it down with a glass of coke", 1 },
                    { 2, 27, "take together with a bag of chips", 2 },
                    { 2, 28, "taste even better when you put them in cinnamon rolls", 2 },
                    { 2, 29, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 2, 30, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 3 },
                    { 2, 31, "wash it down with a glass of coke", 2 },
                    { 1, 32, "take together with a bag of chips", 1 },
                    { 2, 33, "don't spend it all at once", 1 },
                    { 1, 34, "take together with a bag of chips", 1 },
                    { 1, 35, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 36, "take together with a bag of chips", 2 },
                    { 1, 37, "taste even better when you put them in cinnamon rolls", 2 },
                    { 2, 37, "don't spend it all at once", 1 },
                    { 1, 38, "take together with a bag of chips", 1 },
                    { 2, 38, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 39, "wash it down with a glass of coke", 2 },
                    { 1, 40, "take together with a bag of chips", 2 },
                    { 1, 41, "wash it down with a glass of coke", 2 },
                    { 1, 42, "don't spend it all at once", 1 },
                    { 2, 42, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 43, "wash it down with a glass of coke", 1 },
                    { 1, 44, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 2, 45, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 3 },
                    { 1, 46, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 47, "take together with a bag of chips", 1 },
                    { 2, 47, "taste even better when you put them in cinnamon rolls", 1 },
                    { 1, 48, "don't spend it all at once", 1 },
                    { 2, 48, "wash it down with a glass of coke", 2 },
                    { 2, 49, "take together with a bag of chips", 2 },
                    { 1, 50, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 51, "wash it down with a glass of coke", 2 },
                    { 1, 52, "don't spend it all at once", 2 },
                    { 2, 53, "take together with a bag of chips", 1 },
                    { 1, 54, "take together with a bag of chips", 1 },
                    { 1, 55, "take together with a bag of chips", 1 },
                    { 2, 55, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 56, "wash it down with a glass of coke", 1 },
                    { 2, 57, "wash it down with a glass of coke", 2 },
                    { 1, 58, "don't spend it all at once", 1 },
                    { 2, 58, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 59, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 60, "wash it down with a glass of coke", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_medicines_medicine_id",
                table: "prescription_medicines",
                column: "medicine_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_appointment_id",
                table: "prescriptions",
                column: "appointment_id",
                unique: true);
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

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
