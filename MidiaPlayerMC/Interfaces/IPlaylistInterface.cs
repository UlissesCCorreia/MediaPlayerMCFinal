using MidiaPlayerMC.Dto;

namespace MidiaPlayerMC.Interfaces
{
    public interface IPlaylistInterface
    {
        Task<List<PlaylistOutputDto>> GetAllAsync();
        Task<PlaylistOutputDto> GetByIdAsync(int id);
        Task<PlaylistOutputDto> CreateAsync(InsertPlaylistInputDto input);
        Task<PlaylistOutputDto> UpdateAsync(PlaylistInputDto input);
    }
}
