using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public class SQLWalkRepository: IWalkRepository
    {
        public SQLWalkRepository(NZWalksDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public NZWalksDbContext DbContext { get; }
        public IMapper Mapper { get; }

        public async Task<Walk> CrateWalk(Walk walk)
        {
            await DbContext.Walk.AddAsync(walk);
            await DbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GelAllWalk(String? filterOn = null, String? filterQuery= null, String sortBy = null, Boolean isAsending = false, int pageNumber = 1, int pageSize = 1000)
        {
            var walk  = DbContext.Walk.Include(w=>w.Difficulty).Include(w=>w.Region).AsQueryable();

            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                    walk = walk.Where(x => x.Name.Contains(filterQuery));
                }
            }

            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walk = isAsending ? walk.OrderBy(x => x.Name) : walk.OrderByDescending(x=>x.Name);
                }
            }

            var skipResults = (pageNumber - 1) * pageSize;
            return await walk.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> GetWalkById(Guid id){
            return await DbContext.Walk.Include(x=>x.Difficulty).Include(y=>y.Region).FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<WalkDto?> UpdateWalkById(Guid id, UpdateWalkDto walkDto)
        {
            var walk = await DbContext.Walk.FirstOrDefaultAsync(x => x.Id == id);
            if(walk == null)
            {
                return null;
            }
            walk.Name = walkDto.Name;
            walk.MyProperty = walkDto.MyProperty;
            walk.LengthInKm = walkDto.LengthInKm;
            walk.WalkImageUrl = walkDto.WalkImageUrl;
            await DbContext.SaveChangesAsync();


            return Mapper.Map<WalkDto>(walk);

        }

        public async Task<Walk?> DeleteWalkById(Guid id)
        {
            var walk = await DbContext.Walk.FirstOrDefaultAsync(x => x.Id == id);
            if(walk == null)
            {
                return walk;
            }

            DbContext.Walk.Remove(walk);
            await DbContext.SaveChangesAsync();
            return walk;
        }
    }
}
