namespace MidiaPlayerMC.Models
{
    public class MediaPlaylist
    {
        public int Id { get; set; }

        public int MediaId { get; set; }
        public Media Media { get; set; }

        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        public bool IsMediaDisplayable { get; set; }
        public bool IsActive { get; set; }
    }
}
