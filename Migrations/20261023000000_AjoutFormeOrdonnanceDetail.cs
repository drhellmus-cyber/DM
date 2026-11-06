using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patient.Migrations
{
    /// <inheritdoc />
    public partial class AjoutFormeOrdonnanceDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Forme",
                table: "OrdonnanceDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Forme",
                table: "OrdonnanceDetails");
        }
    }
}
