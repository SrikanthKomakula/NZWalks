using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    //localhost:4200/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionsRepository regionsRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext DbContext, IRegionsRepository regionsRepository, IMapper mapper)
        {
            this.dbContext = DbContext;
            this.regionsRepository = regionsRepository;
            this.mapper = mapper;
        }

        //[HttpGet("GetALl")]
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var regions = new List<Region>()
        //    {
        //        new Region
        //        {
        //            Id= Guid.NewGuid(),
        //            Name="Auckland Region",
        //            Code="AUCK",
        //            RegionImageUrl="https://images.pexels.com/photos/31168400/pexels-photo-31168400.jpeg"
        //        },
        //        new Region
        //        {
        //            Id= Guid.NewGuid(),
        //            Name="Willington Region",
        //            Code="AUCK",
        //            RegionImageUrl="https://images.pexels.com/photos/30421258/pexels-photo-30421258.jpeg"
        //        }
        //    };
        //return Ok(regions);
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Getting data from doman model
            var regions = await regionsRepository.GetAllAsync();

            var regionsDto = mapper.Map<List<RegionDto>>(regions);

            //var regionsDto = new List<RegionDto>();

            //foreach (var region in regions)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl
            //    });
            //}

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getByGuid([FromRoute] Guid id)
        {

            //var region = dbContext.Region.Find(guid);  // it wil check the primary key only

            var region = await regionsRepository.getByGuidAsync(id); // It is linQ methond (FirstOrDefault() 
                                                                     // here it is filtering with Id and get the first data)
            var regionsDto = mapper.Map<RegionDto>(region);
            
            if (regionsDto == null)
            {
                return NotFound();
            }
            return Ok(regionsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionRequestDto saveRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                Region regionModel = await regionsRepository.createRegionAsync(saveRegionRequestDto);
                //Map to regionDto to send to response
                var regionDto = mapper.Map<RegionDto>(regionModel);

                //Dto to the response with 201 status
                return CreatedAtAction(nameof(getByGuid), new { Id = regionDto.Id }, regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")] //do not give spaces
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {

            var region = await regionsRepository.updateRegionAsync(id, updateRegionDto);
            if (region == null) { return NotFound(); }

            return Ok(mapper.Map<RegionDto>(region));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            //var region = await dbContext.Region.FirstOrDefaultAsync(x => x.Id == id);
            var region = await regionsRepository.deleteByGuidAsync(id);
            if (region == null) { return NotFound(); }

            return Ok(mapper.Map<RegionDto>(region));
        }
    }
}
