namespace NZWalksAPI.Models.DTO
{
    public class ImageUploadRequest
    {
        public string FileName { get; set; }
        public IFormFile File { get; set; }

        public string? FileDescription { get; set; }
    }
}
