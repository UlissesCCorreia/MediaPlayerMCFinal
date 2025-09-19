using MidiaPlayerMC.Models;

namespace MidiaPlayerMC.Dto
{
    public class GetAllPlaylistMediaOutputDto
    {
        public List<MediaItemDto> medias { get; set; }
        public string Message { get; set; }

        public class MediaItemDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string MediaUpload { get; set; }
            public bool IsMediaDisplayable { get; set; }
        }

    }
}
