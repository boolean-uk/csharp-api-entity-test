﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class intialCreat3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => new { x.patient_id, x.doctor_id });
                    table.ForeignKey(
                        name: "FK_appointment_doctor_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctor",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Bruno Fernandes" },
                    { 2, "Henrik Rosenkilde" },
                    { 3, "Ada Hegerberg" }
                });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Cristiano Ronaldo" },
                    { 2, "Lionel Messi" },
                    { 3, "Erling Braut Haaland" }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 2, 8, 39, 39, 440, DateTimeKind.Utc).AddTicks(1241) },
                    { 1, 2, new DateTime(2024, 2, 2, 8, 39, 39, 440, DateTimeKind.Utc).AddTicks(1342) },
                    { 2, 3, new DateTime(2024, 2, 2, 8, 39, 39, 440, DateTimeKind.Utc).AddTicks(1346) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_doctor_id",
                table: "appointment",
                column: "doctor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
