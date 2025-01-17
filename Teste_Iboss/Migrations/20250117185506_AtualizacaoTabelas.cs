using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste_Iboss.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Curses",
                table: "Curses");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Curses",
                newName: "StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Curses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CurseId",
                table: "Curses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curses",
                table: "Curses",
                column: "CurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Curses_StudentId",
                table: "Curses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curses_Students_StudentId",
                table: "Curses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curses_Students_StudentId",
                table: "Curses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curses",
                table: "Curses");

            migrationBuilder.DropIndex(
                name: "IX_Curses_StudentId",
                table: "Curses");

            migrationBuilder.DropColumn(
                name: "CurseId",
                table: "Curses");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Curses",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Curses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curses",
                table: "Curses",
                column: "Id");
        }
    }
}
