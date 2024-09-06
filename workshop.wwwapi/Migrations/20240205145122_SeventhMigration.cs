using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorid",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientId1",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_PatientId1",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_doctorid",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "appointments");

            migrationBuilder.AlterColumn<int>(
                name: "patientid",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "doctorid", "patientid" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.AlterColumn<int>(
                name: "patientid",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PatientId1",
                table: "appointments",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctorid",
                table: "appointments",
                column: "doctorid");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctorid",
                table: "appointments",
                column: "doctorid",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientId1",
                table: "appointments",
                column: "PatientId1",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
