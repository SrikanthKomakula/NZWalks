using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public class SQLRegionsRepository: IRegionsRepository
    {
        public SQLRegionsRepository(NZWalksDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public NZWalksDbContext DbContext { get; }
        public IMapper Mapper { get; }

        public async Task<List<Region>> GetAllAsync()
        {
            return await DbContext.Region.ToListAsync();
        }

        public async Task<Region?> getByGuidAsync(Guid id)
        {
            return await DbContext.Region.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> createRegionAsync(SaveRegionRequestDto saveRegionRequestDto)
        {
            //Map request DTO to Domain with Automapper
            var regionModel = Mapper.Map<Region>(saveRegionRequestDto);
            //Map request DTO to Domain with manula
            //var regionModel = new Region
            //{
            //    Name = saveRegionRequestDto.Name,
            //    Code = saveRegionRequestDto.Code,
            //    RegionImageUrl = saveRegionRequestDto.RegionImageUrl
            //};

            //Save Domain Model to Database
            await DbContext.Region.AddAsync(regionModel);
            await DbContext.SaveChangesAsync();
            return regionModel;

        }

        public async Task<Region?> updateRegionAsync(Guid id, UpdateRegionDto updateRegionDto)
        {
            var region = await getByGuidAsync(id);

            if(region == null)
            {
                return null;
            }



            region.Name = updateRegionDto.Name;
            region.RegionImageUrl = updateRegionDto.RegionImageUrl;
            await DbContext.SaveChangesAsync();

            return Mapper.Map<Region>(region);
            

        }

        public async Task<Region?> deleteByGuidAsync(Guid id)
        {
            var region = await getByGuidAsync(id);
            if(region == null)
            {
                return region;
            }

             DbContext.Region.Remove(region);
             await DbContext.SaveChangesAsync();
            return region;
        }
    }
}
