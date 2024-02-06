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

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Specialist Doctor Joseph Morecola" },
                    { 2, "Specialist Daphne Snackmore" },
                    { 3, "Dr. Dorian Sugargood" },
                    { 4, "Master Dr. Penelope Eatmore" },
                    { 5, "Master Dr. Josephine Colamore" },
                    { 6, "Professor Dorian Snackmore" },
                    { 7, "Dr. Lavinia Colagood" },
                    { 8, "Professor Beatrice Snackmore" },
                    { 9, "Supreme Dr. Xavier Colagood" },
                    { 10, "Dr. Indiana Candycraze" },
                    { 11, "Supreme Dr. Alexander Eatmore" },
                    { 12, "Doc. Leopold Sodamore" },
                    { 13, "M.D. Maximilian Snackright" },
                    { 14, "Professor Leopold Carbcrave" },
                    { 15, "Prof. Dr. Miranda Candygood" },
                    { 16, "Professor Benedict Snackright" },
                    { 17, "Professor Isabella Jones" },
                    { 18, "Dr. Harrison Snackmore" },
                    { 19, "Specialist Dorian Sugarmore" },
                    { 20, "PhD Dr. Julian Sodagood" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Anna Smith" },
                    { 2, "Chris Miller" },
                    { 3, "Julia Anderson" },
                    { 4, "Claire Smith" },
                    { 5, "Greg Johnson" },
                    { 6, "Greg Thompson" },
                    { 7, "Emily Wilson" },
                    { 8, "Jack Smith" },
                    { 9, "Dave Miller" },
                    { 10, "Jack Taylor" },
                    { 11, "John Harris" },
                    { 12, "Frank Williams" },
                    { 13, "Claire Harris" },
                    { 14, "Frank Wilson" },
                    { 15, "Ian Brown" },
                    { 16, "Claire Martin" },
                    { 17, "Frank Garcia" },
                    { 18, "John Martin" },
                    { 19, "Dave Davis" },
                    { 20, "John Smith" },
                    { 21, "Anna Brown" },
                    { 22, "Jack Thomas" },
                    { 23, "Claire Miller" },
                    { 24, "Diane Martinez" },
                    { 25, "Grace Brown" },
                    { 26, "Ian Jackson" },
                    { 27, "Jack Robinson" },
                    { 28, "Julia Wilson" },
                    { 29, "Greg Smith" },
                    { 30, "Greg Martin" },
                    { 31, "Greg Garcia" },
                    { 32, "Beth Moore" },
                    { 33, "John Smith" },
                    { 34, "Jack Davis" },
                    { 35, "Ben Brown" },
                    { 36, "John Thomas" },
                    { 37, "Beth Thomas" },
                    { 38, "Emily Thompson" },
                    { 39, "Dave White" },
                    { 40, "Anna Jackson" },
                    { 41, "Grace Miller" },
                    { 42, "Claire Smith" },
                    { 43, "Frank Williams" },
                    { 44, "Claire Thomas" },
                    { 45, "Beth Harris" },
                    { 46, "Grace Smith" },
                    { 47, "Diane Taylor" },
                    { 48, "Julia Jackson" },
                    { 49, "Ben Jackson" },
                    { 50, "John Brown" },
                    { 51, "Chris Martin" },
                    { 52, "Ben Johnson" },
                    { 53, "Grace Thomas" },
                    { 54, "Ian Johnson" },
                    { 55, "Claire Johnson" },
                    { 56, "Frank Martin" },
                    { 57, "John Thompson" },
                    { 58, "Grace Brown" },
                    { 59, "Claire Harris" },
                    { 60, "Emily Brown" },
                    { 61, "Emily Williams" },
                    { 62, "Grace White" },
                    { 63, "Julia Smith" },
                    { 64, "Diane Garcia" },
                    { 65, "Jack Wilson" },
                    { 66, "Chris Martin" },
                    { 67, "Grace Jackson" },
                    { 68, "Julia Thompson" },
                    { 69, "Beth Moore" },
                    { 70, "Grace Moore" },
                    { 71, "Diane Johnson" },
                    { 72, "Diane Davis" },
                    { 73, "Claire Martin" },
                    { 74, "Frank Brown" },
                    { 75, "Dave Miller" },
                    { 76, "Julia Jackson" },
                    { 77, "Ben Thomas" },
                    { 78, "Ben Williams" },
                    { 79, "Jack Taylor" },
                    { 80, "Dave White" },
                    { 81, "Jack Wilson" },
                    { 82, "Ben Garcia" },
                    { 83, "Dave Thompson" },
                    { 84, "Beth Anderson" },
                    { 85, "Jack Anderson" },
                    { 86, "Ben Harris" },
                    { 87, "John Anderson" },
                    { 88, "Frank Brown" },
                    { 89, "Greg Moore" },
                    { 90, "Anna Robinson" },
                    { 91, "Chris Taylor" },
                    { 92, "Greg Anderson" },
                    { 93, "Greg Martin" },
                    { 94, "Emily Martin" },
                    { 95, "Ben Williams" },
                    { 96, "Julia Jackson" },
                    { 97, "Jack Anderson" },
                    { 98, "Dave Anderson" },
                    { 99, "Anna Davis" },
                    { 100, "Dave Williams" },
                    { 101, "Frank Miller" },
                    { 102, "Frank Wilson" },
                    { 103, "Julia Thomas" },
                    { 104, "Anna Wilson" },
                    { 105, "Jack Harris" },
                    { 106, "Diane Smith" },
                    { 107, "Dave Anderson" },
                    { 108, "Beth Jackson" },
                    { 109, "Claire Thomas" },
                    { 110, "Grace Davis" },
                    { 111, "Beth Johnson" },
                    { 112, "Anna Davis" },
                    { 113, "Claire Taylor" },
                    { 114, "Chris Jackson" },
                    { 115, "Grace Miller" },
                    { 116, "Greg Johnson" },
                    { 117, "Jack Martin" },
                    { 118, "Ben Davis" },
                    { 119, "Chris Johnson" },
                    { 120, "Emily Moore" },
                    { 121, "Beth Martin" },
                    { 122, "Emily Wilson" },
                    { 123, "Claire Garcia" },
                    { 124, "John Thomas" },
                    { 125, "Dave Taylor" },
                    { 126, "Dave Johnson" },
                    { 127, "Ben Williams" },
                    { 128, "Grace Jackson" },
                    { 129, "Frank Anderson" },
                    { 130, "Grace Davis" },
                    { 131, "Grace Wilson" },
                    { 132, "Diane Robinson" },
                    { 133, "Diane Brown" },
                    { 134, "Emily White" },
                    { 135, "Anna Martinez" },
                    { 136, "Chris Brown" },
                    { 137, "Dave Taylor" },
                    { 138, "Ben Garcia" },
                    { 139, "Frank Taylor" },
                    { 140, "Claire Martin" },
                    { 141, "Dave Smith" },
                    { 142, "Greg Moore" },
                    { 143, "Diane Williams" },
                    { 144, "Claire Davis" },
                    { 145, "Ben Smith" },
                    { 146, "Jack Harris" },
                    { 147, "Diane Thomas" },
                    { 148, "Claire Johnson" },
                    { 149, "Beth Jackson" },
                    { 150, "Dave Smith" },
                    { 151, "Diane Harris" },
                    { 152, "Diane Smith" },
                    { 153, "Chris Davis" },
                    { 154, "Ben White" },
                    { 155, "John Johnson" },
                    { 156, "Dave Martinez" },
                    { 157, "Ian Johnson" },
                    { 158, "Chris Williams" },
                    { 159, "Chris Martinez" },
                    { 160, "Grace Thomas" },
                    { 161, "Frank Williams" },
                    { 162, "Grace Jackson" },
                    { 163, "Anna Garcia" },
                    { 164, "Ben Robinson" },
                    { 165, "Anna Taylor" },
                    { 166, "Ian Thomas" },
                    { 167, "Ben Smith" },
                    { 168, "Greg Williams" },
                    { 169, "John Smith" },
                    { 170, "John Davis" },
                    { 171, "Greg Robinson" },
                    { 172, "Frank Smith" },
                    { 173, "Dave Wilson" },
                    { 174, "Ben Williams" },
                    { 175, "Grace Jackson" },
                    { 176, "Julia Anderson" },
                    { 177, "Grace Brown" },
                    { 178, "Ben Moore" },
                    { 179, "Diane Taylor" },
                    { 180, "Ian Martin" },
                    { 181, "Anna Martinez" },
                    { 182, "Chris Smith" },
                    { 183, "Frank Jackson" },
                    { 184, "Anna Wilson" },
                    { 185, "Anna Martinez" },
                    { 186, "Frank Anderson" },
                    { 187, "Claire Thompson" },
                    { 188, "Anna Davis" },
                    { 189, "Julia Anderson" },
                    { 190, "Jack Taylor" },
                    { 191, "Julia Robinson" },
                    { 192, "Chris Thomas" },
                    { 193, "John Davis" },
                    { 194, "Ian Thompson" },
                    { 195, "Grace Thompson" },
                    { 196, "Dave Smith" },
                    { 197, "Emily Martin" },
                    { 198, "Grace Harris" },
                    { 199, "John Thomas" },
                    { 200, "Beth Robinson" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "appointment_time", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 16, 30, 0, 0, DateTimeKind.Utc), 1, 1 },
                    { 2, new DateTime(2024, 12, 24, 10, 0, 0, 0, DateTimeKind.Utc), 2, 72 },
                    { 3, new DateTime(2025, 8, 25, 15, 0, 0, 0, DateTimeKind.Utc), 14, 126 },
                    { 4, new DateTime(2024, 1, 2, 16, 0, 0, 0, DateTimeKind.Utc), 4, 108 },
                    { 5, new DateTime(2025, 8, 23, 12, 0, 0, 0, DateTimeKind.Utc), 19, 95 },
                    { 6, new DateTime(2025, 3, 3, 19, 0, 0, 0, DateTimeKind.Utc), 1, 26 },
                    { 7, new DateTime(2024, 10, 14, 18, 0, 0, 0, DateTimeKind.Utc), 15, 9 },
                    { 8, new DateTime(2024, 9, 1, 8, 0, 0, 0, DateTimeKind.Utc), 7, 148 },
                    { 9, new DateTime(2025, 9, 4, 17, 0, 0, 0, DateTimeKind.Utc), 12, 144 },
                    { 10, new DateTime(2024, 8, 13, 13, 0, 0, 0, DateTimeKind.Utc), 18, 113 },
                    { 11, new DateTime(2025, 4, 4, 6, 0, 0, 0, DateTimeKind.Utc), 2, 94 },
                    { 12, new DateTime(2024, 9, 17, 11, 0, 0, 0, DateTimeKind.Utc), 4, 55 },
                    { 13, new DateTime(2025, 7, 6, 16, 0, 0, 0, DateTimeKind.Utc), 12, 172 },
                    { 14, new DateTime(2024, 12, 17, 7, 0, 0, 0, DateTimeKind.Utc), 8, 111 },
                    { 15, new DateTime(2025, 9, 7, 6, 0, 0, 0, DateTimeKind.Utc), 2, 185 },
                    { 16, new DateTime(2024, 2, 14, 15, 0, 0, 0, DateTimeKind.Utc), 1, 31 },
                    { 17, new DateTime(2025, 6, 14, 9, 0, 0, 0, DateTimeKind.Utc), 18, 69 },
                    { 18, new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Utc), 17, 137 },
                    { 19, new DateTime(2025, 9, 24, 17, 0, 0, 0, DateTimeKind.Utc), 15, 191 },
                    { 20, new DateTime(2025, 2, 2, 11, 0, 0, 0, DateTimeKind.Utc), 17, 120 },
                    { 21, new DateTime(2024, 7, 25, 16, 0, 0, 0, DateTimeKind.Utc), 11, 20 },
                    { 22, new DateTime(2025, 6, 21, 18, 0, 0, 0, DateTimeKind.Utc), 12, 107 },
                    { 23, new DateTime(2025, 3, 31, 6, 0, 0, 0, DateTimeKind.Utc), 10, 9 },
                    { 24, new DateTime(2025, 2, 10, 11, 0, 0, 0, DateTimeKind.Utc), 19, 41 },
                    { 25, new DateTime(2024, 9, 2, 17, 0, 0, 0, DateTimeKind.Utc), 7, 182 },
                    { 26, new DateTime(2025, 5, 22, 11, 0, 0, 0, DateTimeKind.Utc), 3, 62 },
                    { 27, new DateTime(2025, 7, 15, 19, 0, 0, 0, DateTimeKind.Utc), 16, 137 },
                    { 28, new DateTime(2024, 4, 13, 7, 0, 0, 0, DateTimeKind.Utc), 16, 114 },
                    { 29, new DateTime(2025, 3, 28, 16, 0, 0, 0, DateTimeKind.Utc), 14, 144 },
                    { 30, new DateTime(2025, 7, 29, 15, 0, 0, 0, DateTimeKind.Utc), 19, 77 },
                    { 31, new DateTime(2025, 1, 16, 10, 0, 0, 0, DateTimeKind.Utc), 5, 165 },
                    { 32, new DateTime(2024, 5, 30, 7, 0, 0, 0, DateTimeKind.Utc), 15, 4 },
                    { 33, new DateTime(2025, 8, 29, 15, 0, 0, 0, DateTimeKind.Utc), 14, 111 },
                    { 34, new DateTime(2025, 5, 27, 12, 0, 0, 0, DateTimeKind.Utc), 2, 18 },
                    { 35, new DateTime(2025, 9, 15, 6, 0, 0, 0, DateTimeKind.Utc), 4, 50 },
                    { 36, new DateTime(2024, 8, 21, 15, 0, 0, 0, DateTimeKind.Utc), 18, 112 },
                    { 37, new DateTime(2025, 11, 22, 18, 0, 0, 0, DateTimeKind.Utc), 20, 124 },
                    { 38, new DateTime(2024, 9, 22, 6, 0, 0, 0, DateTimeKind.Utc), 16, 111 },
                    { 39, new DateTime(2025, 3, 11, 14, 0, 0, 0, DateTimeKind.Utc), 9, 71 },
                    { 40, new DateTime(2024, 8, 21, 7, 0, 0, 0, DateTimeKind.Utc), 17, 115 },
                    { 41, new DateTime(2024, 7, 19, 14, 0, 0, 0, DateTimeKind.Utc), 1, 159 },
                    { 42, new DateTime(2025, 7, 14, 17, 0, 0, 0, DateTimeKind.Utc), 9, 174 },
                    { 43, new DateTime(2025, 11, 1, 15, 0, 0, 0, DateTimeKind.Utc), 19, 100 },
                    { 44, new DateTime(2024, 3, 16, 7, 0, 0, 0, DateTimeKind.Utc), 8, 198 },
                    { 45, new DateTime(2024, 2, 26, 11, 0, 0, 0, DateTimeKind.Utc), 15, 32 },
                    { 46, new DateTime(2025, 8, 15, 12, 0, 0, 0, DateTimeKind.Utc), 1, 198 },
                    { 47, new DateTime(2025, 9, 22, 15, 0, 0, 0, DateTimeKind.Utc), 3, 139 },
                    { 48, new DateTime(2024, 3, 6, 18, 0, 0, 0, DateTimeKind.Utc), 6, 165 },
                    { 49, new DateTime(2024, 7, 31, 11, 0, 0, 0, DateTimeKind.Utc), 11, 88 },
                    { 50, new DateTime(2024, 5, 6, 10, 0, 0, 0, DateTimeKind.Utc), 16, 150 },
                    { 51, new DateTime(2025, 7, 22, 13, 0, 0, 0, DateTimeKind.Utc), 17, 9 },
                    { 52, new DateTime(2025, 10, 20, 8, 0, 0, 0, DateTimeKind.Utc), 19, 138 },
                    { 53, new DateTime(2024, 7, 26, 7, 0, 0, 0, DateTimeKind.Utc), 8, 142 },
                    { 54, new DateTime(2024, 4, 17, 8, 0, 0, 0, DateTimeKind.Utc), 15, 14 },
                    { 55, new DateTime(2025, 1, 14, 14, 0, 0, 0, DateTimeKind.Utc), 16, 196 },
                    { 56, new DateTime(2024, 10, 26, 6, 0, 0, 0, DateTimeKind.Utc), 17, 12 },
                    { 57, new DateTime(2024, 2, 29, 11, 0, 0, 0, DateTimeKind.Utc), 10, 47 },
                    { 58, new DateTime(2025, 11, 23, 13, 0, 0, 0, DateTimeKind.Utc), 13, 73 },
                    { 59, new DateTime(2024, 1, 27, 18, 0, 0, 0, DateTimeKind.Utc), 3, 181 },
                    { 60, new DateTime(2025, 12, 16, 11, 0, 0, 0, DateTimeKind.Utc), 14, 117 },
                    { 61, new DateTime(2024, 5, 4, 18, 0, 0, 0, DateTimeKind.Utc), 12, 150 },
                    { 62, new DateTime(2025, 5, 14, 13, 0, 0, 0, DateTimeKind.Utc), 1, 2 },
                    { 63, new DateTime(2025, 1, 19, 7, 0, 0, 0, DateTimeKind.Utc), 19, 7 },
                    { 64, new DateTime(2024, 2, 26, 8, 0, 0, 0, DateTimeKind.Utc), 6, 146 },
                    { 65, new DateTime(2024, 8, 31, 15, 0, 0, 0, DateTimeKind.Utc), 19, 101 },
                    { 66, new DateTime(2025, 2, 6, 17, 0, 0, 0, DateTimeKind.Utc), 15, 39 },
                    { 67, new DateTime(2024, 2, 11, 13, 0, 0, 0, DateTimeKind.Utc), 14, 177 },
                    { 68, new DateTime(2024, 8, 5, 9, 0, 0, 0, DateTimeKind.Utc), 4, 34 },
                    { 69, new DateTime(2024, 2, 9, 10, 0, 0, 0, DateTimeKind.Utc), 14, 63 },
                    { 70, new DateTime(2025, 12, 29, 6, 0, 0, 0, DateTimeKind.Utc), 9, 92 },
                    { 71, new DateTime(2025, 10, 31, 16, 0, 0, 0, DateTimeKind.Utc), 15, 141 },
                    { 72, new DateTime(2025, 12, 28, 11, 0, 0, 0, DateTimeKind.Utc), 1, 35 },
                    { 73, new DateTime(2025, 4, 29, 6, 0, 0, 0, DateTimeKind.Utc), 14, 42 },
                    { 74, new DateTime(2025, 7, 6, 13, 0, 0, 0, DateTimeKind.Utc), 4, 24 },
                    { 75, new DateTime(2024, 5, 12, 19, 0, 0, 0, DateTimeKind.Utc), 11, 65 },
                    { 76, new DateTime(2024, 8, 6, 13, 0, 0, 0, DateTimeKind.Utc), 18, 119 },
                    { 77, new DateTime(2025, 10, 17, 14, 0, 0, 0, DateTimeKind.Utc), 3, 110 },
                    { 78, new DateTime(2024, 10, 19, 18, 0, 0, 0, DateTimeKind.Utc), 14, 175 },
                    { 79, new DateTime(2025, 1, 27, 8, 0, 0, 0, DateTimeKind.Utc), 15, 160 },
                    { 80, new DateTime(2025, 10, 18, 15, 0, 0, 0, DateTimeKind.Utc), 4, 61 },
                    { 81, new DateTime(2024, 11, 30, 6, 0, 0, 0, DateTimeKind.Utc), 19, 110 },
                    { 82, new DateTime(2025, 5, 6, 13, 0, 0, 0, DateTimeKind.Utc), 9, 118 },
                    { 83, new DateTime(2025, 11, 13, 18, 0, 0, 0, DateTimeKind.Utc), 2, 41 },
                    { 84, new DateTime(2025, 8, 4, 6, 0, 0, 0, DateTimeKind.Utc), 12, 8 },
                    { 85, new DateTime(2024, 3, 27, 18, 0, 0, 0, DateTimeKind.Utc), 4, 83 },
                    { 86, new DateTime(2025, 7, 17, 16, 0, 0, 0, DateTimeKind.Utc), 13, 137 },
                    { 87, new DateTime(2024, 4, 11, 6, 0, 0, 0, DateTimeKind.Utc), 2, 19 },
                    { 88, new DateTime(2024, 8, 23, 19, 0, 0, 0, DateTimeKind.Utc), 10, 53 },
                    { 89, new DateTime(2025, 9, 12, 19, 0, 0, 0, DateTimeKind.Utc), 13, 111 },
                    { 90, new DateTime(2024, 2, 17, 8, 0, 0, 0, DateTimeKind.Utc), 12, 149 },
                    { 91, new DateTime(2024, 3, 27, 13, 0, 0, 0, DateTimeKind.Utc), 3, 187 },
                    { 92, new DateTime(2025, 10, 17, 12, 0, 0, 0, DateTimeKind.Utc), 12, 134 },
                    { 93, new DateTime(2025, 9, 15, 11, 0, 0, 0, DateTimeKind.Utc), 20, 161 },
                    { 94, new DateTime(2025, 7, 11, 11, 0, 0, 0, DateTimeKind.Utc), 3, 134 },
                    { 95, new DateTime(2025, 2, 11, 13, 0, 0, 0, DateTimeKind.Utc), 16, 158 },
                    { 96, new DateTime(2025, 8, 22, 16, 0, 0, 0, DateTimeKind.Utc), 3, 113 },
                    { 97, new DateTime(2024, 5, 10, 9, 0, 0, 0, DateTimeKind.Utc), 20, 177 },
                    { 98, new DateTime(2024, 10, 25, 17, 0, 0, 0, DateTimeKind.Utc), 17, 87 },
                    { 99, new DateTime(2024, 10, 10, 18, 0, 0, 0, DateTimeKind.Utc), 5, 21 },
                    { 100, new DateTime(2024, 6, 17, 13, 0, 0, 0, DateTimeKind.Utc), 7, 89 }
                });

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
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
