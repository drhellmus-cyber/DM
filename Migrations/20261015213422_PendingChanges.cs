using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patient.Migrations
{
    /// <inheritdoc />
    public partial class PendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExamenCmpl",
                table: "Consultations",
                newName: "OrientationMotif");

            migrationBuilder.AddColumn<string>(
                name: "ATCD",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BilanBiologique",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BilanRadiologique",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CRO",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dgc",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MotifDeConsultation",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ATCD",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "BilanBiologique",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "BilanRadiologique",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "CRO",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Dgc",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "MotifDeConsultation",
                table: "Consultations");

            migrationBuilder.RenameColumn(
                name: "OrientationMotif",
                table: "Consultations",
                newName: "ExamenCmpl");
        }
    }
}
