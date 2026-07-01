using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class LocalImageUploadRepository : IImageRepository
    {
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly NZWalksDbContext dbContext;

        public LocalImageUploadRepository(IWebHostEnvironment webHostEnvironment, 
            IHttpContextAccessor httpContextAccessor,
            NZWalksDbContext dbContext)
        {
            this.WebHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }


        public async Task<Image> upload(Image image)
        {

            //Image folder created
            //add logic to upload image in local file folder

            //get the ImageFolder
            var localImagePath = Path.Combine(WebHostEnvironment.ContentRootPath, 
                "Images", $"{image.FileName}{image.FileExtension}");


            //save using fileStream
            using var stream = new FileStream(localImagePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            //get the url path of the file
            // referece path https://localhost:4200/Images/filename
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{ httpContextAccessor.HttpContext.Request.Host}{ httpContextAccessor.HttpContext.Request.PathBase}/Images/{ image.FileName}{ image.FileExtension}";
                
            image.FilePath = urlFilePath;

            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;
        }
    }
}
