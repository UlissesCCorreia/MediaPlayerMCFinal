using System.Text.Json.Serialization;

namespace MidiaPlayerMC.Models
{
    public class Media
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; internal set; }
        public string MediaUpload { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public List<MediaPlaylist> MediaPlaylists { get; set; }
    }
}