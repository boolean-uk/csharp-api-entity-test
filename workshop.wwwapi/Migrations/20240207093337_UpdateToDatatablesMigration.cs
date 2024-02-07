using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToDatatablesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "patient_id",
                table: "appointments",
                newName: "doctor_id_fk");

            migrationBuilder.RenameColumn(
                name: "doctor_id",
                table: "appointments",
                newName: "patient_id_fk");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "patient_id_fk", "doctor_id_fk", "booking" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "doctor_id_fk",
                table: "appointments",
                newName: "patient_id");

            migrationBuilder.RenameColumn(
                name: "patient_id_fk",
                table: "appointments",
                newName: "doctor_id");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                column: "id");
        }
    }
}
