using Microsoft.AspNetCore.Mvc;
using MidiaPlayerMC.Dto;
using MidiaPlayerMC.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class MediaController : ControllerBase
{
    private readonly IMediaInterface _mediaService;

    public MediaController(IMediaInterface mediaService)
    {
        _mediaService = mediaService;
    }

    [HttpGet(Name = "GetAllMedia")]
    public async Task<ActionResult<List<MediaOutputDto>>> GetAll()
    {
        return Ok(await _mediaService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MediaOutputDto>> GetById(int id)
    {
        var media = await _mediaService.GetByIdAsync(id);
        if (media == null) return NotFound();
        return Ok(media);
    }

    [HttpPost(Name = "InsertMedia")]
    public async Task<ActionResult<MediaOutputDto>> Create([FromQuery] InsertMediaInputDto input)
    {
        var created = await _mediaService.CreateAsync(input);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut(Name = "UpdateMedia")]
    public async Task<ActionResult<MediaOutputDto>> Update([FromQuery] MediaInputDto input)
    {
        var updated = await _mediaService.UpdateAsync(input);
        if (updated == null) return NotFound();
        return Ok(updated);
    }
}