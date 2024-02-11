using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class newone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment" ,
                table: "appointment");

            migrationBuilder.DeleteData(
                table: "appointment" ,
                keyColumns: new[] { "doctorid" , "patientid" } ,
                keyValues: new object[] { 1 , 1 });

            migrationBuilder.DeleteData(
                table: "appointment" ,
                keyColumns: new[] { "doctorid" , "patientid" } ,
                keyValues: new object[] { 2 , 1 });

            migrationBuilder.DeleteData(
                table: "appointment" ,
                keyColumns: new[] { "doctorid" , "patientid" } ,
                keyValues: new object[] { 1 , 2 });

            migrationBuilder.DeleteData(
                table: "appointment" ,
                keyColumns: new[] { "doctorid" , "patientid" } ,
                keyValues: new object[] { 2 , 2 });

            migrationBuilder.AlterColumn<int>(
                name: "id" ,
                table: "appointment" ,
                type: "integer" ,
                nullable: false ,
                oldClrType: typeof(int) ,
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy" , NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment" ,
                table: "appointment" ,
                column: "id");

            migrationBuilder.InsertData(
                table: "appointment" ,
                columns: new[] { "id" , "booking" , "doctorid" , "patientid" } ,
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 31, 13, 12, 59, 167, DateTimeKind.Utc).AddTicks(7400), 1, 1 },
                    { 2, new DateTime(2024, 1, 31, 13, 12, 59, 167, DateTimeKind.Utc).AddTicks(7402), 1, 2 },
                    { 3, new DateTime(2024, 1, 31, 13, 12, 59, 167, DateTimeKind.Utc).AddTicks(7403), 2, 1 },
                    { 4, new DateTime(2024, 1, 31, 13, 12, 59, 167, DateTimeKind.Utc).AddTicks(7404), 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_patientid" ,
                table: "appointment" ,
                column: "patientid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment" ,
                table: "appointment");

            migrationBuilder.DropIndex(
                name: "IX_appointment_patientid" ,
                table: "appointment");

            migrationBuilder.DeleteData(
                table: "appointment" ,
                keyColumn: "id" ,
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "appointment" ,
                keyColumn: "id" ,
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "appointment" ,
                keyColumn: "id" ,
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "appointment" ,
                keyColumn: "id" ,
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "id" ,
                table: "appointment" ,
                type: "integer" ,
                nullable: false ,
                oldClrType: typeof(int) ,
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy" , NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment" ,
                table: "appointment" ,
                columns: new[] { "patientid" , "doctorid" });

            migrationBuilder.InsertData(
                table: "appointment" ,
                columns: new[] { "doctorid" , "patientid" , "booking" , "id" } ,
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 31, 12, 26, 1, 214, DateTimeKind.Utc).AddTicks(3478), 1 },
                    { 2, 1, new DateTime(2024, 1, 31, 12, 26, 1, 214, DateTimeKind.Utc).AddTicks(3480), 3 },
                    { 1, 2, new DateTime(2024, 1, 31, 12, 26, 1, 214, DateTimeKind.Utc).AddTicks(3479), 2 },
                    { 2, 2, new DateTime(2024, 1, 31, 12, 26, 1, 214, DateTimeKind.Utc).AddTicks(3481), 4 }
                });
        }
    }
}
