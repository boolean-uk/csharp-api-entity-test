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
                    appointment_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    { 2, "M.D. Sebastian Sugarmore" },
                    { 3, "Prof. Dr. Percival Candycraze" },
                    { 4, "M.D. Dorian Colagood" },
                    { 5, "Prof. Dr. Nathaniel Sugarmore" },
                    { 6, "Prof. Dr. Isabella Snackwell" },
                    { 7, "Doc. Dorian Candycraze" },
                    { 8, "Dr. Anastasia Sugargood" },
                    { 9, "Professor Felicity Jones" },
                    { 10, "Master Dr. Maximilian Colagood" },
                    { 11, "M.D. Penelope Eatmore" },
                    { 12, "Prof. Dr. Xavier Sugargood" },
                    { 13, "Supreme Dr. Beatrice Sodagood" },
                    { 14, "Prof. Dr. Percival Sodagood" },
                    { 15, "Prof. Dr. Dorian Jones" },
                    { 16, "Doctor Charlotte Candycraze" },
                    { 17, "Doctor Beatrice Colagood" },
                    { 18, "Specialist Miranda Eatmore" },
                    { 19, "Specialist Daphne Sugargood" },
                    { 20, "Professor Penelope Carbcrave" }
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
                    { 2, "Claire Robinson" },
                    { 3, "Claire Jackson" },
                    { 4, "Chris Smith" },
                    { 5, "Beth Davis" },
                    { 6, "Ian Davis" },
                    { 7, "Emily Moore" },
                    { 8, "Grace Williams" },
                    { 9, "Ben Smith" },
                    { 10, "Dave White" },
                    { 11, "John Taylor" },
                    { 12, "Jack Robinson" },
                    { 13, "Anna Harris" },
                    { 14, "Jack Martinez" },
                    { 15, "Frank Anderson" },
                    { 16, "Greg Robinson" },
                    { 17, "Beth Thompson" },
                    { 18, "Ian Moore" },
                    { 19, "Beth Johnson" },
                    { 20, "John Martin" },
                    { 21, "Julia Jackson" },
                    { 22, "Diane Jackson" },
                    { 23, "Claire Martinez" },
                    { 24, "Chris Thompson" },
                    { 25, "Ben Robinson" },
                    { 26, "Frank Johnson" },
                    { 27, "John Garcia" },
                    { 28, "Ben White" },
                    { 29, "Ben Harris" },
                    { 30, "Diane Jackson" },
                    { 31, "Beth Moore" },
                    { 32, "Ian Brown" },
                    { 33, "Anna Smith" },
                    { 34, "Ben Martinez" },
                    { 35, "Julia Martinez" },
                    { 36, "Claire Anderson" },
                    { 37, "Frank Garcia" },
                    { 38, "Frank Miller" },
                    { 39, "Jack Wilson" },
                    { 40, "Anna Martinez" },
                    { 41, "Claire Jackson" },
                    { 42, "Greg Johnson" },
                    { 43, "Julia Williams" },
                    { 44, "Emily Taylor" },
                    { 45, "Greg Taylor" },
                    { 46, "Frank White" },
                    { 47, "Ian Martin" },
                    { 48, "Chris Williams" },
                    { 49, "John Brown" },
                    { 50, "Anna Taylor" },
                    { 51, "Frank Moore" },
                    { 52, "Anna Brown" },
                    { 53, "Dave Robinson" },
                    { 54, "Beth Davis" },
                    { 55, "Diane Moore" },
                    { 56, "Chris Jackson" },
                    { 57, "Emily White" },
                    { 58, "Anna Thompson" },
                    { 59, "Greg Moore" },
                    { 60, "Ian Taylor" },
                    { 61, "Julia Jackson" },
                    { 62, "Dave Robinson" },
                    { 63, "Emily Davis" },
                    { 64, "Jack Martinez" },
                    { 65, "Diane Davis" },
                    { 66, "Jack Jackson" },
                    { 67, "John Martin" },
                    { 68, "Emily Martin" },
                    { 69, "Diane Thomas" },
                    { 70, "Emily Garcia" },
                    { 71, "Ben Martin" },
                    { 72, "Greg Martinez" },
                    { 73, "John Williams" },
                    { 74, "John Davis" },
                    { 75, "Ian Martinez" },
                    { 76, "Ian Harris" },
                    { 77, "Chris Martin" },
                    { 78, "Jack Thompson" },
                    { 79, "Grace Miller" },
                    { 80, "John Anderson" },
                    { 81, "Diane Harris" },
                    { 82, "Greg Wilson" },
                    { 83, "Beth Taylor" },
                    { 84, "Chris Brown" },
                    { 85, "Emily Wilson" },
                    { 86, "Ben Brown" },
                    { 87, "Jack Williams" },
                    { 88, "Claire Moore" },
                    { 89, "Diane Miller" },
                    { 90, "Diane Brown" },
                    { 91, "Anna Garcia" },
                    { 92, "John Martin" },
                    { 93, "Claire Williams" },
                    { 94, "Claire Thompson" },
                    { 95, "Frank Smith" },
                    { 96, "Anna Martin" },
                    { 97, "John Moore" },
                    { 98, "Grace Williams" },
                    { 99, "Emily Miller" },
                    { 100, "John Robinson" },
                    { 101, "Ian Anderson" },
                    { 102, "Claire Wilson" },
                    { 103, "Dave Garcia" },
                    { 104, "Julia Robinson" },
                    { 105, "Ben Martin" },
                    { 106, "Julia Brown" },
                    { 107, "Julia Moore" },
                    { 108, "Claire Jackson" },
                    { 109, "John Martin" },
                    { 110, "Dave Garcia" },
                    { 111, "Julia Thomas" },
                    { 112, "Jack Williams" },
                    { 113, "Emily Martinez" },
                    { 114, "Greg Davis" },
                    { 115, "Beth Robinson" },
                    { 116, "Julia Thomas" },
                    { 117, "Julia Moore" },
                    { 118, "Beth Thompson" },
                    { 119, "Ben Wilson" },
                    { 120, "Diane Moore" },
                    { 121, "Frank Taylor" },
                    { 122, "John Harris" },
                    { 123, "Diane Anderson" },
                    { 124, "Beth Moore" },
                    { 125, "John White" },
                    { 126, "Dave Garcia" },
                    { 127, "Ian Miller" },
                    { 128, "Anna Harris" },
                    { 129, "Emily Jackson" },
                    { 130, "Jack Martin" },
                    { 131, "Julia Moore" },
                    { 132, "John Anderson" },
                    { 133, "Anna Anderson" },
                    { 134, "Dave Garcia" },
                    { 135, "Diane Jackson" },
                    { 136, "Beth White" },
                    { 137, "Frank White" },
                    { 138, "Ian White" },
                    { 139, "Claire Thompson" },
                    { 140, "Chris Robinson" },
                    { 141, "Chris Robinson" },
                    { 142, "Jack Wilson" },
                    { 143, "Dave Thompson" },
                    { 144, "Diane Williams" },
                    { 145, "Emily Moore" },
                    { 146, "Grace Garcia" },
                    { 147, "Dave Robinson" },
                    { 148, "Emily Johnson" },
                    { 149, "Ian Thomas" },
                    { 150, "John Robinson" },
                    { 151, "Anna Moore" },
                    { 152, "Ian Wilson" },
                    { 153, "John Williams" },
                    { 154, "Ben Brown" },
                    { 155, "Grace Martinez" },
                    { 156, "Julia Davis" },
                    { 157, "Anna Robinson" },
                    { 158, "John Harris" },
                    { 159, "Grace Anderson" },
                    { 160, "Dave Martin" },
                    { 161, "Frank White" },
                    { 162, "Diane Jackson" },
                    { 163, "Jack Wilson" },
                    { 164, "Chris White" },
                    { 165, "Claire Thompson" },
                    { 166, "Jack Wilson" },
                    { 167, "Greg Wilson" },
                    { 168, "Frank Wilson" },
                    { 169, "Chris Thomas" },
                    { 170, "Greg Martinez" },
                    { 171, "Diane Harris" },
                    { 172, "Anna Williams" },
                    { 173, "Chris Davis" },
                    { 174, "Dave Thomas" },
                    { 175, "Ian Johnson" },
                    { 176, "Greg Harris" },
                    { 177, "Grace Moore" },
                    { 178, "Ian Miller" },
                    { 179, "Emily Thompson" },
                    { 180, "Julia Garcia" },
                    { 181, "Ian Miller" },
                    { 182, "Ian Thompson" },
                    { 183, "Grace Smith" },
                    { 184, "Anna White" },
                    { 185, "Greg Garcia" },
                    { 186, "Greg Harris" },
                    { 187, "Ben Brown" },
                    { 188, "Julia White" },
                    { 189, "Ben Martin" },
                    { 190, "Grace Anderson" },
                    { 191, "Dave Jackson" },
                    { 192, "Ben Johnson" },
                    { 193, "Beth Williams" },
                    { 194, "Grace Garcia" },
                    { 195, "Dave Harris" },
                    { 196, "Ian Moore" },
                    { 197, "Grace Thompson" },
                    { 198, "Grace Davis" },
                    { 199, "Beth Smith" },
                    { 200, "John Robinson" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "appointment_time", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 16, 30, 0, 0, DateTimeKind.Utc), 1, 1 },
                    { 2, new DateTime(2025, 6, 14, 7, 0, 0, 0, DateTimeKind.Utc), 17, 4 },
                    { 3, new DateTime(2024, 6, 15, 6, 0, 0, 0, DateTimeKind.Utc), 6, 120 },
                    { 4, new DateTime(2025, 7, 3, 19, 0, 0, 0, DateTimeKind.Utc), 12, 158 },
                    { 5, new DateTime(2024, 6, 4, 11, 0, 0, 0, DateTimeKind.Utc), 9, 67 },
                    { 6, new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Utc), 17, 124 },
                    { 7, new DateTime(2024, 9, 28, 10, 0, 0, 0, DateTimeKind.Utc), 19, 24 },
                    { 8, new DateTime(2024, 8, 16, 16, 0, 0, 0, DateTimeKind.Utc), 14, 50 },
                    { 9, new DateTime(2025, 1, 17, 15, 0, 0, 0, DateTimeKind.Utc), 12, 43 },
                    { 10, new DateTime(2025, 11, 27, 18, 0, 0, 0, DateTimeKind.Utc), 9, 55 },
                    { 11, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Utc), 16, 105 },
                    { 12, new DateTime(2024, 10, 1, 8, 0, 0, 0, DateTimeKind.Utc), 9, 181 },
                    { 13, new DateTime(2025, 5, 21, 10, 0, 0, 0, DateTimeKind.Utc), 9, 26 },
                    { 14, new DateTime(2025, 5, 11, 12, 0, 0, 0, DateTimeKind.Utc), 15, 46 },
                    { 15, new DateTime(2024, 1, 27, 14, 0, 0, 0, DateTimeKind.Utc), 3, 165 },
                    { 16, new DateTime(2024, 10, 16, 16, 0, 0, 0, DateTimeKind.Utc), 16, 101 },
                    { 17, new DateTime(2025, 1, 27, 18, 0, 0, 0, DateTimeKind.Utc), 2, 69 },
                    { 18, new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Utc), 17, 141 },
                    { 19, new DateTime(2024, 3, 21, 8, 0, 0, 0, DateTimeKind.Utc), 5, 158 },
                    { 20, new DateTime(2024, 3, 3, 9, 0, 0, 0, DateTimeKind.Utc), 15, 115 },
                    { 21, new DateTime(2025, 9, 29, 16, 0, 0, 0, DateTimeKind.Utc), 5, 133 },
                    { 22, new DateTime(2024, 6, 29, 8, 0, 0, 0, DateTimeKind.Utc), 8, 83 },
                    { 23, new DateTime(2025, 7, 20, 10, 0, 0, 0, DateTimeKind.Utc), 2, 178 },
                    { 24, new DateTime(2024, 10, 16, 18, 0, 0, 0, DateTimeKind.Utc), 12, 23 },
                    { 25, new DateTime(2025, 7, 1, 8, 0, 0, 0, DateTimeKind.Utc), 19, 150 },
                    { 26, new DateTime(2024, 10, 28, 16, 0, 0, 0, DateTimeKind.Utc), 18, 100 },
                    { 27, new DateTime(2025, 1, 29, 17, 0, 0, 0, DateTimeKind.Utc), 1, 181 },
                    { 28, new DateTime(2025, 7, 10, 9, 0, 0, 0, DateTimeKind.Utc), 2, 92 },
                    { 29, new DateTime(2025, 1, 18, 15, 0, 0, 0, DateTimeKind.Utc), 10, 122 },
                    { 30, new DateTime(2024, 12, 27, 15, 0, 0, 0, DateTimeKind.Utc), 17, 65 },
                    { 31, new DateTime(2025, 1, 21, 17, 0, 0, 0, DateTimeKind.Utc), 13, 182 },
                    { 32, new DateTime(2024, 9, 28, 7, 0, 0, 0, DateTimeKind.Utc), 10, 130 },
                    { 33, new DateTime(2025, 10, 13, 7, 0, 0, 0, DateTimeKind.Utc), 14, 144 },
                    { 34, new DateTime(2024, 5, 22, 11, 0, 0, 0, DateTimeKind.Utc), 18, 5 },
                    { 35, new DateTime(2024, 3, 12, 7, 0, 0, 0, DateTimeKind.Utc), 18, 42 },
                    { 36, new DateTime(2024, 4, 7, 12, 0, 0, 0, DateTimeKind.Utc), 13, 177 },
                    { 37, new DateTime(2024, 7, 16, 18, 0, 0, 0, DateTimeKind.Utc), 19, 114 },
                    { 38, new DateTime(2024, 12, 18, 13, 0, 0, 0, DateTimeKind.Utc), 14, 67 },
                    { 39, new DateTime(2024, 12, 22, 13, 0, 0, 0, DateTimeKind.Utc), 18, 78 },
                    { 40, new DateTime(2025, 6, 25, 11, 0, 0, 0, DateTimeKind.Utc), 3, 33 },
                    { 41, new DateTime(2025, 11, 27, 11, 0, 0, 0, DateTimeKind.Utc), 12, 181 },
                    { 42, new DateTime(2025, 10, 21, 19, 0, 0, 0, DateTimeKind.Utc), 13, 145 },
                    { 43, new DateTime(2025, 10, 29, 15, 0, 0, 0, DateTimeKind.Utc), 11, 74 },
                    { 44, new DateTime(2024, 12, 20, 18, 0, 0, 0, DateTimeKind.Utc), 20, 81 },
                    { 45, new DateTime(2024, 6, 15, 16, 0, 0, 0, DateTimeKind.Utc), 9, 178 },
                    { 46, new DateTime(2024, 9, 2, 10, 0, 0, 0, DateTimeKind.Utc), 8, 26 },
                    { 47, new DateTime(2024, 6, 8, 15, 0, 0, 0, DateTimeKind.Utc), 6, 23 },
                    { 48, new DateTime(2025, 3, 5, 7, 0, 0, 0, DateTimeKind.Utc), 3, 143 },
                    { 49, new DateTime(2025, 6, 26, 19, 0, 0, 0, DateTimeKind.Utc), 8, 117 },
                    { 50, new DateTime(2025, 6, 11, 19, 0, 0, 0, DateTimeKind.Utc), 12, 139 },
                    { 51, new DateTime(2024, 1, 14, 15, 0, 0, 0, DateTimeKind.Utc), 9, 82 },
                    { 52, new DateTime(2024, 12, 16, 15, 0, 0, 0, DateTimeKind.Utc), 7, 3 },
                    { 53, new DateTime(2024, 2, 4, 7, 0, 0, 0, DateTimeKind.Utc), 18, 136 },
                    { 54, new DateTime(2024, 9, 30, 13, 0, 0, 0, DateTimeKind.Utc), 1, 191 },
                    { 55, new DateTime(2025, 10, 11, 14, 0, 0, 0, DateTimeKind.Utc), 14, 50 },
                    { 56, new DateTime(2025, 11, 25, 17, 0, 0, 0, DateTimeKind.Utc), 3, 160 },
                    { 57, new DateTime(2024, 8, 15, 16, 0, 0, 0, DateTimeKind.Utc), 2, 143 },
                    { 58, new DateTime(2025, 7, 11, 15, 0, 0, 0, DateTimeKind.Utc), 1, 12 },
                    { 59, new DateTime(2025, 12, 12, 10, 0, 0, 0, DateTimeKind.Utc), 12, 154 },
                    { 60, new DateTime(2024, 10, 11, 12, 0, 0, 0, DateTimeKind.Utc), 5, 63 },
                    { 61, new DateTime(2025, 6, 14, 19, 0, 0, 0, DateTimeKind.Utc), 3, 34 },
                    { 62, new DateTime(2025, 3, 6, 7, 0, 0, 0, DateTimeKind.Utc), 19, 135 },
                    { 63, new DateTime(2024, 2, 6, 15, 0, 0, 0, DateTimeKind.Utc), 13, 121 },
                    { 64, new DateTime(2024, 8, 12, 15, 0, 0, 0, DateTimeKind.Utc), 10, 21 },
                    { 65, new DateTime(2024, 9, 11, 18, 0, 0, 0, DateTimeKind.Utc), 17, 125 },
                    { 66, new DateTime(2025, 1, 27, 12, 0, 0, 0, DateTimeKind.Utc), 6, 96 },
                    { 67, new DateTime(2024, 9, 26, 19, 0, 0, 0, DateTimeKind.Utc), 5, 38 },
                    { 68, new DateTime(2024, 3, 25, 7, 0, 0, 0, DateTimeKind.Utc), 20, 98 },
                    { 69, new DateTime(2024, 5, 11, 18, 0, 0, 0, DateTimeKind.Utc), 6, 196 },
                    { 70, new DateTime(2024, 10, 19, 16, 0, 0, 0, DateTimeKind.Utc), 16, 101 },
                    { 71, new DateTime(2024, 4, 16, 17, 0, 0, 0, DateTimeKind.Utc), 1, 127 },
                    { 72, new DateTime(2025, 10, 6, 9, 0, 0, 0, DateTimeKind.Utc), 16, 74 },
                    { 73, new DateTime(2025, 4, 13, 11, 0, 0, 0, DateTimeKind.Utc), 15, 119 },
                    { 74, new DateTime(2024, 8, 2, 8, 0, 0, 0, DateTimeKind.Utc), 5, 127 },
                    { 75, new DateTime(2024, 2, 4, 16, 0, 0, 0, DateTimeKind.Utc), 15, 156 },
                    { 76, new DateTime(2024, 9, 1, 13, 0, 0, 0, DateTimeKind.Utc), 18, 39 },
                    { 77, new DateTime(2025, 2, 28, 13, 0, 0, 0, DateTimeKind.Utc), 15, 39 },
                    { 78, new DateTime(2024, 2, 23, 11, 0, 0, 0, DateTimeKind.Utc), 4, 138 },
                    { 79, new DateTime(2024, 8, 6, 15, 0, 0, 0, DateTimeKind.Utc), 8, 67 },
                    { 80, new DateTime(2024, 2, 3, 18, 0, 0, 0, DateTimeKind.Utc), 8, 4 },
                    { 81, new DateTime(2025, 5, 2, 14, 0, 0, 0, DateTimeKind.Utc), 13, 106 },
                    { 82, new DateTime(2025, 6, 29, 9, 0, 0, 0, DateTimeKind.Utc), 14, 164 },
                    { 83, new DateTime(2025, 6, 29, 7, 0, 0, 0, DateTimeKind.Utc), 9, 9 },
                    { 84, new DateTime(2024, 1, 21, 19, 0, 0, 0, DateTimeKind.Utc), 12, 86 },
                    { 85, new DateTime(2024, 9, 16, 15, 0, 0, 0, DateTimeKind.Utc), 16, 43 },
                    { 86, new DateTime(2025, 12, 15, 11, 0, 0, 0, DateTimeKind.Utc), 8, 15 },
                    { 87, new DateTime(2025, 1, 6, 11, 0, 0, 0, DateTimeKind.Utc), 18, 38 },
                    { 88, new DateTime(2025, 3, 13, 14, 0, 0, 0, DateTimeKind.Utc), 19, 144 },
                    { 89, new DateTime(2024, 7, 16, 7, 0, 0, 0, DateTimeKind.Utc), 9, 99 },
                    { 90, new DateTime(2025, 11, 9, 10, 0, 0, 0, DateTimeKind.Utc), 17, 140 },
                    { 91, new DateTime(2024, 11, 5, 16, 0, 0, 0, DateTimeKind.Utc), 20, 11 },
                    { 92, new DateTime(2024, 5, 22, 19, 0, 0, 0, DateTimeKind.Utc), 19, 159 },
                    { 93, new DateTime(2024, 7, 7, 18, 0, 0, 0, DateTimeKind.Utc), 8, 124 },
                    { 94, new DateTime(2025, 1, 8, 7, 0, 0, 0, DateTimeKind.Utc), 7, 57 },
                    { 95, new DateTime(2025, 9, 15, 6, 0, 0, 0, DateTimeKind.Utc), 20, 114 },
                    { 96, new DateTime(2025, 7, 16, 16, 0, 0, 0, DateTimeKind.Utc), 17, 141 },
                    { 97, new DateTime(2025, 11, 26, 8, 0, 0, 0, DateTimeKind.Utc), 8, 158 },
                    { 98, new DateTime(2024, 9, 11, 11, 0, 0, 0, DateTimeKind.Utc), 15, 76 },
                    { 99, new DateTime(2025, 3, 25, 11, 0, 0, 0, DateTimeKind.Utc), 18, 83 },
                    { 100, new DateTime(2024, 10, 11, 11, 0, 0, 0, DateTimeKind.Utc), 5, 119 }
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
                    { 2, 1, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 2, 2, "don't spend it all at once", 2 },
                    { 1, 3, "don't spend it all at once", 2 },
                    { 2, 3, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 1, 4, "don't spend it all at once", 1 },
                    { 2, 4, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 5, "wash it down with a glass of coke", 2 },
                    { 2, 5, "don't spend it all at once", 1 },
                    { 2, 6, "wash it down with a glass of coke", 3 },
                    { 2, 7, "wash it down with a glass of coke", 1 },
                    { 1, 8, "take together with a bag of chips", 2 },
                    { 1, 9, "take together with a bag of chips", 2 },
                    { 2, 9, "take together with a bag of chips", 1 },
                    { 2, 10, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 11, "take together with a bag of chips", 2 },
                    { 1, 12, "take together with a bag of chips", 2 },
                    { 2, 12, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 13, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 14, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 15, "wash it down with a glass of coke", 2 },
                    { 2, 16, "take together with a bag of chips", 2 },
                    { 2, 17, "don't spend it all at once", 1 },
                    { 2, 18, "don't spend it all at once", 1 },
                    { 1, 19, "wash it down with a glass of coke", 1 },
                    { 1, 20, "take together with a bag of chips", 2 },
                    { 1, 21, "take together with a bag of chips", 2 },
                    { 2, 21, "taste even better when you put them in cinnamon rolls", 1 },
                    { 1, 22, "don't spend it all at once", 1 },
                    { 2, 22, "don't spend it all at once", 2 },
                    { 2, 23, "take together with a bag of chips", 1 },
                    { 2, 24, "take together with a bag of chips", 3 },
                    { 1, 25, "wash it down with a glass of coke", 1 },
                    { 2, 25, "don't spend it all at once", 1 },
                    { 1, 26, "taste even better when you put them in cinnamon rolls", 1 },
                    { 2, 26, "don't spend it all at once", 1 },
                    { 2, 27, "wash it down with a glass of coke", 2 },
                    { 2, 28, "don't spend it all at once", 1 },
                    { 1, 29, "take together with a bag of chips", 2 },
                    { 2, 30, "take together with a bag of chips", 2 },
                    { 1, 31, "taste even better when you put them in cinnamon rolls", 1 },
                    { 2, 31, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 1, 32, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 1, 33, "wash it down with a glass of coke", 2 },
                    { 2, 33, "wash it down with a glass of coke", 2 },
                    { 1, 34, "don't spend it all at once", 2 },
                    { 1, 35, "taste even better when you put them in cinnamon rolls", 1 },
                    { 1, 36, "wash it down with a glass of coke", 1 },
                    { 1, 37, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 2, 37, "wash it down with a glass of coke", 2 },
                    { 1, 38, "don't spend it all at once", 2 },
                    { 2, 38, "don't spend it all at once", 1 },
                    { 1, 39, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 1, 40, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 2, 40, "don't spend it all at once", 2 },
                    { 1, 41, "wash it down with a glass of coke", 1 },
                    { 2, 41, "take together with a bag of chips", 2 },
                    { 1, 42, "wash it down with a glass of coke", 2 },
                    { 2, 42, "taste even better when you put them in cinnamon rolls", 1 },
                    { 1, 43, "wash it down with a glass of coke", 1 },
                    { 1, 44, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 2, 45, "take together with a bag of chips", 3 },
                    { 2, 46, "wash it down with a glass of coke", 2 },
                    { 2, 47, "don't spend it all at once", 2 },
                    { 2, 48, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 49, "taste even better when you put them in cinnamon rolls", 2 },
                    { 2, 49, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 50, "wash it down with a glass of coke", 2 },
                    { 1, 51, "take together with a bag of chips", 1 },
                    { 2, 51, "don't spend it all at once", 2 },
                    { 1, 52, "take together with a bag of chips", 2 },
                    { 1, 53, "wash it down with a glass of coke", 2 },
                    { 2, 54, "don't spend it all at once", 1 },
                    { 1, 55, "don't spend it all at once", 3 },
                    { 1, 56, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 57, "taste even better when you put them in cinnamon rolls", 2 },
                    { 2, 57, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 1, 58, "wash it down with a glass of coke", 1 },
                    { 2, 58, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 59, "take together with a bag of chips", 1 },
                    { 1, 60, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 }
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
