using Microsoft.EntityFrameworkCore;
using MidiaPlayerMC.Data;
using MidiaPlayerMC.Dto;
using MidiaPlayerMC.Interfaces;
using MidiaPlayerMC.Models;

namespace MidiaPlayerMC.Services
{
    public class PlaylistService : IPlaylistInterface
    {
        private readonly AppDbContext _context;

        public PlaylistService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PlaylistOutputDto> CreateAsync(PlaylistInputDto input)
        {
            try
            {
                var playlist = new Playlist
                {
                    Name = input.PlaylistName,
                    IsActive = true
                };

                _context.Playlists.Add(playlist);
                await _context.SaveChangesAsync();

                return new PlaylistOutputDto
                {
                    PlaylistNumber = playlist.Id,
                    PlaylistName = playlist.Name,
                    Active = playlist.IsActive,
                    Message = "Playlist criada com sucesso."
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<List<PlaylistOutputDto>> GetAllAsync()
        {
            try
            {
                return await _context.Playlists
                .Select(p => new PlaylistOutputDto
                {
                    PlaylistNumber = p.Id,
                    PlaylistName = p.Name,
                    Active = p.IsActive
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<PlaylistOutputDto> GetByIdAsync(int id)
        {
            try
            {
                var playlist = await _context.Playlists.FindAsync(id);
                return new PlaylistOutputDto
                {
                    PlaylistNumber = playlist?.Id ?? 0,
                    PlaylistName = playlist?.Name ?? "",
                    Active = playlist == null ? false : playlist.IsActive,
                    Message = playlist == null ? "Playlist não encontrada." : "Playlist encontrada."
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<PlaylistOutputDto> UpdateAsync(PlaylistInputDto input)
        {
            try
            {
                var playlist = await _context.Playlists.FindAsync(input.PlalistNumber);
                if (playlist == null)
                {
                    return new PlaylistOutputDto
                    {
                        PlaylistNumber = 0,
                        PlaylistName = "",
                        Active = false,
                        Message = "Playlist não encontrada."
                    };
                }

                playlist.Name = input.PlaylistName;
                playlist.IsActive = input.Active;

                await _context.SaveChangesAsync();

                return new PlaylistOutputDto
                {
                    PlaylistNumber = playlist.Id,
                    PlaylistName = playlist.Name,
                    Active = playlist.IsActive,
                    Message = "Playlist alterada com sucesso."
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
