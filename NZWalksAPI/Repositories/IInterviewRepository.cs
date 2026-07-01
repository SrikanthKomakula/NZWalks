using Microsoft.OpenApi.Any;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public interface IInterviewRepository
    {

        public Task<List<WalkRegionDto>> GetAllWalks();

    }
}
