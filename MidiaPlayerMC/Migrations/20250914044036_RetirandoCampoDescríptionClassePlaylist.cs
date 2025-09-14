using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidiaPlayerMC.Migrations
{
    /// <inheritdoc />
    public partial class RetirandoCampoDescríptionClassePlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Playlists");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Medias",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Medias",
                newName: "description");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
