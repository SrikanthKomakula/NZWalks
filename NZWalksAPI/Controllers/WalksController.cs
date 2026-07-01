using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]

public class WalksController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IWalkRepository _walkRepository;
    private readonly ILogger<WalksController> logger;

    public WalksController(IMapper mapper, IWalkRepository walkRepository, ILogger<WalksController> logger)
    {
        _mapper = mapper;
        _walkRepository = walkRepository;
        this.logger = logger;
    }

    [HttpPost]
    //[Authorize(Roles = "Writer")]
    public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
    {
        // Map DTO to domain model
        var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);

        // Save to DB via repository
        walkDomainModel = await _walkRepository.CrateWalk(walkDomainModel);

        // Map domain model back to DTO
        var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

        return Ok(walkDto);
    }

    [HttpGet]
    //[Authorize(Roles = "Reader")]
    public async Task<IActionResult> GetAll([FromQuery] String? filterOn, [FromQuery] String? filterQuery, [FromQuery] string? sortBy, [FromQuery] Boolean isAsending = false, int pageNumber = 1, [FromQuery] int pageSize = 1000)
    {
        logger.LogInformation("GetAll Walks method is invoded");

           // throw new Exception("This is exception");
            var walksModel = await _walkRepository.GelAllWalk(filterOn, filterQuery, sortBy, isAsending, pageNumber, pageSize);
            logger.LogInformation($"This is the walks informaiton: {JsonSerializer.Serialize(walksModel)}");
            var walkDto = _mapper.Map<List<WalkDto>>(walksModel);
            return Ok(walkDto);
       

        

    }

    [HttpGet]
    [Route("{id:Guid}")]
    //[Authorize(Roles = "Reader")]
    public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
    {
        var walkModel = await _walkRepository.GetWalkById(id);
        var WalkDto = _mapper.Map<WalkDto>(walkModel);
        return Ok(WalkDto);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    //[Authorize(Roles = "Writer, Reader")]
    public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkDto walk)
    {
        var walkDto = await _walkRepository.UpdateWalkById(id, walk);
        if(walkDto == null) { return NotFound(); }
        return Ok(walkDto);

    }
}