using Microsoft.AspNetCore.Mvc;
using MidiaPlayerMC.Dto;
using MidiaPlayerMC.Interfaces;
using MidiaPlayerMC.Services;

namespace MidiaPlayerMC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaPlaylistController : ControllerBase
    {
        private readonly IMediaPlaylistInterface _mediaPlaylistService;

        public MediaPlaylistController(IMediaPlaylistInterface mediaPlaylistService)
        {
            _mediaPlaylistService = mediaPlaylistService;
        }

        [HttpGet(Name = "GetAllPlaylistMedia")]
        public async Task<ActionResult<GetAllPlaylistMediaOutputDto>> GetAllPlaylistMedia([FromQuery] MediaPlaylistInputDto input)
        {
            var mediaList = await _mediaPlaylistService.GetAllPlaylistMedia(input);
            if (mediaList == null) return NotFound();
            return Ok(mediaList);
        }

        [HttpPost(Name = "InsertMediaPlaylist")]
        public async Task<ActionResult<MediaPlaylistOutputDto>> Create([FromQuery] MediaPlaylistInputDto input)
        {
            var created = await _mediaPlaylistService.CreateAsync(input);
            return Ok(created);
        }

        [HttpPut(Name = "UpdateMediaPlaylist")]
        public async Task<ActionResult<MediaPlaylistOutputDto>> Update([FromQuery] MediaPlaylistInputDto input)
        {
            var updated = await _mediaPlaylistService.UpdateAsync(input);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
    }
}
