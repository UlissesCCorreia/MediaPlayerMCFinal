using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidiaPlayerMC.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoClasseMediaPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaPlaylists");

            migrationBuilder.CreateTable(
                name: "MediaPlaylist",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsMediaDisplayable = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaPlaylist", x => new { x.MediaId, x.PlaylistId });
                    table.ForeignKey(
                        name: "FK_MediaPlaylist_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaPlaylist_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaPlaylist_PlaylistId",
                table: "MediaPlaylist",
                column: "PlaylistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaPlaylist");

            migrationBuilder.CreateTable(
                name: "MediaPlaylists",
                columns: table => new
                {
                    MediasId = table.Column<int>(type: "int", nullable: false),
                    playlistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaPlaylists", x => new { x.MediasId, x.playlistsId });
                    table.ForeignKey(
                        name: "FK_MediaPlaylists_Medias_MediasId",
                        column: x => x.MediasId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaPlaylists_Playlists_playlistsId",
                        column: x => x.playlistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaPlaylists_playlistsId",
                table: "MediaPlaylists",
                column: "playlistsId");
        }
    }
}
