using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CrateWalk(Walk walk);

        Task<List<Walk>> GelAllWalk(String? filterOn = null, String? filterQuery = null, String? soryBy = null, Boolean isAscending = false, int pageNumber = 1, int pageSize = 1000);

        Task<Walk> GetWalkById(Guid id);
        Task<WalkDto> UpdateWalkById(Guid id, UpdateWalkDto walkDto);
        Task<Walk?> DeleteWalkById(Guid id);
    }
}
