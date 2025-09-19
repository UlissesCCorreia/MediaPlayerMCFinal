using Microsoft.EntityFrameworkCore;
using MidiaPlayerMC.Data;
using MidiaPlayerMC.Dto;
using MidiaPlayerMC.Interfaces;
using MidiaPlayerMC.Models;
using static MidiaPlayerMC.Dto.GetAllPlaylistMediaOutputDto;

namespace MidiaPlayerMC.Services
{
    public class MediaPlaylistService : IMediaPlaylistInterface
    {
        private readonly AppDbContext _context;

        public MediaPlaylistService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MediaPlaylistOutputDto> CreateAsync(MediaPlaylistInputDto input)
        {
            try
            {
                var mediaPlaylist = new MediaPlaylist
                {
                    MediaId = input.MediaNumber,
                    PlaylistId = input.PlaylistNumber,
                    IsActive = true,
                    IsMediaDisplayable = input.Displayable
                };

                _context.MediaPlaylists.Add(mediaPlaylist);
                await _context.SaveChangesAsync();

                return new MediaPlaylistOutputDto
                {
                    Message = "Mídia adicionada a playlist com sucesso."
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<MediaPlaylistOutputDto> UpdateAsync(MediaPlaylistInputDto input)
        {
            try
            {
                var mediaPlaylist = _context.MediaPlaylists
                    .FirstOrDefault(mp => mp.MediaId == input.MediaNumber && mp.PlaylistId == input.PlaylistNumber);

                mediaPlaylist.IsMediaDisplayable = input.Displayable;

                await _context.SaveChangesAsync();

                return new MediaPlaylistOutputDto
                {
                    Message = "Mídia alterada com sucesso."
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<GetAllPlaylistMediaOutputDto> GetAllPlaylistMedia(MediaPlaylistInputDto input)
        {
            try
            {
                var mediaListDto = new GetAllPlaylistMediaOutputDto
                {
                    medias = new List<MediaItemDto>()
                };

                using (var connection = _context.Database.GetDbConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    command.CommandText = @"
                    SELECT 
                        M.NAME MEDIANAME,
                        M.DESCRIPTION MEDIADESC,        
                        M.MEDIAUPLOAD MEDIAUP,
                        MP.ISMEDIADISPLAYABLE DISPLAYABLE
                    FROM
                        PLAYLISTS P
                    LEFT JOIN MEDIAPLAYLISTS MP ON P.ID = MP.PLAYLISTID
                    LEFT JOIN MEDIAS M ON MP.MEDIAID = M.ID
                    WHERE 
                        P.ID = @PlaylistId AND
                        P.ISACTIVE = 1 AND
                        MP.ISACTIVE = 1 AND
                        M.ISACTIVE = 1;
                    ";

                    var playlistIdParam = command.CreateParameter();
                    playlistIdParam.ParameterName = "@PlaylistId";
                    playlistIdParam.Value = input.PlaylistNumber;
                    command.Parameters.Add(playlistIdParam);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        mediaListDto.medias.Add(new MediaItemDto
                        {
                            Name = reader.GetString(0),
                            Description = reader.GetString(1),
                            MediaUpload = reader.GetString(2),
                            IsMediaDisplayable = reader.GetBoolean(3)
                        });
                    }
                    reader.Close();
                    connection.Close();
                    if (mediaListDto.medias == null)
                        mediaListDto.Message = "Nenhuma mídia encontrada para a playlist informada.";
                    else
                        mediaListDto.Message = "Mídias da playlist retornadas com sucesso.";
                }
                return mediaListDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
