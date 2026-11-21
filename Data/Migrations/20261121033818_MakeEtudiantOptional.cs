using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAppData.Migrations
{
    /// <inheritdoc />
    public partial class MakeEtudiantOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Etudiants_EtudiantId",
                table: "Utilisateurs");

            migrationBuilder.AlterColumn<int>(
                name: "EtudiantId",
                table: "Utilisateurs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Etudiants_EtudiantId",
                table: "Utilisateurs",
                column: "EtudiantId",
                principalTable: "Etudiants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Etudiants_EtudiantId",
                table: "Utilisateurs");

            migrationBuilder.AlterColumn<int>(
                name: "EtudiantId",
                table: "Utilisateurs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Etudiants_EtudiantId",
                table: "Utilisateurs",
                column: "EtudiantId",
                principalTable: "Etudiants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
