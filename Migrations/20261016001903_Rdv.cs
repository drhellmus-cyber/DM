using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patient.Migrations
{
    /// <inheritdoc />
    public partial class Rdv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRDV",
                table: "Consultations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intervention",
                table: "Consultations",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRDV",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Intervention",
                table: "Consultations");
        }
    }
}
