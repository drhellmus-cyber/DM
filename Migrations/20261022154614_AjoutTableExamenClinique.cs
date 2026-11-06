using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patient.Migrations
{
    /// <inheritdoc />
    public partial class AjoutTableExamenClinique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamenClinique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomExamen = table.Column<string>(type: "TEXT", nullable: false),
                    Pathologique = table.Column<bool>(type: "INTEGER", nullable: false),
                    Lateralite = table.Column<int>(type: "INTEGER", nullable: false),
                    CategorieExamen = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenClinique", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamenClinique");
        }
    }
}
