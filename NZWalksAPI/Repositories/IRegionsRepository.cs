using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public interface IRegionsRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> getByGuidAsync(Guid id);
        Task<Region> createRegionAsync(SaveRegionRequestDto saveRegionRequestDto);
        Task<Region?> updateRegionAsync(Guid id, UpdateRegionDto updateRegionDto);
        Task<Region?> deleteByGuidAsync(Guid id);
    }
}
