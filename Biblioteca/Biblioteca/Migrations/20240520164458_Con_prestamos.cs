using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class Con_prestamos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Usuarios_UsuarioID",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "IDUsuario",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "IdLibro",
                table: "Prestamos");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Prestamos",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_UsuarioID",
                table: "Prestamos",
                newName: "IX_Prestamos_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Usuarios_UsuarioId",
                table: "Prestamos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Usuarios_UsuarioId",
                table: "Prestamos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Prestamos",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_UsuarioId",
                table: "Prestamos",
                newName: "IX_Prestamos_UsuarioID");

            migrationBuilder.AddColumn<int>(
                name: "IDUsuario",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLibro",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Usuarios_UsuarioID",
                table: "Prestamos",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
