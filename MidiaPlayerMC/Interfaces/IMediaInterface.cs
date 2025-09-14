using MidiaPlayerMC.Dto;

namespace MidiaPlayerMC.Interfaces
{
    public interface IMediaInterface
    {
        Task<List<MediaOutputDto>> GetAllAsync();
        Task<MediaOutputDto> GetByIdAsync(int id);
        Task<MediaOutputDto> CreateAsync(InsertMediaInputDto input);
        Task<MediaOutputDto> UpdateAsync(MediaInputDto input);

    }
}
