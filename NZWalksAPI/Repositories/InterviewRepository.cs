using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using NZWalksAPI.Data;
using NZWalksAPI.Helpers;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using System.Threading.Tasks;

namespace NZWalksAPI.Repositories
{
    public class InterviewRepository: IInterviewRepository
    {
        private readonly NZWalksDbContext _dbContext;
        public InterviewRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //example of query based linQ
        public async Task<List<WalkRegionDto>> GetAllWalks()
        {
            //var walk = from w in _dbContext.Walk
            //           join r in _dbContext.Region
            //           on w.Region.Id equals r.Id
            //           group new { w,r} by r.Name into g
            //           select new WalkRegionDto
            //           {
            //               WalkName = g.Key,
            //               RegionName = String.Join(", ", g.Select(x=>x.w.Name))
            //           };



            //method based linq
            var walk = _dbContext.Walk.Join(_dbContext.Region,
            w => w.Region.Id,
                r => r.Id,
                (w, r) => new WalkRegionDto
                {
                    WalkName = w.Name,
                    RegionName = r.Name.RightSubstring(1)
                }).GroupBy(x => x.RegionName).
                Select(g => new WalkRegionDto
                {
                    RegionName = g.Key,
                    WalkName = string.Join(", ", g.Select(h => h.WalkName))
                });

            return await walk.ToListAsync();
        }
    }
}
