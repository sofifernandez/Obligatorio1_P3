using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class descripValueObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescTipo",
                table: "Tipos",
                newName: "DescTipo_Value");

            migrationBuilder.RenameColumn(
                name: "DescripCabana",
                table: "Cabanas",
                newName: "DescripCabana_Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescTipo_Value",
                table: "Tipos",
                newName: "DescTipo");

            migrationBuilder.RenameColumn(
                name: "DescripCabana_Value",
                table: "Cabanas",
                newName: "DescripCabana");
        }
    }
}
