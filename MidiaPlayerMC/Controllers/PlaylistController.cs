using Microsoft.AspNetCore.Mvc;
using MidiaPlayerMC.Dto;
using MidiaPlayerMC.Interfaces;

namespace MidiaPlayerMC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController :  ControllerBase
    {
        private readonly IPlaylistInterface _playlistService;

        public PlaylistController(IPlaylistInterface playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet(Name = "GetAllMedia")]
        public async Task<ActionResult<List<PlaylistOutputDto>>> GetAll()
        {
            return Ok(await _playlistService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistOutputDto>> GetById(int id)
        {
            var media = await _playlistService.GetByIdAsync(id);
            if (media == null) return NotFound();
            return Ok(media);
        }

        [HttpPost(Name = "InsertMedia")]
        public async Task<ActionResult<PlaylistOutputDto>> Create([FromQuery] PlaylistInputDto input)
        {
            var created = await _playlistService.CreateAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = created.PlaylistNumber }, created);
        }

        [HttpPut(Name = "UpdateMedia")]
        public async Task<ActionResult<PlaylistOutputDto>> Update([FromQuery] PlaylistInputDto input)
        {
            var updated = await _playlistService.UpdateAsync(input);
            if (updated == null) return NotFound();
            return Ok(updated);
        }
    }
}
