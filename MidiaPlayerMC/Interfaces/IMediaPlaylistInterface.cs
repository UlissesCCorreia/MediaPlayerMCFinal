using MidiaPlayerMC.Dto;

namespace MidiaPlayerMC.Interfaces
{
    public interface IMediaPlaylistInterface
    {
        Task<MediaPlaylistOutputDto> CreateAsync(MediaPlaylistInputDto input);
        Task<MediaPlaylistOutputDto> UpdateAsync(MediaPlaylistInputDto input);
        Task<GetAllPlaylistMediaOutputDto> GetAllPlaylistMedia(MediaPlaylistInputDto input);
    }
}
