using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoBiblioteca.Infrastructure.Pesistence.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Livro_Id",
                table: "Emprestimo");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Usuario_Id",
                table: "Emprestimo");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Emprestimo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdLivro",
                table: "Emprestimo",
                column: "IdLivro");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdUsuario",
                table: "Emprestimo",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Livro_IdLivro",
                table: "Emprestimo",
                column: "IdLivro",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Usuario_IdUsuario",
                table: "Emprestimo",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Livro_IdLivro",
                table: "Emprestimo");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Usuario_IdUsuario",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_IdLivro",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_IdUsuario",
                table: "Emprestimo");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Emprestimo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Livro_Id",
                table: "Emprestimo",
                column: "Id",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Usuario_Id",
                table: "Emprestimo",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
