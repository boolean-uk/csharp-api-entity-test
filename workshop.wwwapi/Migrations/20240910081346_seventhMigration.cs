﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class seventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 9, 1 },
                column: "booking",
                value: new DateTime(2025, 6, 23, 1, 49, 38, 625, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "booking", "id" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2024, 10, 7, 14, 58, 57, 625, DateTimeKind.Utc).AddTicks(9253), 2 },
                    { 3, 5, new DateTime(2025, 9, 7, 6, 50, 14, 625, DateTimeKind.Utc).AddTicks(9266), 5 },
                    { 6, 6, new DateTime(2025, 6, 26, 9, 39, 5, 625, DateTimeKind.Utc).AddTicks(9270), 6 },
                    { 6, 8, new DateTime(2024, 12, 20, 6, 28, 21, 625, DateTimeKind.Utc).AddTicks(9277), 8 },
                    { 7, 3, new DateTime(2025, 6, 20, 11, 53, 12, 625, DateTimeKind.Utc).AddTicks(9259), 3 },
                    { 7, 9, new DateTime(2024, 9, 22, 14, 35, 19, 625, DateTimeKind.Utc).AddTicks(9280), 9 },
                    { 7, 10, new DateTime(2025, 6, 3, 16, 31, 56, 625, DateTimeKind.Utc).AddTicks(9284), 10 },
                    { 9, 7, new DateTime(2025, 3, 8, 22, 33, 58, 625, DateTimeKind.Utc).AddTicks(9273), 7 },
                    { 10, 4, new DateTime(2025, 6, 11, 0, 55, 9, 625, DateTimeKind.Utc).AddTicks(9263), 4 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Elvis Winslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Elvis Mathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Adam Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Neo Mouse");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Neo Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Barack Mathiasson");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Mickey Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Adam Duck");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Felix Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Donald Winfrey");

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Bad Pills", 25 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Crazy Couch drops", 91 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Snort before tequila shot.", "Stupid Leaves", 1 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Insert into rectum.", "Ultra Couch drops", 14 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Mix with chicken noodle soup.", "Stupid Aspirin", 23 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Super Blue Pills", 14 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Mix with chicken noodle soup.", "Crazy Heroin", 76 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Insert into rectum.", "Ultra Heroin", 63 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Hide in cabinet and let the placebo effect do it's job.", "Not Leaves", 98 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Snort before tequila shot.", "Stupid Xanax", 93 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Kate Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Ragnar Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Barack Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Charles Sandler");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Elvis Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Neo Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Elvis Winfrey");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Neo Xavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Oprah Lothbrok");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Arnold Mathiasson");

            migrationBuilder.InsertData(
                table: "prescription_medicines",
                columns: new[] { "medicine_id", "prescription_id" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 6, 2 },
                    { 2, 3 },
                    { 4, 3 },
                    { 7, 3 },
                    { 2, 5 },
                    { 5, 5 },
                    { 7, 6 },
                    { 9, 6 },
                    { 1, 7 },
                    { 6, 7 },
                    { 10, 7 },
                    { 5, 8 },
                    { 8, 9 },
                    { 9, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 4, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "prescription_medicines",
                keyColumns: new[] { "medicine_id", "prescription_id" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 9, 1 },
                column: "booking",
                value: new DateTime(2024, 12, 27, 22, 59, 38, 248, DateTimeKind.Utc).AddTicks(2908));

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "booking", "id" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 8, 7, 21, 14, 37, 248, DateTimeKind.Utc).AddTicks(3014), 2 },
                    { 2, 10, new DateTime(2025, 8, 17, 13, 38, 23, 248, DateTimeKind.Utc).AddTicks(3110), 10 },
                    { 3, 7, new DateTime(2024, 11, 6, 16, 31, 31, 248, DateTimeKind.Utc).AddTicks(3099), 7 },
                    { 5, 5, new DateTime(2025, 5, 14, 2, 58, 28, 248, DateTimeKind.Utc).AddTicks(3086), 5 },
                    { 6, 3, new DateTime(2025, 6, 23, 14, 50, 17, 248, DateTimeKind.Utc).AddTicks(3037), 3 },
                    { 7, 4, new DateTime(2024, 10, 19, 4, 20, 49, 248, DateTimeKind.Utc).AddTicks(3047), 4 },
                    { 7, 8, new DateTime(2025, 2, 2, 23, 52, 32, 248, DateTimeKind.Utc).AddTicks(3102), 8 },
                    { 8, 6, new DateTime(2025, 4, 18, 14, 12, 57, 248, DateTimeKind.Utc).AddTicks(3095), 6 },
                    { 8, 9, new DateTime(2025, 5, 19, 2, 33, 43, 248, DateTimeKind.Utc).AddTicks(3106), 9 }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Arnold Xavier");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Adam Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Barack Obama");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Felix Sandler");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Barack Winslow");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Donald Sandler");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Donald Lothbrok");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Elvis Lothbrok");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Arnold Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Mickey Duck");

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Ultra Couch drops", 58 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Stupid Blue Pills", 83 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Mix with chicken noodle soup.", "Crazy Xanax", 7 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Swallow with water.", "Dangerous Laxatives", 33 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Insert into rectum.", "Yummy Mushrooms", 6 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "quantity" },
                values: new object[] { "Yummy Leaves", 45 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Snort before tequila shot.", "Good Couch drops", 80 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Chew on it for 3 hours.", "Ultra Leaves", 60 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Disolve into drink of your choice.", "Dangerous Leaves", 80 });

            migrationBuilder.UpdateData(
                table: "medicines",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "instructions", "name", "quantity" },
                values: new object[] { "Chew on it for 3 hours.", "Yummy Leaves", 28 });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1,
                column: "fullName",
                value: "Felix Schwarzenegger");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2,
                column: "fullName",
                value: "Arnold Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3,
                column: "fullName",
                value: "Felix Obama");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4,
                column: "fullName",
                value: "Neo Winslow");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 5,
                column: "fullName",
                value: "Elvis Andersson");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 6,
                column: "fullName",
                value: "Donald Sandler");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 7,
                column: "fullName",
                value: "Ragnar Xavier");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 8,
                column: "fullName",
                value: "Barack Mouse");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 9,
                column: "fullName",
                value: "Barack Presley");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "id",
                keyValue: 10,
                column: "fullName",
                value: "Felix Lothbrok");

            migrationBuilder.InsertData(
                table: "prescription_medicines",
                columns: new[] { "medicine_id", "prescription_id" },
                values: new object[,]
                {
                    { 9, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 7, 2 },
                    { 10, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 1, 5 },
                    { 6, 5 },
                    { 4, 6 },
                    { 8, 6 },
                    { 4, 7 },
                    { 5, 7 },
                    { 8, 7 },
                    { 6, 8 },
                    { 7, 8 },
                    { 2, 9 },
                    { 3, 9 },
                    { 5, 9 },
                    { 7, 9 },
                    { 9, 10 }
                });
        }
    }
}