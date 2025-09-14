using MidiaPlayerMC.Models;
using MidiaPlayerMC.Data;
using Microsoft.EntityFrameworkCore;
using MidiaPlayerMC.Dto;
using MidiaPlayerMC.Interfaces;
using System;

public class MediaService : IMediaInterface
{
    private readonly AppDbContext _context;

    public MediaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MediaOutputDto>> GetAllAsync()
    {
        try
        {
            return await _context.Medias
            .Select(m => new MediaOutputDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                MediaUpload = m.MediaUpload,
                Active = m.IsActive
            }).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

    public async Task<MediaOutputDto> GetByIdAsync(int id)
    {
        try
        {
            var media = await _context.Medias.FindAsync(id);
            return new MediaOutputDto
            {
                Id = media?.Id ?? 0,
                Name = media?.Name ?? "",
                Description = media?.Description ?? "",
                MediaUpload = media?.MediaUpload ?? "",
                Active = media == null ? false : media.IsActive,
                Message = media == null ? "Mídia não encontrada." : "Mídia encontrada."
            };

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

    public async Task<MediaOutputDto> CreateAsync(InsertMediaInputDto input)
    {
        try
        {
            var media = new Media
            {
                Name = input.Name,
                Description = input.Description,
                MediaUpload = input.MediaUpload,
                IsActive = input.Active
            };

            _context.Medias.Add(media);
            await _context.SaveChangesAsync();

            return new MediaOutputDto
            {
                Id = media.Id,
                Name = media.Name,
                Description = media.Description,
                MediaUpload = media.MediaUpload,
                Active = media.IsActive,
                Message = "Mídia criada com sucesso."
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

    public async Task<MediaOutputDto> UpdateAsync(MediaInputDto input)
    {
        try
        {
            var media = await _context.Medias.FindAsync(input.MediaNumber);
            if (media == null)
            {
                return new MediaOutputDto
                {
                    Id = 0,
                    Name = "",
                    Description = "",
                    MediaUpload = "",
                    Active = false,
                    Message = "Mídia não encontrada."
                };
            }

            media.Name = input.Name;
            media.Description = input.Description;
            media.MediaUpload = input.MediaUpload;
            media.IsActive = input.Active;

            await _context.SaveChangesAsync();

            return new MediaOutputDto
            {
                Id = media.Id,
                Name = media.Name,
                Description = media.Description,
                MediaUpload = media.MediaUpload,
                Active = media.IsActive,
                Message = "Mídia alterada com sucesso."
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}