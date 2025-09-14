using System.Text.Json.Serialization;

namespace MidiaPlayerMC.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public List<MediaPlaylist> MediaPlaylists { get; set; }
    }
}
