using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class SaveRegionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage = "Should be 3 characters only")]
        [MaxLength(3, ErrorMessage = "Should be 3 characters only")]
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
