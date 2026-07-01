using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions) { 
        
        }

        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Walk> Walk { get; set; }
        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("5aa0232d-1f9b-4187-b008-96efd253ecbb"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("dfbefdbb-6e72-4610-b034-1a09868ce778"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("b02717f0-4d7f-453c-af23-09dc269fd1b9"),
                    Name = "Hard"
                }

            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);



            var regions = new List<Region>()
            {
                new Region()
                {
                    Id= Guid.Parse("543b5535-0316-44eb-954c-b4d5b61dadf7"),
                    Code="Midwest",
                    Name="East North Central",
                    RegionImageUrl="https://cdn.pixabay.com/photo/2025/12/08/13/36/portal-10002185_1280.jpg"
                },
                new Region()
                {
                    Id= Guid.Parse("9b53ce92-08dd-4f13-8ed7-99c2fe58cfe3"),
                    Code="South",
                    Name="South Atlantic",
                    RegionImageUrl="https://cdn.pixabay.com/photo/2025/12/07/09/01/abstract-9999854_1280.jpg"
                },
                new Region()
                {
                    Id= Guid.Parse("1519926d-7644-4215-b14b-9b6edf908b7e"),
                    Code="West",
                    Name="Mountain",
                    RegionImageUrl="https://cdn.pixabay.com/photo/2025/12/06/07/47/07-47-55-754_1280.jpg"
                },
                new Region()
                {
                    Id= Guid.Parse("d873260b-4231-47e2-8c2c-d174a91155a7"),
                    Code="Northeast",
                    Name="Mid-Atlantic",
                    RegionImageUrl="https://cdn.pixabay.com/photo/2025/12/07/09/01/earth-9999856_1280.jpg"
                },
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }

       
    }
}
