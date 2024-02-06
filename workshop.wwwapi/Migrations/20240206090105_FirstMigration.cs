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
                    { 1, "Dr. Felicity Chocofix" },
                    { 2, "Doc. Nathaniel Sodamore" },
                    { 3, "Prof. Dr. Harrison Snackright" },
                    { 4, "M.D. Josephine Snackmore" },
                    { 5, "Dr. Sebastian Colagood" },
                    { 6, "Doc. Quentin Jones" },
                    { 7, "Doc. Henrietta Snackwell" },
                    { 8, "Dr. Daphne Sugarlove" },
                    { 9, "Professor Charles Sugarlove" },
                    { 10, "Master Dr. Julian Sodamore" },
                    { 11, "Prof. Dr. Indiana Jones" },
                    { 12, "PhD Dr. Julian Sodamore" },
                    { 13, "Doc. Sebastian Chocofix" },
                    { 14, "Prof. Dr. Isabella Candygood" },
                    { 15, "Doc. Ophelia Morecola" },
                    { 16, "Specialist Henrietta Snackgood" },
                    { 17, "Professor Anastasia Jones" },
                    { 18, "PhD Dr. Daphne Chocomore" },
                    { 19, "M.D. Alexander Snackwell" },
                    { 20, "Dr. Montgomery Eatmore" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Beth Williams" },
                    { 2, "Chris Moore" },
                    { 3, "Dave White" },
                    { 4, "Dave Thomas" },
                    { 5, "Grace Harris" },
                    { 6, "Ben Garcia" },
                    { 7, "Chris Brown" },
                    { 8, "Anna White" },
                    { 9, "Emily Taylor" },
                    { 10, "Emily Davis" },
                    { 11, "Diane White" },
                    { 12, "Chris Williams" },
                    { 13, "Claire Smith" },
                    { 14, "Jack Johnson" },
                    { 15, "Grace Williams" },
                    { 16, "Claire Harris" },
                    { 17, "Greg Williams" },
                    { 18, "Grace Garcia" },
                    { 19, "Claire Brown" },
                    { 20, "Ben Martin" },
                    { 21, "Grace Johnson" },
                    { 22, "Grace Williams" },
                    { 23, "Ian Davis" },
                    { 24, "Ben Williams" },
                    { 25, "Frank Martinez" },
                    { 26, "Grace Martin" },
                    { 27, "Frank Harris" },
                    { 28, "Claire Taylor" },
                    { 29, "Dave Thomas" },
                    { 30, "Ian Anderson" },
                    { 31, "Grace Robinson" },
                    { 32, "Grace Thompson" },
                    { 33, "Anna Smith" },
                    { 34, "Chris Davis" },
                    { 35, "John Martinez" },
                    { 36, "Emily Taylor" },
                    { 37, "Ben Davis" },
                    { 38, "Frank Williams" },
                    { 39, "Anna Thomas" },
                    { 40, "Jack Miller" },
                    { 41, "Frank Anderson" },
                    { 42, "Jack Davis" },
                    { 43, "Frank Taylor" },
                    { 44, "Grace Johnson" },
                    { 45, "Julia Garcia" },
                    { 46, "Chris Robinson" },
                    { 47, "Greg Harris" },
                    { 48, "Grace Brown" },
                    { 49, "Julia Johnson" },
                    { 50, "Chris Martin" },
                    { 51, "Emily Davis" },
                    { 52, "Ian Anderson" },
                    { 53, "Ben Davis" },
                    { 54, "Claire Smith" },
                    { 55, "Jack Johnson" },
                    { 56, "Julia Brown" },
                    { 57, "Ben Smith" },
                    { 58, "Julia White" },
                    { 59, "Greg Anderson" },
                    { 60, "Emily Davis" },
                    { 61, "Chris Smith" },
                    { 62, "John Wilson" },
                    { 63, "Ben Jackson" },
                    { 64, "Dave Robinson" },
                    { 65, "Greg Davis" },
                    { 66, "Dave White" },
                    { 67, "John Anderson" },
                    { 68, "Jack Miller" },
                    { 69, "Frank Moore" },
                    { 70, "Claire Martinez" },
                    { 71, "Ian Martin" },
                    { 72, "Julia Jackson" },
                    { 73, "Claire Martin" },
                    { 74, "Emily Davis" },
                    { 75, "Ben Thomas" },
                    { 76, "Dave Jackson" },
                    { 77, "Julia Johnson" },
                    { 78, "Diane Thompson" },
                    { 79, "Emily Brown" },
                    { 80, "Chris Garcia" },
                    { 81, "Claire White" },
                    { 82, "Jack Johnson" },
                    { 83, "Anna Martinez" },
                    { 84, "John Smith" },
                    { 85, "Dave Martinez" },
                    { 86, "Emily Smith" },
                    { 87, "Emily Miller" },
                    { 88, "Ben Robinson" },
                    { 89, "Claire Taylor" },
                    { 90, "Claire White" },
                    { 91, "John Anderson" },
                    { 92, "Claire White" },
                    { 93, "Frank Anderson" },
                    { 94, "Chris Moore" },
                    { 95, "Diane Miller" },
                    { 96, "John Smith" },
                    { 97, "Diane Thompson" },
                    { 98, "Jack Brown" },
                    { 99, "Jack Williams" },
                    { 100, "Grace Thomas" },
                    { 101, "Emily Garcia" },
                    { 102, "Claire Robinson" },
                    { 103, "Grace Anderson" },
                    { 104, "Ben Smith" },
                    { 105, "Grace Thompson" },
                    { 106, "Anna Thompson" },
                    { 107, "Jack Miller" },
                    { 108, "Jack Davis" },
                    { 109, "Julia Williams" },
                    { 110, "John Miller" },
                    { 111, "Julia Martin" },
                    { 112, "Grace Thompson" },
                    { 113, "Grace Johnson" },
                    { 114, "Emily Williams" },
                    { 115, "Grace Williams" },
                    { 116, "John Garcia" },
                    { 117, "Jack Moore" },
                    { 118, "Frank Garcia" },
                    { 119, "Chris Taylor" },
                    { 120, "Grace Moore" },
                    { 121, "Julia Smith" },
                    { 122, "Emily Smith" },
                    { 123, "Claire Davis" },
                    { 124, "Julia Wilson" },
                    { 125, "Jack Brown" },
                    { 126, "Diane Davis" },
                    { 127, "Jack Jackson" },
                    { 128, "Grace Jackson" },
                    { 129, "John Miller" },
                    { 130, "Ian Garcia" },
                    { 131, "Greg Jackson" },
                    { 132, "Anna Harris" },
                    { 133, "Jack Moore" },
                    { 134, "Chris Thompson" },
                    { 135, "Diane Davis" },
                    { 136, "Julia Jackson" },
                    { 137, "Dave Moore" },
                    { 138, "Ben White" },
                    { 139, "Chris White" },
                    { 140, "Jack Jackson" },
                    { 141, "Ian Robinson" },
                    { 142, "Dave Anderson" },
                    { 143, "Julia Smith" },
                    { 144, "Dave Anderson" },
                    { 145, "Ian Taylor" },
                    { 146, "Dave Johnson" },
                    { 147, "Ben Anderson" },
                    { 148, "Diane Harris" },
                    { 149, "Chris Garcia" },
                    { 150, "Diane Martin" },
                    { 151, "Frank Davis" },
                    { 152, "Grace Robinson" },
                    { 153, "Emily Garcia" },
                    { 154, "Emily White" },
                    { 155, "Julia Miller" },
                    { 156, "John Harris" },
                    { 157, "Claire Brown" },
                    { 158, "Ben Anderson" },
                    { 159, "Dave Martin" },
                    { 160, "Jack Martinez" },
                    { 161, "Anna Robinson" },
                    { 162, "Claire Harris" },
                    { 163, "Chris Martinez" },
                    { 164, "Jack Harris" },
                    { 165, "Chris Garcia" },
                    { 166, "Diane Jackson" },
                    { 167, "Claire Taylor" },
                    { 168, "Grace Thompson" },
                    { 169, "Beth White" },
                    { 170, "Claire White" },
                    { 171, "Jack Taylor" },
                    { 172, "Julia Brown" },
                    { 173, "Ian Johnson" },
                    { 174, "Ben Brown" },
                    { 175, "Ben Harris" },
                    { 176, "Diane Robinson" },
                    { 177, "Greg Brown" },
                    { 178, "Jack White" },
                    { 179, "Ben Garcia" },
                    { 180, "Beth Thomas" },
                    { 181, "Ben Johnson" },
                    { 182, "John Brown" },
                    { 183, "Dave Smith" },
                    { 184, "Greg Martinez" },
                    { 185, "Beth Martinez" },
                    { 186, "Ben White" },
                    { 187, "Greg Thomas" },
                    { 188, "Beth Johnson" },
                    { 189, "Jack Thomas" },
                    { 190, "Jack Williams" },
                    { 191, "John Harris" },
                    { 192, "Chris Harris" },
                    { 193, "Chris Garcia" },
                    { 194, "Beth Moore" },
                    { 195, "Diane Wilson" },
                    { 196, "Chris White" },
                    { 197, "John Jackson" },
                    { 198, "Ian Robinson" },
                    { 199, "Emily Moore" },
                    { 200, "Chris Robinson" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "appointment_time", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 30, 9, 0, 0, 0, DateTimeKind.Utc), 15, 91 },
                    { 2, new DateTime(2025, 12, 6, 14, 0, 0, 0, DateTimeKind.Utc), 10, 93 },
                    { 3, new DateTime(2025, 3, 10, 10, 0, 0, 0, DateTimeKind.Utc), 9, 149 },
                    { 4, new DateTime(2024, 3, 18, 11, 0, 0, 0, DateTimeKind.Utc), 16, 18 },
                    { 5, new DateTime(2025, 5, 18, 7, 0, 0, 0, DateTimeKind.Utc), 8, 80 },
                    { 6, new DateTime(2024, 12, 7, 10, 0, 0, 0, DateTimeKind.Utc), 14, 85 },
                    { 7, new DateTime(2025, 4, 25, 15, 0, 0, 0, DateTimeKind.Utc), 2, 82 },
                    { 8, new DateTime(2025, 10, 25, 18, 0, 0, 0, DateTimeKind.Utc), 1, 36 },
                    { 9, new DateTime(2024, 7, 8, 8, 0, 0, 0, DateTimeKind.Utc), 3, 141 },
                    { 10, new DateTime(2025, 12, 8, 12, 0, 0, 0, DateTimeKind.Utc), 12, 106 },
                    { 11, new DateTime(2024, 5, 26, 19, 0, 0, 0, DateTimeKind.Utc), 2, 134 },
                    { 12, new DateTime(2025, 10, 28, 8, 0, 0, 0, DateTimeKind.Utc), 13, 133 },
                    { 13, new DateTime(2024, 4, 6, 12, 0, 0, 0, DateTimeKind.Utc), 4, 90 },
                    { 14, new DateTime(2024, 11, 11, 15, 0, 0, 0, DateTimeKind.Utc), 5, 71 },
                    { 15, new DateTime(2025, 1, 26, 8, 0, 0, 0, DateTimeKind.Utc), 18, 37 },
                    { 16, new DateTime(2024, 1, 25, 18, 0, 0, 0, DateTimeKind.Utc), 9, 170 },
                    { 17, new DateTime(2025, 1, 4, 17, 0, 0, 0, DateTimeKind.Utc), 2, 198 },
                    { 18, new DateTime(2025, 3, 26, 11, 0, 0, 0, DateTimeKind.Utc), 15, 9 },
                    { 19, new DateTime(2025, 8, 16, 17, 0, 0, 0, DateTimeKind.Utc), 20, 110 },
                    { 20, new DateTime(2025, 5, 23, 19, 0, 0, 0, DateTimeKind.Utc), 12, 30 },
                    { 21, new DateTime(2024, 5, 23, 17, 0, 0, 0, DateTimeKind.Utc), 1, 160 },
                    { 22, new DateTime(2024, 7, 17, 11, 0, 0, 0, DateTimeKind.Utc), 19, 25 },
                    { 23, new DateTime(2024, 11, 28, 14, 0, 0, 0, DateTimeKind.Utc), 19, 50 },
                    { 24, new DateTime(2024, 5, 22, 14, 0, 0, 0, DateTimeKind.Utc), 16, 7 },
                    { 25, new DateTime(2025, 5, 29, 10, 0, 0, 0, DateTimeKind.Utc), 2, 151 },
                    { 26, new DateTime(2024, 1, 29, 12, 0, 0, 0, DateTimeKind.Utc), 18, 1 },
                    { 27, new DateTime(2024, 2, 27, 10, 0, 0, 0, DateTimeKind.Utc), 6, 149 },
                    { 28, new DateTime(2025, 11, 24, 9, 0, 0, 0, DateTimeKind.Utc), 11, 177 },
                    { 29, new DateTime(2024, 3, 24, 19, 0, 0, 0, DateTimeKind.Utc), 20, 27 },
                    { 30, new DateTime(2024, 11, 2, 15, 0, 0, 0, DateTimeKind.Utc), 14, 95 },
                    { 31, new DateTime(2024, 11, 17, 14, 0, 0, 0, DateTimeKind.Utc), 7, 50 },
                    { 32, new DateTime(2025, 9, 27, 14, 0, 0, 0, DateTimeKind.Utc), 6, 15 },
                    { 33, new DateTime(2025, 8, 10, 11, 0, 0, 0, DateTimeKind.Utc), 10, 190 },
                    { 34, new DateTime(2024, 8, 25, 7, 0, 0, 0, DateTimeKind.Utc), 7, 83 },
                    { 35, new DateTime(2024, 12, 28, 19, 0, 0, 0, DateTimeKind.Utc), 13, 63 },
                    { 36, new DateTime(2024, 10, 28, 18, 0, 0, 0, DateTimeKind.Utc), 4, 160 },
                    { 37, new DateTime(2024, 11, 16, 7, 0, 0, 0, DateTimeKind.Utc), 20, 100 },
                    { 38, new DateTime(2024, 2, 12, 11, 0, 0, 0, DateTimeKind.Utc), 10, 78 },
                    { 39, new DateTime(2025, 7, 30, 16, 0, 0, 0, DateTimeKind.Utc), 14, 168 },
                    { 40, new DateTime(2024, 5, 18, 6, 0, 0, 0, DateTimeKind.Utc), 9, 99 },
                    { 41, new DateTime(2025, 7, 11, 16, 0, 0, 0, DateTimeKind.Utc), 2, 29 },
                    { 42, new DateTime(2024, 10, 8, 10, 0, 0, 0, DateTimeKind.Utc), 6, 103 },
                    { 43, new DateTime(2025, 3, 7, 15, 0, 0, 0, DateTimeKind.Utc), 15, 96 },
                    { 44, new DateTime(2025, 3, 18, 6, 0, 0, 0, DateTimeKind.Utc), 12, 54 },
                    { 45, new DateTime(2024, 12, 12, 8, 0, 0, 0, DateTimeKind.Utc), 14, 192 },
                    { 46, new DateTime(2024, 7, 25, 18, 0, 0, 0, DateTimeKind.Utc), 1, 166 },
                    { 47, new DateTime(2025, 4, 15, 12, 0, 0, 0, DateTimeKind.Utc), 16, 41 },
                    { 48, new DateTime(2025, 5, 12, 7, 0, 0, 0, DateTimeKind.Utc), 12, 48 },
                    { 49, new DateTime(2024, 4, 9, 19, 0, 0, 0, DateTimeKind.Utc), 13, 156 },
                    { 50, new DateTime(2024, 1, 30, 12, 0, 0, 0, DateTimeKind.Utc), 8, 126 },
                    { 51, new DateTime(2024, 2, 18, 18, 0, 0, 0, DateTimeKind.Utc), 10, 106 },
                    { 52, new DateTime(2025, 3, 17, 6, 0, 0, 0, DateTimeKind.Utc), 18, 165 },
                    { 53, new DateTime(2024, 11, 24, 6, 0, 0, 0, DateTimeKind.Utc), 1, 200 },
                    { 54, new DateTime(2024, 3, 6, 6, 0, 0, 0, DateTimeKind.Utc), 7, 122 },
                    { 55, new DateTime(2024, 3, 28, 8, 0, 0, 0, DateTimeKind.Utc), 8, 179 },
                    { 56, new DateTime(2024, 11, 9, 13, 0, 0, 0, DateTimeKind.Utc), 1, 27 },
                    { 57, new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Utc), 17, 131 },
                    { 58, new DateTime(2025, 11, 8, 9, 0, 0, 0, DateTimeKind.Utc), 15, 148 },
                    { 59, new DateTime(2024, 12, 7, 17, 0, 0, 0, DateTimeKind.Utc), 14, 110 },
                    { 60, new DateTime(2025, 8, 9, 16, 0, 0, 0, DateTimeKind.Utc), 5, 183 },
                    { 61, new DateTime(2025, 4, 23, 14, 0, 0, 0, DateTimeKind.Utc), 1, 138 },
                    { 62, new DateTime(2024, 12, 27, 13, 0, 0, 0, DateTimeKind.Utc), 15, 122 },
                    { 63, new DateTime(2024, 1, 9, 18, 0, 0, 0, DateTimeKind.Utc), 12, 124 },
                    { 64, new DateTime(2024, 2, 24, 9, 0, 0, 0, DateTimeKind.Utc), 7, 60 },
                    { 65, new DateTime(2024, 1, 13, 8, 0, 0, 0, DateTimeKind.Utc), 13, 105 },
                    { 66, new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc), 8, 111 },
                    { 67, new DateTime(2024, 7, 26, 18, 0, 0, 0, DateTimeKind.Utc), 15, 115 },
                    { 68, new DateTime(2025, 10, 12, 11, 0, 0, 0, DateTimeKind.Utc), 11, 63 },
                    { 69, new DateTime(2024, 1, 19, 7, 0, 0, 0, DateTimeKind.Utc), 3, 76 },
                    { 70, new DateTime(2025, 4, 30, 14, 0, 0, 0, DateTimeKind.Utc), 17, 79 },
                    { 71, new DateTime(2024, 7, 25, 13, 0, 0, 0, DateTimeKind.Utc), 13, 149 },
                    { 72, new DateTime(2024, 8, 13, 15, 0, 0, 0, DateTimeKind.Utc), 9, 121 },
                    { 73, new DateTime(2025, 2, 11, 18, 0, 0, 0, DateTimeKind.Utc), 7, 20 },
                    { 74, new DateTime(2025, 6, 3, 17, 0, 0, 0, DateTimeKind.Utc), 11, 146 },
                    { 75, new DateTime(2025, 10, 7, 10, 0, 0, 0, DateTimeKind.Utc), 14, 70 },
                    { 76, new DateTime(2024, 3, 21, 9, 0, 0, 0, DateTimeKind.Utc), 15, 82 },
                    { 77, new DateTime(2024, 2, 23, 16, 0, 0, 0, DateTimeKind.Utc), 9, 61 },
                    { 78, new DateTime(2024, 4, 22, 8, 0, 0, 0, DateTimeKind.Utc), 6, 138 },
                    { 79, new DateTime(2025, 9, 28, 14, 0, 0, 0, DateTimeKind.Utc), 18, 190 },
                    { 80, new DateTime(2025, 2, 7, 16, 0, 0, 0, DateTimeKind.Utc), 11, 117 },
                    { 81, new DateTime(2025, 4, 22, 14, 0, 0, 0, DateTimeKind.Utc), 4, 124 },
                    { 82, new DateTime(2025, 6, 21, 11, 0, 0, 0, DateTimeKind.Utc), 5, 185 },
                    { 83, new DateTime(2025, 1, 10, 6, 0, 0, 0, DateTimeKind.Utc), 19, 57 },
                    { 84, new DateTime(2024, 7, 31, 17, 0, 0, 0, DateTimeKind.Utc), 15, 183 },
                    { 85, new DateTime(2024, 3, 26, 13, 0, 0, 0, DateTimeKind.Utc), 7, 21 },
                    { 86, new DateTime(2025, 6, 24, 12, 0, 0, 0, DateTimeKind.Utc), 9, 183 },
                    { 87, new DateTime(2025, 4, 28, 16, 0, 0, 0, DateTimeKind.Utc), 5, 190 },
                    { 88, new DateTime(2024, 6, 14, 15, 0, 0, 0, DateTimeKind.Utc), 8, 167 },
                    { 89, new DateTime(2025, 2, 23, 6, 0, 0, 0, DateTimeKind.Utc), 6, 65 },
                    { 90, new DateTime(2024, 4, 26, 12, 0, 0, 0, DateTimeKind.Utc), 19, 148 },
                    { 91, new DateTime(2025, 11, 16, 14, 0, 0, 0, DateTimeKind.Utc), 3, 22 },
                    { 92, new DateTime(2024, 3, 19, 15, 0, 0, 0, DateTimeKind.Utc), 17, 90 },
                    { 93, new DateTime(2025, 9, 22, 17, 0, 0, 0, DateTimeKind.Utc), 12, 174 },
                    { 94, new DateTime(2025, 3, 7, 14, 0, 0, 0, DateTimeKind.Utc), 16, 164 },
                    { 95, new DateTime(2024, 3, 27, 11, 0, 0, 0, DateTimeKind.Utc), 5, 168 },
                    { 96, new DateTime(2025, 7, 12, 11, 0, 0, 0, DateTimeKind.Utc), 6, 177 },
                    { 97, new DateTime(2024, 7, 21, 15, 0, 0, 0, DateTimeKind.Utc), 4, 99 },
                    { 98, new DateTime(2025, 9, 25, 9, 0, 0, 0, DateTimeKind.Utc), 18, 73 },
                    { 99, new DateTime(2024, 2, 20, 19, 0, 0, 0, DateTimeKind.Utc), 20, 66 },
                    { 100, new DateTime(2025, 8, 30, 17, 0, 0, 0, DateTimeKind.Utc), 11, 7 }
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
