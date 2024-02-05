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
                    { 1, "Supreme Dr. Miranda Sugarmore" },
                    { 2, "Supreme Dr. Miranda Snackwell" },
                    { 3, "Doctor Penelope Sodamore" },
                    { 4, "M.D. Montgomery Sugarmore" },
                    { 5, "Master Dr. Geoffrey Colamore" },
                    { 6, "Doc. Benedict Jones" },
                    { 7, "Supreme Dr. Nathaniel Sugarlove" },
                    { 8, "Specialist Edmund Jones" },
                    { 9, "M.D. Chawton Sugarlove" },
                    { 10, "Supreme Dr. Alexander Colamore" },
                    { 11, "Master Dr. Sebastian Butterbliss" },
                    { 12, "Supreme Dr. Edmund Sodamore" },
                    { 13, "Specialist Leopold Snackright" },
                    { 14, "Master Dr. Benedict Snackwell" },
                    { 15, "M.D. Lavinia Chocofix" },
                    { 16, "Master Dr. Dorian Snackright" },
                    { 17, "PhD Dr. Oliver Sugarlove" },
                    { 18, "Professor Leopold Snackright" },
                    { 19, "Supreme Dr. Lavinia Sugarlove" },
                    { 20, "Doctor Josephine Chocofix" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Frank Smith" },
                    { 2, "Grace Martinez" },
                    { 3, "Emily Davis" },
                    { 4, "Grace Jackson" },
                    { 5, "Greg Williams" },
                    { 6, "Diane Martinez" },
                    { 7, "Diane Jackson" },
                    { 8, "Anna Thomas" },
                    { 9, "Grace Smith" },
                    { 10, "John Robinson" },
                    { 11, "Beth Garcia" },
                    { 12, "Ben Taylor" },
                    { 13, "Anna Thomas" },
                    { 14, "Dave Davis" },
                    { 15, "Ian Johnson" },
                    { 16, "Chris Garcia" },
                    { 17, "Emily Martin" },
                    { 18, "John Anderson" },
                    { 19, "Emily Anderson" },
                    { 20, "Ian Jackson" },
                    { 21, "Julia Thompson" },
                    { 22, "Beth Smith" },
                    { 23, "Dave Taylor" },
                    { 24, "Frank White" },
                    { 25, "Frank Taylor" },
                    { 26, "Dave Harris" },
                    { 27, "Emily Taylor" },
                    { 28, "Greg Thompson" },
                    { 29, "Diane Johnson" },
                    { 30, "Jack Davis" },
                    { 31, "John Thomas" },
                    { 32, "Anna Martin" },
                    { 33, "Diane Thomas" },
                    { 34, "Dave Harris" },
                    { 35, "Frank White" },
                    { 36, "Emily Smith" },
                    { 37, "Frank Williams" },
                    { 38, "Jack Thomas" },
                    { 39, "Dave Martin" },
                    { 40, "Ben Thomas" },
                    { 41, "Julia Taylor" },
                    { 42, "Chris Taylor" },
                    { 43, "Ben Davis" },
                    { 44, "Claire White" },
                    { 45, "Julia Williams" },
                    { 46, "Diane Williams" },
                    { 47, "Chris Taylor" },
                    { 48, "Jack Brown" },
                    { 49, "Grace Davis" },
                    { 50, "Grace Johnson" },
                    { 51, "Emily White" },
                    { 52, "Greg Wilson" },
                    { 53, "Anna Robinson" },
                    { 54, "Jack Smith" },
                    { 55, "Greg Miller" },
                    { 56, "John Moore" },
                    { 57, "Diane Garcia" },
                    { 58, "Chris Anderson" },
                    { 59, "Diane Wilson" },
                    { 60, "Jack Harris" },
                    { 61, "Chris Anderson" },
                    { 62, "Grace Anderson" },
                    { 63, "Julia Thomas" },
                    { 64, "Dave Johnson" },
                    { 65, "Jack Davis" },
                    { 66, "Emily Brown" },
                    { 67, "Greg Anderson" },
                    { 68, "Emily Martin" },
                    { 69, "Emily Robinson" },
                    { 70, "Ian Brown" },
                    { 71, "Greg Thomas" },
                    { 72, "John Davis" },
                    { 73, "Ben Martinez" },
                    { 74, "Claire Anderson" },
                    { 75, "Ben Martin" },
                    { 76, "Ian Davis" },
                    { 77, "Diane Garcia" },
                    { 78, "Beth Taylor" },
                    { 79, "Beth Johnson" },
                    { 80, "Greg Martinez" },
                    { 81, "Dave Martin" },
                    { 82, "Frank Davis" },
                    { 83, "Dave Martinez" },
                    { 84, "Julia Harris" },
                    { 85, "Greg Miller" },
                    { 86, "Emily Garcia" },
                    { 87, "Greg Robinson" },
                    { 88, "Beth Martinez" },
                    { 89, "Emily Taylor" },
                    { 90, "Ian Harris" },
                    { 91, "Grace Miller" },
                    { 92, "Ian Williams" },
                    { 93, "Anna Martin" },
                    { 94, "Julia Robinson" },
                    { 95, "Jack Martin" },
                    { 96, "Beth Wilson" },
                    { 97, "Greg Jackson" },
                    { 98, "Greg Harris" },
                    { 99, "Claire Williams" },
                    { 100, "Chris White" },
                    { 101, "Frank White" },
                    { 102, "Emily Garcia" },
                    { 103, "Greg Robinson" },
                    { 104, "Emily Harris" },
                    { 105, "Beth Taylor" },
                    { 106, "Chris Williams" },
                    { 107, "Greg Johnson" },
                    { 108, "Jack Moore" },
                    { 109, "Grace Taylor" },
                    { 110, "Ian Williams" },
                    { 111, "Greg Williams" },
                    { 112, "Anna Martin" },
                    { 113, "Diane Taylor" },
                    { 114, "Beth Taylor" },
                    { 115, "Jack Anderson" },
                    { 116, "Greg Miller" },
                    { 117, "Beth Thomas" },
                    { 118, "John Garcia" },
                    { 119, "Grace Garcia" },
                    { 120, "Grace Williams" },
                    { 121, "John Anderson" },
                    { 122, "Jack Moore" },
                    { 123, "Beth Thompson" },
                    { 124, "Ian Smith" },
                    { 125, "Grace Thompson" },
                    { 126, "Ben Johnson" },
                    { 127, "Ben Thomas" },
                    { 128, "Jack Robinson" },
                    { 129, "Anna Wilson" },
                    { 130, "Beth Williams" },
                    { 131, "Anna Anderson" },
                    { 132, "Frank Miller" },
                    { 133, "Ben Robinson" },
                    { 134, "Greg Wilson" },
                    { 135, "Greg Thompson" },
                    { 136, "Jack Martin" },
                    { 137, "Chris Johnson" },
                    { 138, "Claire Harris" },
                    { 139, "Diane Taylor" },
                    { 140, "John Thompson" },
                    { 141, "Dave Johnson" },
                    { 142, "Grace Johnson" },
                    { 143, "Emily White" },
                    { 144, "Beth Martinez" },
                    { 145, "Chris Smith" },
                    { 146, "Beth Taylor" },
                    { 147, "Greg Martinez" },
                    { 148, "Beth Jackson" },
                    { 149, "Jack White" },
                    { 150, "Frank Thomas" },
                    { 151, "Anna Jackson" },
                    { 152, "Diane Johnson" },
                    { 153, "Ben Smith" },
                    { 154, "Frank Thompson" },
                    { 155, "Beth Miller" },
                    { 156, "Julia Robinson" },
                    { 157, "Chris Martin" },
                    { 158, "Emily Thomas" },
                    { 159, "Emily Taylor" },
                    { 160, "John Jackson" },
                    { 161, "Chris Davis" },
                    { 162, "Diane Miller" },
                    { 163, "Jack Taylor" },
                    { 164, "Chris Harris" },
                    { 165, "Jack Smith" },
                    { 166, "Emily Jackson" },
                    { 167, "Grace Anderson" },
                    { 168, "Claire White" },
                    { 169, "Jack Davis" },
                    { 170, "Claire Taylor" },
                    { 171, "Jack Moore" },
                    { 172, "Claire Taylor" },
                    { 173, "Dave Thompson" },
                    { 174, "Chris Harris" },
                    { 175, "Claire Smith" },
                    { 176, "Emily Martin" },
                    { 177, "Ben Smith" },
                    { 178, "Anna Smith" },
                    { 179, "John Johnson" },
                    { 180, "Beth Brown" },
                    { 181, "Ben Garcia" },
                    { 182, "Ben Williams" },
                    { 183, "Emily Thompson" },
                    { 184, "Jack Harris" },
                    { 185, "Diane Miller" },
                    { 186, "Dave Thompson" },
                    { 187, "Beth Garcia" },
                    { 188, "Anna Brown" },
                    { 189, "Anna Brown" },
                    { 190, "Ian Martin" },
                    { 191, "Jack Wilson" },
                    { 192, "Greg Davis" },
                    { 193, "Anna Thompson" },
                    { 194, "Diane Williams" },
                    { 195, "Grace Smith" },
                    { 196, "Ian Brown" },
                    { 197, "Claire Harris" },
                    { 198, "Anna Martinez" },
                    { 199, "Dave Taylor" },
                    { 200, "Beth Martin" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "appointment_time", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 31, 10, 0, 0, 0, DateTimeKind.Utc), 1, 22 },
                    { 2, new DateTime(2025, 12, 15, 8, 0, 0, 0, DateTimeKind.Utc), 2, 112 },
                    { 3, new DateTime(2024, 7, 27, 14, 0, 0, 0, DateTimeKind.Utc), 18, 74 },
                    { 4, new DateTime(2024, 2, 18, 17, 0, 0, 0, DateTimeKind.Utc), 4, 83 },
                    { 5, new DateTime(2025, 4, 21, 18, 0, 0, 0, DateTimeKind.Utc), 6, 89 },
                    { 6, new DateTime(2024, 10, 22, 8, 0, 0, 0, DateTimeKind.Utc), 9, 200 },
                    { 7, new DateTime(2025, 5, 29, 7, 0, 0, 0, DateTimeKind.Utc), 5, 133 },
                    { 8, new DateTime(2025, 2, 19, 16, 0, 0, 0, DateTimeKind.Utc), 20, 9 },
                    { 9, new DateTime(2024, 3, 27, 12, 0, 0, 0, DateTimeKind.Utc), 12, 134 },
                    { 10, new DateTime(2024, 11, 25, 8, 0, 0, 0, DateTimeKind.Utc), 3, 122 },
                    { 11, new DateTime(2025, 11, 25, 12, 0, 0, 0, DateTimeKind.Utc), 8, 105 },
                    { 12, new DateTime(2025, 10, 25, 18, 0, 0, 0, DateTimeKind.Utc), 15, 11 },
                    { 13, new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Utc), 6, 169 },
                    { 14, new DateTime(2025, 4, 27, 14, 0, 0, 0, DateTimeKind.Utc), 18, 179 },
                    { 15, new DateTime(2025, 1, 21, 8, 0, 0, 0, DateTimeKind.Utc), 8, 185 },
                    { 16, new DateTime(2024, 2, 23, 13, 0, 0, 0, DateTimeKind.Utc), 17, 29 },
                    { 17, new DateTime(2025, 10, 10, 18, 0, 0, 0, DateTimeKind.Utc), 6, 133 },
                    { 18, new DateTime(2024, 6, 16, 15, 0, 0, 0, DateTimeKind.Utc), 11, 32 },
                    { 19, new DateTime(2025, 12, 29, 8, 0, 0, 0, DateTimeKind.Utc), 13, 92 },
                    { 20, new DateTime(2024, 4, 19, 19, 0, 0, 0, DateTimeKind.Utc), 13, 133 },
                    { 21, new DateTime(2025, 5, 5, 17, 0, 0, 0, DateTimeKind.Utc), 3, 84 },
                    { 22, new DateTime(2024, 5, 12, 19, 0, 0, 0, DateTimeKind.Utc), 14, 21 },
                    { 23, new DateTime(2024, 8, 4, 16, 0, 0, 0, DateTimeKind.Utc), 6, 97 },
                    { 24, new DateTime(2024, 2, 28, 11, 0, 0, 0, DateTimeKind.Utc), 8, 67 },
                    { 25, new DateTime(2024, 5, 24, 19, 0, 0, 0, DateTimeKind.Utc), 11, 177 },
                    { 26, new DateTime(2024, 3, 22, 19, 0, 0, 0, DateTimeKind.Utc), 2, 52 },
                    { 27, new DateTime(2024, 12, 29, 16, 0, 0, 0, DateTimeKind.Utc), 11, 100 },
                    { 28, new DateTime(2024, 12, 15, 6, 0, 0, 0, DateTimeKind.Utc), 20, 175 },
                    { 29, new DateTime(2024, 11, 28, 7, 0, 0, 0, DateTimeKind.Utc), 16, 18 },
                    { 30, new DateTime(2025, 10, 11, 16, 0, 0, 0, DateTimeKind.Utc), 2, 106 },
                    { 31, new DateTime(2024, 2, 12, 6, 0, 0, 0, DateTimeKind.Utc), 12, 162 },
                    { 32, new DateTime(2025, 10, 21, 14, 0, 0, 0, DateTimeKind.Utc), 2, 176 },
                    { 33, new DateTime(2024, 10, 14, 15, 0, 0, 0, DateTimeKind.Utc), 6, 71 },
                    { 34, new DateTime(2024, 6, 15, 6, 0, 0, 0, DateTimeKind.Utc), 13, 110 },
                    { 35, new DateTime(2025, 9, 19, 19, 0, 0, 0, DateTimeKind.Utc), 13, 68 },
                    { 36, new DateTime(2025, 5, 5, 13, 0, 0, 0, DateTimeKind.Utc), 1, 119 },
                    { 37, new DateTime(2025, 4, 3, 6, 0, 0, 0, DateTimeKind.Utc), 13, 150 },
                    { 38, new DateTime(2025, 8, 28, 10, 0, 0, 0, DateTimeKind.Utc), 10, 35 },
                    { 39, new DateTime(2025, 5, 13, 15, 0, 0, 0, DateTimeKind.Utc), 13, 189 },
                    { 40, new DateTime(2024, 4, 7, 6, 0, 0, 0, DateTimeKind.Utc), 20, 71 },
                    { 41, new DateTime(2024, 6, 20, 16, 0, 0, 0, DateTimeKind.Utc), 7, 64 },
                    { 42, new DateTime(2024, 11, 19, 12, 0, 0, 0, DateTimeKind.Utc), 6, 58 },
                    { 43, new DateTime(2024, 6, 2, 16, 0, 0, 0, DateTimeKind.Utc), 13, 110 },
                    { 44, new DateTime(2025, 1, 13, 15, 0, 0, 0, DateTimeKind.Utc), 13, 138 },
                    { 45, new DateTime(2025, 3, 18, 19, 0, 0, 0, DateTimeKind.Utc), 13, 28 },
                    { 46, new DateTime(2025, 11, 23, 13, 0, 0, 0, DateTimeKind.Utc), 1, 177 },
                    { 47, new DateTime(2024, 4, 5, 12, 0, 0, 0, DateTimeKind.Utc), 14, 104 },
                    { 48, new DateTime(2024, 8, 30, 10, 0, 0, 0, DateTimeKind.Utc), 3, 120 },
                    { 49, new DateTime(2024, 2, 14, 13, 0, 0, 0, DateTimeKind.Utc), 1, 54 },
                    { 50, new DateTime(2024, 7, 2, 11, 0, 0, 0, DateTimeKind.Utc), 11, 31 },
                    { 51, new DateTime(2024, 9, 11, 6, 0, 0, 0, DateTimeKind.Utc), 12, 139 },
                    { 52, new DateTime(2025, 12, 21, 13, 0, 0, 0, DateTimeKind.Utc), 7, 194 },
                    { 53, new DateTime(2024, 10, 7, 14, 0, 0, 0, DateTimeKind.Utc), 12, 155 },
                    { 54, new DateTime(2024, 3, 7, 6, 0, 0, 0, DateTimeKind.Utc), 7, 98 },
                    { 55, new DateTime(2025, 12, 6, 19, 0, 0, 0, DateTimeKind.Utc), 13, 185 },
                    { 56, new DateTime(2025, 1, 5, 15, 0, 0, 0, DateTimeKind.Utc), 18, 142 },
                    { 57, new DateTime(2024, 7, 7, 11, 0, 0, 0, DateTimeKind.Utc), 2, 168 },
                    { 58, new DateTime(2024, 11, 27, 17, 0, 0, 0, DateTimeKind.Utc), 20, 172 },
                    { 59, new DateTime(2025, 7, 26, 8, 0, 0, 0, DateTimeKind.Utc), 15, 136 },
                    { 60, new DateTime(2025, 6, 29, 10, 0, 0, 0, DateTimeKind.Utc), 6, 121 },
                    { 61, new DateTime(2024, 1, 26, 13, 0, 0, 0, DateTimeKind.Utc), 8, 168 },
                    { 62, new DateTime(2024, 9, 29, 16, 0, 0, 0, DateTimeKind.Utc), 10, 159 },
                    { 63, new DateTime(2025, 7, 24, 9, 0, 0, 0, DateTimeKind.Utc), 12, 96 },
                    { 64, new DateTime(2024, 5, 25, 17, 0, 0, 0, DateTimeKind.Utc), 1, 198 },
                    { 65, new DateTime(2024, 5, 3, 10, 0, 0, 0, DateTimeKind.Utc), 1, 161 },
                    { 66, new DateTime(2024, 4, 11, 19, 0, 0, 0, DateTimeKind.Utc), 8, 83 },
                    { 67, new DateTime(2025, 11, 16, 19, 0, 0, 0, DateTimeKind.Utc), 7, 140 },
                    { 68, new DateTime(2025, 7, 5, 16, 0, 0, 0, DateTimeKind.Utc), 9, 125 },
                    { 69, new DateTime(2025, 4, 2, 12, 0, 0, 0, DateTimeKind.Utc), 16, 123 },
                    { 70, new DateTime(2024, 5, 24, 15, 0, 0, 0, DateTimeKind.Utc), 3, 5 },
                    { 71, new DateTime(2024, 2, 12, 16, 0, 0, 0, DateTimeKind.Utc), 6, 27 },
                    { 72, new DateTime(2024, 3, 29, 15, 0, 0, 0, DateTimeKind.Utc), 12, 114 },
                    { 73, new DateTime(2024, 7, 2, 19, 0, 0, 0, DateTimeKind.Utc), 6, 111 },
                    { 74, new DateTime(2025, 8, 24, 15, 0, 0, 0, DateTimeKind.Utc), 13, 26 },
                    { 75, new DateTime(2024, 4, 4, 11, 0, 0, 0, DateTimeKind.Utc), 15, 45 },
                    { 76, new DateTime(2025, 7, 21, 9, 0, 0, 0, DateTimeKind.Utc), 13, 146 },
                    { 77, new DateTime(2025, 9, 23, 15, 0, 0, 0, DateTimeKind.Utc), 3, 7 },
                    { 78, new DateTime(2024, 12, 13, 10, 0, 0, 0, DateTimeKind.Utc), 7, 197 },
                    { 79, new DateTime(2024, 8, 11, 10, 0, 0, 0, DateTimeKind.Utc), 20, 5 },
                    { 80, new DateTime(2024, 9, 26, 10, 0, 0, 0, DateTimeKind.Utc), 7, 3 },
                    { 81, new DateTime(2025, 1, 24, 14, 0, 0, 0, DateTimeKind.Utc), 19, 57 },
                    { 82, new DateTime(2024, 7, 9, 12, 0, 0, 0, DateTimeKind.Utc), 10, 78 },
                    { 83, new DateTime(2024, 2, 2, 8, 0, 0, 0, DateTimeKind.Utc), 15, 80 },
                    { 84, new DateTime(2025, 9, 5, 13, 0, 0, 0, DateTimeKind.Utc), 10, 40 },
                    { 85, new DateTime(2024, 3, 21, 16, 0, 0, 0, DateTimeKind.Utc), 19, 64 },
                    { 86, new DateTime(2024, 11, 19, 16, 0, 0, 0, DateTimeKind.Utc), 6, 176 },
                    { 87, new DateTime(2024, 2, 16, 10, 0, 0, 0, DateTimeKind.Utc), 17, 137 },
                    { 88, new DateTime(2024, 1, 30, 14, 0, 0, 0, DateTimeKind.Utc), 15, 90 },
                    { 89, new DateTime(2025, 9, 6, 11, 0, 0, 0, DateTimeKind.Utc), 8, 125 },
                    { 90, new DateTime(2024, 4, 1, 7, 0, 0, 0, DateTimeKind.Utc), 16, 178 },
                    { 91, new DateTime(2024, 11, 28, 6, 0, 0, 0, DateTimeKind.Utc), 10, 95 },
                    { 92, new DateTime(2025, 9, 21, 11, 0, 0, 0, DateTimeKind.Utc), 12, 199 },
                    { 93, new DateTime(2025, 5, 22, 8, 0, 0, 0, DateTimeKind.Utc), 10, 196 },
                    { 94, new DateTime(2024, 6, 13, 6, 0, 0, 0, DateTimeKind.Utc), 17, 122 },
                    { 95, new DateTime(2025, 1, 25, 7, 0, 0, 0, DateTimeKind.Utc), 18, 198 },
                    { 96, new DateTime(2025, 5, 29, 11, 0, 0, 0, DateTimeKind.Utc), 17, 2 },
                    { 97, new DateTime(2025, 9, 15, 13, 0, 0, 0, DateTimeKind.Utc), 3, 12 },
                    { 98, new DateTime(2024, 12, 25, 18, 0, 0, 0, DateTimeKind.Utc), 9, 93 },
                    { 99, new DateTime(2025, 6, 6, 6, 0, 0, 0, DateTimeKind.Utc), 15, 185 },
                    { 100, new DateTime(2025, 9, 2, 8, 0, 0, 0, DateTimeKind.Utc), 14, 103 }
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
