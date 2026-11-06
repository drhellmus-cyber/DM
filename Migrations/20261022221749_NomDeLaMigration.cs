using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patient.Migrations
{
    /// <inheritdoc />
    public partial class NomDeLaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamenClinique",
                table: "ExamenClinique");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Consultations");

            migrationBuilder.RenameTable(
                name: "ExamenClinique",
                newName: "ExamenCliniques");

            migrationBuilder.AddColumn<string>(
                name: "CB",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cou",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Face",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Neurologique",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OTO",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RA",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vestibulaire",
                table: "Consultations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamenCliniques",
                table: "ExamenCliniques",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamenCliniques",
                table: "ExamenCliniques");

            migrationBuilder.DropColumn(
                name: "CB",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Cou",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Face",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Neurologique",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "OTO",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "RA",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Vestibulaire",
                table: "Consultations");

            migrationBuilder.RenameTable(
                name: "ExamenCliniques",
                newName: "ExamenClinique");

            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Consultations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamenClinique",
                table: "ExamenClinique",
                column: "Id");
        }
    }
}
