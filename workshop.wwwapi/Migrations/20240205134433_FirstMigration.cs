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
                    { 1, "Supreme Dr. Charlotte Archibald-Wellesley" },
                    { 2, "Prof. Dr. Genevieve Ravenswood-Grantham" },
                    { 3, "Supreme Dr. Daphne Kensington-Rowe" },
                    { 4, "Doc. Penelope Huntington-Whitely" },
                    { 5, "Doctor Penelope Fitzroy-Davenport" },
                    { 6, "Prof. Dr. Xavier Fairbanks-Crowley" },
                    { 7, "Prof. Dr. Edmund Montague-Smythe" },
                    { 8, "Supreme Dr. Ophelia Hawthorne-Devereux" },
                    { 9, "Doc. Dorian Derbyshire-Langford" },
                    { 10, "Doc. Josephine Wentworth-Fitzwilliam" },
                    { 11, "Doctor Charles Derbyshire-Langford" },
                    { 12, "Dr. Charles Sterling-Goldsmith" },
                    { 13, "Doctor Julian Vanderbilt-Astor" },
                    { 14, "Supreme Dr. Dorian Huntington-Whitely" },
                    { 15, "Professor Charlotte Archibald-Wellesley" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Chris Williams" },
                    { 2, "Ben Martin" },
                    { 3, "Ben Davis" },
                    { 4, "Diane Garcia" },
                    { 5, "Jack Brown" },
                    { 6, "Claire Davis" },
                    { 7, "Claire Brown" },
                    { 8, "Dave Thompson" },
                    { 9, "Diane Taylor" },
                    { 10, "Emily Johnson" },
                    { 11, "Ben Smith" },
                    { 12, "Anna Thompson" },
                    { 13, "Ian Miller" },
                    { 14, "Greg Williams" },
                    { 15, "Ian Davis" },
                    { 16, "Frank Davis" },
                    { 17, "Anna Martin" },
                    { 18, "Claire Davis" },
                    { 19, "Anna Thomas" },
                    { 20, "Dave Smith" },
                    { 21, "Greg Robinson" },
                    { 22, "Diane Smith" },
                    { 23, "John Wilson" },
                    { 24, "Dave Thomas" },
                    { 25, "Anna Smith" },
                    { 26, "Chris Williams" },
                    { 27, "Frank Wilson" },
                    { 28, "Julia Anderson" },
                    { 29, "John Davis" },
                    { 30, "Beth Anderson" },
                    { 31, "Grace Miller" },
                    { 32, "Chris Moore" },
                    { 33, "John Davis" },
                    { 34, "Chris Brown" },
                    { 35, "Ian Jackson" },
                    { 36, "Ben Miller" },
                    { 37, "Beth Martinez" },
                    { 38, "Ian Thompson" },
                    { 39, "Jack Moore" },
                    { 40, "Jack Garcia" },
                    { 41, "Frank Garcia" },
                    { 42, "Anna Thompson" },
                    { 43, "Beth Garcia" },
                    { 44, "Greg Thomas" },
                    { 45, "Julia Jackson" },
                    { 46, "Dave Taylor" },
                    { 47, "Chris Wilson" },
                    { 48, "Diane Brown" },
                    { 49, "Chris Thompson" },
                    { 50, "Anna Davis" },
                    { 51, "Beth White" },
                    { 52, "John Thompson" },
                    { 53, "Grace Harris" },
                    { 54, "Emily Taylor" },
                    { 55, "Ben Harris" },
                    { 56, "Dave Garcia" },
                    { 57, "Chris White" },
                    { 58, "Jack Johnson" },
                    { 59, "Greg Martin" },
                    { 60, "Frank Johnson" },
                    { 61, "Beth Miller" },
                    { 62, "Frank Davis" },
                    { 63, "Frank Garcia" },
                    { 64, "Greg Robinson" },
                    { 65, "Frank Taylor" },
                    { 66, "Chris Smith" },
                    { 67, "Ben Garcia" },
                    { 68, "Diane White" },
                    { 69, "Anna Johnson" },
                    { 70, "Grace Moore" },
                    { 71, "Frank Wilson" },
                    { 72, "Ian Thompson" },
                    { 73, "Greg Smith" },
                    { 74, "Anna White" },
                    { 75, "Diane Johnson" },
                    { 76, "Grace Taylor" },
                    { 77, "Claire Taylor" },
                    { 78, "Anna Wilson" },
                    { 79, "Julia Miller" },
                    { 80, "Ben Martinez" },
                    { 81, "Frank Smith" },
                    { 82, "Julia Taylor" },
                    { 83, "Julia Jackson" },
                    { 84, "Dave Moore" },
                    { 85, "Chris Miller" },
                    { 86, "Chris Davis" },
                    { 87, "Diane Jackson" },
                    { 88, "Emily Williams" },
                    { 89, "Dave Davis" },
                    { 90, "Diane Brown" },
                    { 91, "Emily Moore" },
                    { 92, "Chris Thomas" },
                    { 93, "Claire Anderson" },
                    { 94, "Ben Garcia" },
                    { 95, "Emily Harris" },
                    { 96, "Beth Johnson" },
                    { 97, "Anna Miller" },
                    { 98, "Greg Taylor" },
                    { 99, "Greg Wilson" },
                    { 100, "Dave Miller" },
                    { 101, "Emily Martinez" },
                    { 102, "Julia Moore" },
                    { 103, "Chris Anderson" },
                    { 104, "Ian Thompson" },
                    { 105, "Chris White" },
                    { 106, "Grace Moore" },
                    { 107, "Ben Williams" },
                    { 108, "Anna Garcia" },
                    { 109, "Anna Thompson" },
                    { 110, "Greg Moore" },
                    { 111, "Julia Garcia" },
                    { 112, "Jack Smith" },
                    { 113, "Emily Davis" },
                    { 114, "Chris Smith" },
                    { 115, "Chris Anderson" },
                    { 116, "Frank Martin" },
                    { 117, "Emily Davis" },
                    { 118, "Greg Wilson" },
                    { 119, "Claire Davis" },
                    { 120, "Grace Garcia" },
                    { 121, "Dave Garcia" },
                    { 122, "Ian White" },
                    { 123, "Grace Thompson" },
                    { 124, "Diane Moore" },
                    { 125, "Diane Martinez" },
                    { 126, "John Miller" },
                    { 127, "Emily Martinez" },
                    { 128, "Claire White" },
                    { 129, "Beth Thompson" },
                    { 130, "Diane Martin" },
                    { 131, "Jack Brown" },
                    { 132, "Beth Smith" },
                    { 133, "Julia Anderson" },
                    { 134, "Anna Thompson" },
                    { 135, "John Garcia" },
                    { 136, "Julia Miller" },
                    { 137, "Anna Wilson" },
                    { 138, "Greg Wilson" },
                    { 139, "John Smith" },
                    { 140, "Dave Johnson" },
                    { 141, "Anna Harris" },
                    { 142, "Chris Jackson" },
                    { 143, "Dave Martin" },
                    { 144, "Anna Thompson" },
                    { 145, "Greg White" },
                    { 146, "Chris Williams" },
                    { 147, "Jack Jackson" },
                    { 148, "Anna Moore" },
                    { 149, "Claire Davis" },
                    { 150, "Dave Jackson" },
                    { 151, "Beth Moore" },
                    { 152, "Dave Smith" },
                    { 153, "Grace Thomas" },
                    { 154, "Claire Martin" },
                    { 155, "Emily Brown" },
                    { 156, "Anna Robinson" },
                    { 157, "Frank Brown" },
                    { 158, "Chris Williams" },
                    { 159, "Dave Smith" },
                    { 160, "Jack Taylor" },
                    { 161, "Ben Moore" },
                    { 162, "Beth Martinez" },
                    { 163, "Dave Davis" },
                    { 164, "Claire Thompson" },
                    { 165, "Beth Martinez" },
                    { 166, "Jack Thomas" },
                    { 167, "Dave Davis" },
                    { 168, "Beth Jackson" },
                    { 169, "Dave Williams" },
                    { 170, "Diane Johnson" },
                    { 171, "Greg Taylor" },
                    { 172, "Emily Jackson" },
                    { 173, "Beth Brown" },
                    { 174, "John Wilson" },
                    { 175, "Emily Anderson" },
                    { 176, "Ben Taylor" },
                    { 177, "Chris Anderson" },
                    { 178, "Ian Smith" },
                    { 179, "Jack Smith" },
                    { 180, "Claire Moore" },
                    { 181, "Ian Harris" },
                    { 182, "Anna White" },
                    { 183, "Claire Garcia" },
                    { 184, "Ian Taylor" },
                    { 185, "John Martin" },
                    { 186, "Dave Wilson" },
                    { 187, "Beth Anderson" },
                    { 188, "Grace Miller" },
                    { 189, "Diane Moore" },
                    { 190, "Grace Taylor" },
                    { 191, "Beth Thomas" },
                    { 192, "Ian Anderson" },
                    { 193, "John Thompson" },
                    { 194, "Claire Brown" },
                    { 195, "Julia Martinez" },
                    { 196, "Diane Thompson" },
                    { 197, "Beth Jackson" },
                    { 198, "Frank Smith" },
                    { 199, "Julia Brown" },
                    { 200, "Diane Miller" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "appointment_time", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 23, 6, 0, 0, 0, DateTimeKind.Utc), 7, 99 },
                    { 2, new DateTime(2025, 5, 14, 10, 0, 0, 0, DateTimeKind.Utc), 14, 2 },
                    { 3, new DateTime(2025, 12, 1, 19, 0, 0, 0, DateTimeKind.Utc), 14, 183 },
                    { 4, new DateTime(2025, 2, 14, 12, 0, 0, 0, DateTimeKind.Utc), 12, 134 },
                    { 5, new DateTime(2024, 6, 23, 16, 0, 0, 0, DateTimeKind.Utc), 13, 10 },
                    { 6, new DateTime(2024, 9, 22, 15, 0, 0, 0, DateTimeKind.Utc), 9, 56 },
                    { 7, new DateTime(2025, 9, 11, 7, 0, 0, 0, DateTimeKind.Utc), 10, 132 },
                    { 8, new DateTime(2025, 1, 12, 8, 0, 0, 0, DateTimeKind.Utc), 8, 184 },
                    { 9, new DateTime(2024, 1, 18, 10, 0, 0, 0, DateTimeKind.Utc), 2, 18 },
                    { 10, new DateTime(2024, 8, 23, 9, 0, 0, 0, DateTimeKind.Utc), 15, 100 },
                    { 11, new DateTime(2025, 3, 13, 10, 0, 0, 0, DateTimeKind.Utc), 10, 156 },
                    { 12, new DateTime(2024, 7, 20, 14, 0, 0, 0, DateTimeKind.Utc), 9, 194 },
                    { 13, new DateTime(2025, 6, 3, 6, 0, 0, 0, DateTimeKind.Utc), 2, 104 },
                    { 14, new DateTime(2024, 6, 27, 13, 0, 0, 0, DateTimeKind.Utc), 1, 64 },
                    { 15, new DateTime(2025, 11, 17, 6, 0, 0, 0, DateTimeKind.Utc), 4, 96 },
                    { 16, new DateTime(2024, 4, 26, 12, 0, 0, 0, DateTimeKind.Utc), 7, 181 },
                    { 17, new DateTime(2024, 2, 2, 15, 0, 0, 0, DateTimeKind.Utc), 15, 194 },
                    { 18, new DateTime(2025, 11, 4, 16, 0, 0, 0, DateTimeKind.Utc), 9, 196 },
                    { 19, new DateTime(2025, 5, 1, 7, 0, 0, 0, DateTimeKind.Utc), 10, 53 },
                    { 20, new DateTime(2024, 9, 24, 15, 0, 0, 0, DateTimeKind.Utc), 8, 17 },
                    { 21, new DateTime(2025, 2, 20, 7, 0, 0, 0, DateTimeKind.Utc), 9, 42 },
                    { 22, new DateTime(2025, 7, 8, 13, 0, 0, 0, DateTimeKind.Utc), 14, 155 },
                    { 23, new DateTime(2025, 4, 4, 13, 0, 0, 0, DateTimeKind.Utc), 5, 32 },
                    { 24, new DateTime(2024, 9, 28, 7, 0, 0, 0, DateTimeKind.Utc), 1, 15 },
                    { 25, new DateTime(2024, 8, 25, 13, 0, 0, 0, DateTimeKind.Utc), 8, 186 },
                    { 26, new DateTime(2024, 11, 30, 7, 0, 0, 0, DateTimeKind.Utc), 3, 134 },
                    { 27, new DateTime(2024, 10, 4, 8, 0, 0, 0, DateTimeKind.Utc), 2, 29 },
                    { 28, new DateTime(2024, 11, 27, 12, 0, 0, 0, DateTimeKind.Utc), 13, 185 },
                    { 29, new DateTime(2025, 6, 27, 8, 0, 0, 0, DateTimeKind.Utc), 15, 111 },
                    { 30, new DateTime(2025, 7, 5, 7, 0, 0, 0, DateTimeKind.Utc), 12, 192 },
                    { 31, new DateTime(2025, 3, 3, 18, 0, 0, 0, DateTimeKind.Utc), 1, 116 },
                    { 32, new DateTime(2025, 7, 24, 6, 0, 0, 0, DateTimeKind.Utc), 4, 75 },
                    { 33, new DateTime(2024, 6, 20, 16, 0, 0, 0, DateTimeKind.Utc), 13, 167 },
                    { 34, new DateTime(2025, 11, 9, 6, 0, 0, 0, DateTimeKind.Utc), 5, 128 },
                    { 35, new DateTime(2025, 2, 14, 18, 0, 0, 0, DateTimeKind.Utc), 7, 109 },
                    { 36, new DateTime(2025, 10, 1, 14, 0, 0, 0, DateTimeKind.Utc), 2, 50 },
                    { 37, new DateTime(2025, 3, 27, 13, 0, 0, 0, DateTimeKind.Utc), 3, 187 },
                    { 38, new DateTime(2024, 7, 21, 7, 0, 0, 0, DateTimeKind.Utc), 13, 174 },
                    { 39, new DateTime(2025, 9, 21, 9, 0, 0, 0, DateTimeKind.Utc), 1, 149 },
                    { 40, new DateTime(2024, 9, 30, 14, 0, 0, 0, DateTimeKind.Utc), 5, 2 },
                    { 41, new DateTime(2024, 8, 18, 6, 0, 0, 0, DateTimeKind.Utc), 4, 164 },
                    { 42, new DateTime(2024, 2, 9, 14, 0, 0, 0, DateTimeKind.Utc), 5, 148 },
                    { 43, new DateTime(2024, 7, 24, 15, 0, 0, 0, DateTimeKind.Utc), 4, 41 },
                    { 44, new DateTime(2024, 8, 18, 7, 0, 0, 0, DateTimeKind.Utc), 6, 171 },
                    { 45, new DateTime(2024, 11, 22, 17, 0, 0, 0, DateTimeKind.Utc), 3, 45 },
                    { 46, new DateTime(2024, 9, 8, 13, 0, 0, 0, DateTimeKind.Utc), 2, 166 },
                    { 47, new DateTime(2025, 12, 22, 18, 0, 0, 0, DateTimeKind.Utc), 9, 107 },
                    { 48, new DateTime(2024, 8, 24, 14, 0, 0, 0, DateTimeKind.Utc), 4, 118 },
                    { 49, new DateTime(2024, 10, 6, 19, 0, 0, 0, DateTimeKind.Utc), 13, 100 },
                    { 50, new DateTime(2024, 5, 28, 18, 0, 0, 0, DateTimeKind.Utc), 6, 30 },
                    { 51, new DateTime(2024, 4, 6, 18, 0, 0, 0, DateTimeKind.Utc), 8, 54 },
                    { 52, new DateTime(2024, 3, 15, 8, 0, 0, 0, DateTimeKind.Utc), 4, 136 },
                    { 53, new DateTime(2025, 2, 16, 18, 0, 0, 0, DateTimeKind.Utc), 2, 5 },
                    { 54, new DateTime(2025, 1, 15, 6, 0, 0, 0, DateTimeKind.Utc), 14, 95 },
                    { 55, new DateTime(2025, 8, 2, 18, 0, 0, 0, DateTimeKind.Utc), 11, 135 },
                    { 56, new DateTime(2025, 8, 18, 14, 0, 0, 0, DateTimeKind.Utc), 6, 36 },
                    { 57, new DateTime(2024, 8, 18, 16, 0, 0, 0, DateTimeKind.Utc), 13, 9 },
                    { 58, new DateTime(2024, 12, 6, 12, 0, 0, 0, DateTimeKind.Utc), 6, 41 },
                    { 59, new DateTime(2024, 11, 24, 16, 0, 0, 0, DateTimeKind.Utc), 1, 121 },
                    { 60, new DateTime(2024, 9, 20, 16, 0, 0, 0, DateTimeKind.Utc), 10, 86 },
                    { 61, new DateTime(2024, 6, 15, 13, 0, 0, 0, DateTimeKind.Utc), 14, 110 },
                    { 62, new DateTime(2025, 1, 3, 17, 0, 0, 0, DateTimeKind.Utc), 12, 190 },
                    { 63, new DateTime(2024, 10, 27, 19, 0, 0, 0, DateTimeKind.Utc), 4, 139 },
                    { 64, new DateTime(2024, 5, 12, 17, 0, 0, 0, DateTimeKind.Utc), 11, 69 },
                    { 65, new DateTime(2024, 5, 24, 8, 0, 0, 0, DateTimeKind.Utc), 8, 52 },
                    { 66, new DateTime(2024, 10, 6, 6, 0, 0, 0, DateTimeKind.Utc), 14, 29 },
                    { 67, new DateTime(2025, 7, 8, 12, 0, 0, 0, DateTimeKind.Utc), 14, 142 },
                    { 68, new DateTime(2025, 2, 26, 18, 0, 0, 0, DateTimeKind.Utc), 3, 68 },
                    { 69, new DateTime(2025, 5, 18, 6, 0, 0, 0, DateTimeKind.Utc), 1, 141 },
                    { 70, new DateTime(2025, 6, 2, 7, 0, 0, 0, DateTimeKind.Utc), 1, 70 },
                    { 71, new DateTime(2024, 1, 12, 12, 0, 0, 0, DateTimeKind.Utc), 15, 114 },
                    { 72, new DateTime(2025, 11, 17, 17, 0, 0, 0, DateTimeKind.Utc), 6, 168 },
                    { 73, new DateTime(2024, 4, 6, 13, 0, 0, 0, DateTimeKind.Utc), 9, 61 },
                    { 74, new DateTime(2025, 7, 15, 9, 0, 0, 0, DateTimeKind.Utc), 13, 73 },
                    { 75, new DateTime(2025, 9, 22, 16, 0, 0, 0, DateTimeKind.Utc), 5, 30 },
                    { 76, new DateTime(2025, 12, 31, 12, 0, 0, 0, DateTimeKind.Utc), 12, 84 },
                    { 77, new DateTime(2025, 4, 2, 6, 0, 0, 0, DateTimeKind.Utc), 14, 38 },
                    { 78, new DateTime(2024, 8, 11, 13, 0, 0, 0, DateTimeKind.Utc), 9, 104 },
                    { 79, new DateTime(2025, 1, 19, 16, 0, 0, 0, DateTimeKind.Utc), 8, 157 },
                    { 80, new DateTime(2025, 9, 22, 19, 0, 0, 0, DateTimeKind.Utc), 13, 181 },
                    { 81, new DateTime(2025, 8, 2, 18, 0, 0, 0, DateTimeKind.Utc), 9, 6 },
                    { 82, new DateTime(2024, 6, 2, 13, 0, 0, 0, DateTimeKind.Utc), 5, 58 },
                    { 83, new DateTime(2025, 6, 12, 8, 0, 0, 0, DateTimeKind.Utc), 7, 152 },
                    { 84, new DateTime(2024, 6, 6, 9, 0, 0, 0, DateTimeKind.Utc), 7, 198 },
                    { 85, new DateTime(2024, 2, 16, 11, 0, 0, 0, DateTimeKind.Utc), 5, 130 },
                    { 86, new DateTime(2024, 9, 30, 19, 0, 0, 0, DateTimeKind.Utc), 14, 194 },
                    { 87, new DateTime(2024, 9, 16, 8, 0, 0, 0, DateTimeKind.Utc), 1, 28 },
                    { 88, new DateTime(2024, 11, 12, 14, 0, 0, 0, DateTimeKind.Utc), 6, 82 },
                    { 89, new DateTime(2024, 6, 8, 14, 0, 0, 0, DateTimeKind.Utc), 14, 115 },
                    { 90, new DateTime(2024, 9, 13, 11, 0, 0, 0, DateTimeKind.Utc), 4, 116 },
                    { 91, new DateTime(2024, 11, 2, 14, 0, 0, 0, DateTimeKind.Utc), 15, 157 },
                    { 92, new DateTime(2024, 5, 5, 18, 0, 0, 0, DateTimeKind.Utc), 2, 139 },
                    { 93, new DateTime(2024, 1, 26, 15, 0, 0, 0, DateTimeKind.Utc), 4, 174 },
                    { 94, new DateTime(2024, 5, 20, 6, 0, 0, 0, DateTimeKind.Utc), 4, 59 },
                    { 95, new DateTime(2024, 1, 9, 11, 0, 0, 0, DateTimeKind.Utc), 2, 181 },
                    { 96, new DateTime(2024, 6, 16, 6, 0, 0, 0, DateTimeKind.Utc), 10, 82 },
                    { 97, new DateTime(2024, 11, 2, 10, 0, 0, 0, DateTimeKind.Utc), 2, 109 },
                    { 98, new DateTime(2024, 10, 11, 12, 0, 0, 0, DateTimeKind.Utc), 4, 150 },
                    { 99, new DateTime(2024, 6, 20, 15, 0, 0, 0, DateTimeKind.Utc), 4, 46 },
                    { 100, new DateTime(2024, 7, 19, 19, 0, 0, 0, DateTimeKind.Utc), 8, 156 }
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
