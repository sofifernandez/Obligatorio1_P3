using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class CabanaToCabanas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabana_Tipos_TipoId",
                table: "Cabana");

            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Cabana_CabanaId",
                table: "Mantenimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabana",
                table: "Cabana");

            migrationBuilder.RenameTable(
                name: "Cabana",
                newName: "Cabanas");

            migrationBuilder.RenameIndex(
                name: "IX_Cabana_TipoId",
                table: "Cabanas",
                newName: "IX_Cabanas_TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cabana_NombreCabana_Value",
                table: "Cabanas",
                newName: "IX_Cabanas_NombreCabana_Value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabanas",
                table: "Cabanas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabanas_Tipos_TipoId",
                table: "Cabanas",
                column: "TipoId",
                principalTable: "Tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Cabanas_CabanaId",
                table: "Mantenimientos",
                column: "CabanaId",
                principalTable: "Cabanas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabanas_Tipos_TipoId",
                table: "Cabanas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Cabanas_CabanaId",
                table: "Mantenimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabanas",
                table: "Cabanas");

            migrationBuilder.RenameTable(
                name: "Cabanas",
                newName: "Cabana");

            migrationBuilder.RenameIndex(
                name: "IX_Cabanas_TipoId",
                table: "Cabana",
                newName: "IX_Cabana_TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cabanas_NombreCabana_Value",
                table: "Cabana",
                newName: "IX_Cabana_NombreCabana_Value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabana",
                table: "Cabana",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabana_Tipos_TipoId",
                table: "Cabana",
                column: "TipoId",
                principalTable: "Tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Cabana_CabanaId",
                table: "Mantenimientos",
                column: "CabanaId",
                principalTable: "Cabana",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
