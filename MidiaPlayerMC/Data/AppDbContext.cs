using Microsoft.EntityFrameworkCore;
using MidiaPlayerMC.Models;

namespace MidiaPlayerMC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Media> Medias { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da relação muitos-para-muitos
            modelBuilder.Entity<MediaPlaylist>().
                HasKey(mp => new { mp.MediaId, mp.PlaylistId });

            modelBuilder.Entity<MediaPlaylist>()
                .HasOne(mp => mp.Media)
                .WithMany(m => m.MediaPlaylists)
                .HasForeignKey(mp => mp.MediaId);

            modelBuilder.Entity<MediaPlaylist>()
                .HasOne(mp => mp.Playlist)
                .WithMany(p => p.MediaPlaylists)
                .HasForeignKey(mp => mp.PlaylistId);

        }

    }
}
