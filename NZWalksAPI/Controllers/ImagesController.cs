using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;
        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }


        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequest request)
        {
            ValidateImage(request);

            if(ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = (int)request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,

                };
                //Implement repository
                await imageRepository.upload(imageDomainModel);
                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        private void ValidateImage(ImageUploadRequest request) {

            var validExtensions = new string[] { ".jpg", ".png" };

            if (!validExtensions.Contains(Path.GetExtension(request.File.FileName))){
                ModelState.AddModelError("File", "Please upload valid files");
            }

            if (request.File.Length > 10645730) {
                ModelState.AddModelError("key", "Image size should be below 10MB");
            }
        
        }
    }
}
