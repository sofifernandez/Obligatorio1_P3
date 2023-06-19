using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class NombreTipoValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Tipos",
                newName: "NombreTipo_Value");

            migrationBuilder.RenameIndex(
                name: "IX_Tipos_Nombre",
                table: "Tipos",
                newName: "IX_Tipos_NombreTipo_Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreTipo_Value",
                table: "Tipos",
                newName: "Nombre");

            migrationBuilder.RenameIndex(
                name: "IX_Tipos_NombreTipo_Value",
                table: "Tipos",
                newName: "IX_Tipos_Nombre");
        }
    }
}
