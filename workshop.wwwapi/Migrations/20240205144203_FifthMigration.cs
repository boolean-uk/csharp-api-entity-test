using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "patientid",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                name: "FK_appointments_patients_patientid",
                table: "appointments",
                column: "patientid",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorid",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patientid",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_doctorid",
                table: "appointments");

            migrationBuilder.AlterColumn<int>(
                name: "patientid",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
