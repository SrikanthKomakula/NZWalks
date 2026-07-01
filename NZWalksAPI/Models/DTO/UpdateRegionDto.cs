using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class UpdateRegionDto
    {
        [Required]
        [MaxLength(3,ErrorMessage = "Should be 3 characters only")]
        [MinLength(3,ErrorMessage = "Should be 3 characters only")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
