using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidiaPlayerMC.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationAdicionandoContextMediaPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaPlaylist_Medias_MediaId",
                table: "MediaPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaPlaylist_Playlists_PlaylistId",
                table: "MediaPlaylist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaPlaylist",
                table: "MediaPlaylist");

            migrationBuilder.RenameTable(
                name: "MediaPlaylist",
                newName: "MediaPlaylists");

            migrationBuilder.RenameIndex(
                name: "IX_MediaPlaylist_PlaylistId",
                table: "MediaPlaylists",
                newName: "IX_MediaPlaylists_PlaylistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaPlaylists",
                table: "MediaPlaylists",
                columns: new[] { "MediaId", "PlaylistId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MediaPlaylists_Medias_MediaId",
                table: "MediaPlaylists",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaPlaylists_Playlists_PlaylistId",
                table: "MediaPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaPlaylists_Medias_MediaId",
                table: "MediaPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaPlaylists_Playlists_PlaylistId",
                table: "MediaPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaPlaylists",
                table: "MediaPlaylists");

            migrationBuilder.RenameTable(
                name: "MediaPlaylists",
                newName: "MediaPlaylist");

            migrationBuilder.RenameIndex(
                name: "IX_MediaPlaylists_PlaylistId",
                table: "MediaPlaylist",
                newName: "IX_MediaPlaylist_PlaylistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaPlaylist",
                table: "MediaPlaylist",
                columns: new[] { "MediaId", "PlaylistId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MediaPlaylist_Medias_MediaId",
                table: "MediaPlaylist",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaPlaylist_Playlists_PlaylistId",
                table: "MediaPlaylist",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
