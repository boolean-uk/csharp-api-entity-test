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
                    { 2, "Professor Sebastian Candygood" },
                    { 3, "PhD Dr. Chawton Snackright" },
                    { 4, "PhD Dr. Edmund Carbcrave" },
                    { 5, "M.D. Maximilian Sugargood" },
                    { 6, "PhD Dr. Edmund Carbcrave" },
                    { 7, "Dr. Benedict Candycraze" },
                    { 8, "Master Dr. Edmund Colagood" },
                    { 9, "Dr. Indiana Snackmore" },
                    { 10, "Supreme Dr. Dorian Carbcrave" },
                    { 11, "Doc. Isabella Candygood" },
                    { 12, "PhD Dr. Isabella Snackmore" },
                    { 13, "M.D. Ophelia Sugarmore" },
                    { 14, "PhD Dr. Charlotte Sugarmore" },
                    { 15, "Professor Percival Jones" },
                    { 16, "Dr. Beatrice Eatmore" },
                    { 17, "M.D. Percival Eatmore" },
                    { 18, "Professor Quentin Snackgood" },
                    { 19, "PhD Dr. Percival Sugargood" },
                    { 20, "Doctor Benedict Colagood" }
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
                    { 2, "Jack Jackson" },
                    { 3, "Diane Martinez" },
                    { 4, "Jack Taylor" },
                    { 5, "Frank Miller" },
                    { 6, "Anna Taylor" },
                    { 7, "Jack Davis" },
                    { 8, "Anna White" },
                    { 9, "John Thomas" },
                    { 10, "Ben Garcia" },
                    { 11, "Beth Moore" },
                    { 12, "Diane Brown" },
                    { 13, "Ben Harris" },
                    { 14, "Claire Martinez" },
                    { 15, "John Davis" },
                    { 16, "John Thompson" },
                    { 17, "Diane Martin" },
                    { 18, "Greg Thompson" },
                    { 19, "Anna White" },
                    { 20, "Greg Harris" },
                    { 21, "Emily Davis" },
                    { 22, "Diane Smith" },
                    { 23, "Emily Harris" },
                    { 24, "Chris Martinez" },
                    { 25, "Beth Wilson" },
                    { 26, "Chris Martinez" },
                    { 27, "Jack Robinson" },
                    { 28, "Claire Miller" },
                    { 29, "Chris Wilson" },
                    { 30, "Beth Smith" },
                    { 31, "Emily Thomas" },
                    { 32, "Greg Harris" },
                    { 33, "Grace Anderson" },
                    { 34, "Diane Davis" },
                    { 35, "Anna Moore" },
                    { 36, "Ian Martinez" },
                    { 37, "Ian Wilson" },
                    { 38, "Greg Johnson" },
                    { 39, "John White" },
                    { 40, "Ian Brown" },
                    { 41, "Ian Taylor" },
                    { 42, "Ben Robinson" },
                    { 43, "Diane Taylor" },
                    { 44, "Claire Wilson" },
                    { 45, "Grace Harris" },
                    { 46, "Beth Taylor" },
                    { 47, "Claire Garcia" },
                    { 48, "Julia Johnson" },
                    { 49, "Dave Garcia" },
                    { 50, "Beth Martin" },
                    { 51, "Greg Brown" },
                    { 52, "Greg Taylor" },
                    { 53, "Julia Martinez" },
                    { 54, "Grace Davis" },
                    { 55, "Anna White" },
                    { 56, "Diane Harris" },
                    { 57, "Beth Moore" },
                    { 58, "Jack Wilson" },
                    { 59, "Ben Davis" },
                    { 60, "Greg Anderson" },
                    { 61, "Jack Martinez" },
                    { 62, "John White" },
                    { 63, "Grace Harris" },
                    { 64, "Beth Davis" },
                    { 65, "Greg Robinson" },
                    { 66, "Emily Thompson" },
                    { 67, "Frank Williams" },
                    { 68, "Ian Anderson" },
                    { 69, "Diane Williams" },
                    { 70, "Diane Miller" },
                    { 71, "Ben Jackson" },
                    { 72, "Beth Brown" },
                    { 73, "Chris Davis" },
                    { 74, "Frank Anderson" },
                    { 75, "Anna Martinez" },
                    { 76, "Jack Thompson" },
                    { 77, "Emily Williams" },
                    { 78, "Ian Thomas" },
                    { 79, "Diane Moore" },
                    { 80, "Jack Martinez" },
                    { 81, "Diane White" },
                    { 82, "Grace Garcia" },
                    { 83, "Ian Robinson" },
                    { 84, "Diane Garcia" },
                    { 85, "Jack Taylor" },
                    { 86, "Julia Martin" },
                    { 87, "Jack Johnson" },
                    { 88, "Ian Moore" },
                    { 89, "Dave Martin" },
                    { 90, "Emily Harris" },
                    { 91, "Dave Williams" },
                    { 92, "Ben Miller" },
                    { 93, "Claire Johnson" },
                    { 94, "Dave Wilson" },
                    { 95, "Julia Miller" },
                    { 96, "Frank Harris" },
                    { 97, "Diane Robinson" },
                    { 98, "Ian Anderson" },
                    { 99, "Emily Harris" },
                    { 100, "Emily Wilson" },
                    { 101, "Ian White" },
                    { 102, "Frank Jackson" },
                    { 103, "John Williams" },
                    { 104, "Frank Moore" },
                    { 105, "Dave Williams" },
                    { 106, "Greg Williams" },
                    { 107, "Frank Smith" },
                    { 108, "Ben Moore" },
                    { 109, "Ben Harris" },
                    { 110, "Anna Taylor" },
                    { 111, "Claire Thompson" },
                    { 112, "Ben Miller" },
                    { 113, "Grace Thomas" },
                    { 114, "Ian Jackson" },
                    { 115, "Beth Martin" },
                    { 116, "John Harris" },
                    { 117, "Jack Smith" },
                    { 118, "Greg Moore" },
                    { 119, "Beth Martinez" },
                    { 120, "Frank Miller" },
                    { 121, "Ian Miller" },
                    { 122, "Greg Smith" },
                    { 123, "Ian Williams" },
                    { 124, "Anna Williams" },
                    { 125, "Beth Moore" },
                    { 126, "Ben Thomas" },
                    { 127, "John Thomas" },
                    { 128, "Chris Robinson" },
                    { 129, "Diane Davis" },
                    { 130, "John Jackson" },
                    { 131, "Beth Williams" },
                    { 132, "Diane Jackson" },
                    { 133, "Dave Anderson" },
                    { 134, "Claire Williams" },
                    { 135, "Claire Harris" },
                    { 136, "Grace Thomas" },
                    { 137, "Diane Davis" },
                    { 138, "Ben Taylor" },
                    { 139, "Chris Brown" },
                    { 140, "Ben Robinson" },
                    { 141, "Chris Martinez" },
                    { 142, "Anna Davis" },
                    { 143, "Jack Thomas" },
                    { 144, "John White" },
                    { 145, "Greg Robinson" },
                    { 146, "Julia White" },
                    { 147, "Beth Robinson" },
                    { 148, "Claire Jackson" },
                    { 149, "Emily Martin" },
                    { 150, "Diane Thompson" },
                    { 151, "Claire Garcia" },
                    { 152, "Diane Garcia" },
                    { 153, "Grace Harris" },
                    { 154, "Grace Miller" },
                    { 155, "Greg White" },
                    { 156, "Julia Smith" },
                    { 157, "Claire Thompson" },
                    { 158, "Emily Moore" },
                    { 159, "Beth Williams" },
                    { 160, "Anna Robinson" },
                    { 161, "Julia Thomas" },
                    { 162, "Grace Garcia" },
                    { 163, "Beth Anderson" },
                    { 164, "Diane Garcia" },
                    { 165, "Ian Williams" },
                    { 166, "Chris Garcia" },
                    { 167, "John Thompson" },
                    { 168, "Anna Moore" },
                    { 169, "Jack Miller" },
                    { 170, "Jack Martin" },
                    { 171, "Dave Thompson" },
                    { 172, "Ben Martin" },
                    { 173, "Jack Moore" },
                    { 174, "John Harris" },
                    { 175, "John Moore" },
                    { 176, "Claire Johnson" },
                    { 177, "Beth Jackson" },
                    { 178, "Claire Anderson" },
                    { 179, "Claire Robinson" },
                    { 180, "Ben Taylor" },
                    { 181, "Jack Smith" },
                    { 182, "Ben Thomas" },
                    { 183, "Claire Johnson" },
                    { 184, "Claire Garcia" },
                    { 185, "Emily Brown" },
                    { 186, "Jack Martin" },
                    { 187, "Grace Robinson" },
                    { 188, "Grace Jackson" },
                    { 189, "Beth Williams" },
                    { 190, "Anna Martin" },
                    { 191, "Chris Garcia" },
                    { 192, "Emily Smith" },
                    { 193, "Anna Davis" },
                    { 194, "Dave White" },
                    { 195, "Emily Moore" },
                    { 196, "Ian Moore" },
                    { 197, "Grace Brown" },
                    { 198, "Diane Robinson" },
                    { 199, "Anna Robinson" },
                    { 200, "Jack Davis" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "appointment_time", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 16, 30, 0, 0, DateTimeKind.Utc), 1, 1 },
                    { 2, new DateTime(2024, 11, 2, 16, 0, 0, 0, DateTimeKind.Utc), 1, 135 },
                    { 3, new DateTime(2024, 7, 3, 6, 0, 0, 0, DateTimeKind.Utc), 8, 66 },
                    { 4, new DateTime(2024, 7, 25, 6, 0, 0, 0, DateTimeKind.Utc), 4, 172 },
                    { 5, new DateTime(2024, 9, 10, 18, 0, 0, 0, DateTimeKind.Utc), 18, 150 },
                    { 6, new DateTime(2024, 10, 27, 9, 0, 0, 0, DateTimeKind.Utc), 15, 108 },
                    { 7, new DateTime(2024, 7, 1, 17, 0, 0, 0, DateTimeKind.Utc), 16, 9 },
                    { 8, new DateTime(2025, 4, 3, 16, 0, 0, 0, DateTimeKind.Utc), 5, 126 },
                    { 9, new DateTime(2025, 6, 14, 10, 0, 0, 0, DateTimeKind.Utc), 18, 94 },
                    { 10, new DateTime(2025, 11, 25, 10, 0, 0, 0, DateTimeKind.Utc), 15, 12 },
                    { 11, new DateTime(2025, 6, 7, 6, 0, 0, 0, DateTimeKind.Utc), 19, 82 },
                    { 12, new DateTime(2024, 6, 1, 9, 0, 0, 0, DateTimeKind.Utc), 17, 129 },
                    { 13, new DateTime(2024, 11, 3, 16, 0, 0, 0, DateTimeKind.Utc), 18, 132 },
                    { 14, new DateTime(2025, 11, 21, 18, 0, 0, 0, DateTimeKind.Utc), 4, 134 },
                    { 15, new DateTime(2024, 5, 20, 17, 0, 0, 0, DateTimeKind.Utc), 20, 169 },
                    { 16, new DateTime(2025, 8, 19, 7, 0, 0, 0, DateTimeKind.Utc), 2, 48 },
                    { 17, new DateTime(2025, 10, 14, 12, 0, 0, 0, DateTimeKind.Utc), 6, 156 },
                    { 18, new DateTime(2025, 4, 24, 9, 0, 0, 0, DateTimeKind.Utc), 18, 182 },
                    { 19, new DateTime(2024, 1, 23, 10, 0, 0, 0, DateTimeKind.Utc), 10, 86 },
                    { 20, new DateTime(2025, 4, 3, 16, 0, 0, 0, DateTimeKind.Utc), 20, 169 },
                    { 21, new DateTime(2025, 9, 2, 17, 0, 0, 0, DateTimeKind.Utc), 3, 56 },
                    { 22, new DateTime(2024, 3, 28, 7, 0, 0, 0, DateTimeKind.Utc), 4, 82 },
                    { 23, new DateTime(2025, 11, 21, 13, 0, 0, 0, DateTimeKind.Utc), 18, 161 },
                    { 24, new DateTime(2024, 6, 11, 11, 0, 0, 0, DateTimeKind.Utc), 10, 150 },
                    { 25, new DateTime(2024, 8, 17, 8, 0, 0, 0, DateTimeKind.Utc), 16, 191 },
                    { 26, new DateTime(2025, 6, 25, 17, 0, 0, 0, DateTimeKind.Utc), 2, 68 },
                    { 27, new DateTime(2025, 5, 18, 8, 0, 0, 0, DateTimeKind.Utc), 19, 154 },
                    { 28, new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Utc), 7, 141 },
                    { 29, new DateTime(2025, 4, 8, 18, 0, 0, 0, DateTimeKind.Utc), 12, 8 },
                    { 30, new DateTime(2025, 5, 31, 10, 0, 0, 0, DateTimeKind.Utc), 5, 141 },
                    { 31, new DateTime(2025, 9, 17, 12, 0, 0, 0, DateTimeKind.Utc), 3, 120 },
                    { 32, new DateTime(2025, 4, 20, 12, 0, 0, 0, DateTimeKind.Utc), 5, 183 },
                    { 33, new DateTime(2025, 10, 3, 19, 0, 0, 0, DateTimeKind.Utc), 2, 77 },
                    { 34, new DateTime(2024, 1, 10, 8, 0, 0, 0, DateTimeKind.Utc), 10, 192 },
                    { 35, new DateTime(2025, 10, 14, 13, 0, 0, 0, DateTimeKind.Utc), 16, 184 },
                    { 36, new DateTime(2025, 10, 8, 14, 0, 0, 0, DateTimeKind.Utc), 7, 56 },
                    { 37, new DateTime(2024, 4, 14, 7, 0, 0, 0, DateTimeKind.Utc), 13, 157 },
                    { 38, new DateTime(2024, 8, 16, 16, 0, 0, 0, DateTimeKind.Utc), 1, 126 },
                    { 39, new DateTime(2025, 8, 18, 16, 0, 0, 0, DateTimeKind.Utc), 10, 198 },
                    { 40, new DateTime(2024, 4, 21, 19, 0, 0, 0, DateTimeKind.Utc), 13, 38 },
                    { 41, new DateTime(2025, 9, 30, 18, 0, 0, 0, DateTimeKind.Utc), 11, 195 },
                    { 42, new DateTime(2024, 2, 10, 19, 0, 0, 0, DateTimeKind.Utc), 3, 190 },
                    { 43, new DateTime(2025, 11, 13, 12, 0, 0, 0, DateTimeKind.Utc), 16, 149 },
                    { 44, new DateTime(2024, 10, 5, 10, 0, 0, 0, DateTimeKind.Utc), 1, 175 },
                    { 45, new DateTime(2024, 1, 30, 16, 0, 0, 0, DateTimeKind.Utc), 15, 140 },
                    { 46, new DateTime(2025, 5, 29, 14, 0, 0, 0, DateTimeKind.Utc), 5, 105 },
                    { 47, new DateTime(2025, 7, 3, 9, 0, 0, 0, DateTimeKind.Utc), 19, 174 },
                    { 48, new DateTime(2025, 10, 30, 12, 0, 0, 0, DateTimeKind.Utc), 14, 15 },
                    { 49, new DateTime(2024, 12, 10, 12, 0, 0, 0, DateTimeKind.Utc), 8, 127 },
                    { 50, new DateTime(2024, 6, 29, 17, 0, 0, 0, DateTimeKind.Utc), 14, 67 },
                    { 51, new DateTime(2024, 10, 27, 11, 0, 0, 0, DateTimeKind.Utc), 18, 156 },
                    { 52, new DateTime(2025, 6, 29, 7, 0, 0, 0, DateTimeKind.Utc), 14, 105 },
                    { 53, new DateTime(2025, 4, 18, 13, 0, 0, 0, DateTimeKind.Utc), 19, 189 },
                    { 54, new DateTime(2025, 10, 19, 14, 0, 0, 0, DateTimeKind.Utc), 17, 171 },
                    { 55, new DateTime(2024, 8, 9, 8, 0, 0, 0, DateTimeKind.Utc), 4, 118 },
                    { 56, new DateTime(2025, 5, 2, 15, 0, 0, 0, DateTimeKind.Utc), 6, 80 },
                    { 57, new DateTime(2025, 9, 17, 19, 0, 0, 0, DateTimeKind.Utc), 9, 41 },
                    { 58, new DateTime(2024, 7, 20, 6, 0, 0, 0, DateTimeKind.Utc), 13, 30 },
                    { 59, new DateTime(2024, 6, 3, 8, 0, 0, 0, DateTimeKind.Utc), 17, 148 },
                    { 60, new DateTime(2024, 12, 11, 15, 0, 0, 0, DateTimeKind.Utc), 8, 136 },
                    { 61, new DateTime(2024, 9, 22, 18, 0, 0, 0, DateTimeKind.Utc), 17, 143 },
                    { 62, new DateTime(2024, 12, 9, 13, 0, 0, 0, DateTimeKind.Utc), 13, 20 },
                    { 63, new DateTime(2024, 7, 18, 11, 0, 0, 0, DateTimeKind.Utc), 8, 86 },
                    { 64, new DateTime(2024, 11, 2, 11, 0, 0, 0, DateTimeKind.Utc), 8, 116 },
                    { 65, new DateTime(2025, 5, 2, 14, 0, 0, 0, DateTimeKind.Utc), 12, 55 },
                    { 66, new DateTime(2024, 12, 27, 12, 0, 0, 0, DateTimeKind.Utc), 11, 196 },
                    { 67, new DateTime(2024, 1, 22, 13, 0, 0, 0, DateTimeKind.Utc), 3, 141 },
                    { 68, new DateTime(2025, 4, 29, 19, 0, 0, 0, DateTimeKind.Utc), 11, 106 },
                    { 69, new DateTime(2024, 3, 11, 15, 0, 0, 0, DateTimeKind.Utc), 16, 100 },
                    { 70, new DateTime(2024, 1, 10, 11, 0, 0, 0, DateTimeKind.Utc), 1, 98 },
                    { 71, new DateTime(2025, 8, 27, 16, 0, 0, 0, DateTimeKind.Utc), 15, 110 },
                    { 72, new DateTime(2024, 1, 19, 11, 0, 0, 0, DateTimeKind.Utc), 20, 136 },
                    { 73, new DateTime(2025, 12, 20, 14, 0, 0, 0, DateTimeKind.Utc), 6, 103 },
                    { 74, new DateTime(2025, 5, 29, 14, 0, 0, 0, DateTimeKind.Utc), 20, 49 },
                    { 75, new DateTime(2024, 5, 15, 19, 0, 0, 0, DateTimeKind.Utc), 5, 43 },
                    { 76, new DateTime(2025, 5, 2, 19, 0, 0, 0, DateTimeKind.Utc), 19, 119 },
                    { 77, new DateTime(2024, 3, 7, 14, 0, 0, 0, DateTimeKind.Utc), 4, 199 },
                    { 78, new DateTime(2025, 10, 19, 10, 0, 0, 0, DateTimeKind.Utc), 11, 67 },
                    { 79, new DateTime(2025, 5, 19, 10, 0, 0, 0, DateTimeKind.Utc), 2, 26 },
                    { 80, new DateTime(2025, 6, 9, 15, 0, 0, 0, DateTimeKind.Utc), 3, 92 },
                    { 81, new DateTime(2025, 7, 16, 16, 0, 0, 0, DateTimeKind.Utc), 10, 130 },
                    { 82, new DateTime(2024, 7, 31, 17, 0, 0, 0, DateTimeKind.Utc), 10, 48 },
                    { 83, new DateTime(2025, 11, 19, 11, 0, 0, 0, DateTimeKind.Utc), 3, 167 },
                    { 84, new DateTime(2024, 4, 9, 7, 0, 0, 0, DateTimeKind.Utc), 19, 155 },
                    { 85, new DateTime(2025, 2, 9, 11, 0, 0, 0, DateTimeKind.Utc), 17, 15 },
                    { 86, new DateTime(2024, 3, 4, 14, 0, 0, 0, DateTimeKind.Utc), 18, 167 },
                    { 87, new DateTime(2024, 4, 15, 13, 0, 0, 0, DateTimeKind.Utc), 11, 49 },
                    { 88, new DateTime(2024, 11, 28, 11, 0, 0, 0, DateTimeKind.Utc), 11, 14 },
                    { 89, new DateTime(2024, 9, 8, 12, 0, 0, 0, DateTimeKind.Utc), 4, 100 },
                    { 90, new DateTime(2024, 10, 30, 8, 0, 0, 0, DateTimeKind.Utc), 16, 15 },
                    { 91, new DateTime(2025, 5, 8, 19, 0, 0, 0, DateTimeKind.Utc), 14, 147 },
                    { 92, new DateTime(2024, 7, 10, 10, 0, 0, 0, DateTimeKind.Utc), 17, 152 },
                    { 93, new DateTime(2025, 2, 14, 6, 0, 0, 0, DateTimeKind.Utc), 8, 66 },
                    { 94, new DateTime(2025, 12, 8, 19, 0, 0, 0, DateTimeKind.Utc), 17, 68 },
                    { 95, new DateTime(2024, 4, 19, 11, 0, 0, 0, DateTimeKind.Utc), 18, 175 },
                    { 96, new DateTime(2024, 4, 15, 7, 0, 0, 0, DateTimeKind.Utc), 14, 115 },
                    { 97, new DateTime(2025, 4, 10, 6, 0, 0, 0, DateTimeKind.Utc), 2, 62 },
                    { 98, new DateTime(2024, 3, 20, 14, 0, 0, 0, DateTimeKind.Utc), 16, 194 },
                    { 99, new DateTime(2024, 11, 15, 15, 0, 0, 0, DateTimeKind.Utc), 8, 151 },
                    { 100, new DateTime(2024, 7, 30, 15, 0, 0, 0, DateTimeKind.Utc), 7, 71 }
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
                    { 2, 1, "take together with a bag of chips", 2 },
                    { 1, 2, "wash it down with a glass of coke", 2 },
                    { 1, 3, "don't spend it all at once", 1 },
                    { 2, 3, "wash it down with a glass of coke", 2 },
                    { 1, 4, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 3 },
                    { 1, 5, "wash it down with a glass of coke", 1 },
                    { 2, 5, "wash it down with a glass of coke", 1 },
                    { 1, 6, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 1, 7, "taste even better when you put them in cinnamon rolls", 1 },
                    { 1, 8, "don't spend it all at once", 2 },
                    { 1, 9, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 2, 10, "wash it down with a glass of coke", 1 },
                    { 1, 11, "take together with a bag of chips", 2 },
                    { 1, 12, "wash it down with a glass of coke", 2 },
                    { 1, 13, "take together with a bag of chips", 2 },
                    { 2, 13, "wash it down with a glass of coke", 1 },
                    { 2, 14, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 1, 15, "don't spend it all at once", 1 },
                    { 2, 15, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 16, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 2, 16, "taste even better when you put them in cinnamon rolls", 2 },
                    { 2, 17, "wash it down with a glass of coke", 2 },
                    { 2, 18, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 2, 19, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 2, 20, "don't spend it all at once", 1 },
                    { 1, 21, "take together with a bag of chips", 1 },
                    { 2, 21, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 22, "taste even better when you put them in cinnamon rolls", 1 },
                    { 1, 23, "wash it down with a glass of coke", 2 },
                    { 1, 24, "wash it down with a glass of coke", 3 },
                    { 2, 25, "wash it down with a glass of coke", 3 },
                    { 2, 26, "wash it down with a glass of coke", 1 },
                    { 1, 27, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 1, 28, "wash it down with a glass of coke", 1 },
                    { 2, 28, "don't spend it all at once", 1 },
                    { 2, 29, "taste even better when you put them in cinnamon rolls", 1 },
                    { 1, 30, "wash it down with a glass of coke", 1 },
                    { 2, 30, "take together with a bag of chips", 1 },
                    { 1, 31, "taste even better when you put them in cinnamon rolls", 1 },
                    { 2, 31, "don't spend it all at once", 2 },
                    { 2, 32, "taste even better when you put them in cinnamon rolls", 3 },
                    { 1, 33, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 34, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 35, "taste even better when you put them in cinnamon rolls", 1 },
                    { 2, 36, "wash it down with a glass of coke", 2 },
                    { 2, 37, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 1, 38, "don't spend it all at once", 1 },
                    { 2, 39, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 40, "wash it down with a glass of coke", 2 },
                    { 1, 41, "wash it down with a glass of coke", 2 },
                    { 1, 42, "taste even better when you put them in cinnamon rolls", 2 },
                    { 2, 43, "don't spend it all at once", 2 },
                    { 2, 44, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 1, 45, "taste even better when you put them in cinnamon rolls", 1 },
                    { 2, 45, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 46, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 2 },
                    { 2, 46, "don't spend it all at once", 2 },
                    { 2, 47, "don't spend it all at once", 2 },
                    { 1, 48, "take together with a bag of chips", 3 },
                    { 1, 49, "don't spend it all at once", 2 },
                    { 2, 49, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 1, 50, "take together with a bag of chips", 1 },
                    { 2, 50, "don't spend it all at once", 1 },
                    { 2, 51, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 1 },
                    { 2, 52, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 53, "wash it down with a glass of coke", 2 },
                    { 1, 54, "don't spend it all at once", 2 },
                    { 2, 54, "taste even better when you put them in cinnamon rolls", 2 },
                    { 2, 55, "don't spend it all at once", 1 },
                    { 1, 56, "taste even better when you put them in cinnamon rolls", 2 },
                    { 1, 57, "take together with a bag of chips", 2 },
                    { 2, 58, "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)", 3 },
                    { 2, 59, "don't spend it all at once", 2 },
                    { 2, 60, "wash it down with a glass of coke", 1 }
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
