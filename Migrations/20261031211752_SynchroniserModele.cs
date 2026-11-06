using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patient.Migrations
{
    /// <inheritdoc />
    public partial class SynchroniserModele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdonnanceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomModele = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdonnanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdonnanceTypeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdonnanceTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicamentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Dosage = table.Column<string>(type: "TEXT", nullable: false),
                    Forme = table.Column<string>(type: "TEXT", nullable: false),
                    Frequence = table.Column<string>(type: "TEXT", nullable: false),
                    Duree = table.Column<string>(type: "TEXT", nullable: false),
                    Rq = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdonnanceTypeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdonnanceTypeDetails_Medicaments_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdonnanceTypeDetails_OrdonnanceTypes_OrdonnanceTypeId",
                        column: x => x.OrdonnanceTypeId,
                        principalTable: "OrdonnanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdonnanceTypeDetails_MedicamentId",
                table: "OrdonnanceTypeDetails",
                column: "MedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdonnanceTypeDetails_OrdonnanceTypeId",
                table: "OrdonnanceTypeDetails",
                column: "OrdonnanceTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdonnanceTypeDetails");

            migrationBuilder.DropTable(
                name: "OrdonnanceTypes");
        }
    }
}
