using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalksAPI.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext

    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerGuid = "7f3fdb59-453a-4af1-a3d3-8305f1850f2d";
            var writerGuid = "491e94c1-5371-4031-be69-2ea10a22aebb";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerGuid,
                    ConcurrencyStamp = readerGuid,
                    Name = "Reader",
                    NormalizedName = "Reader"
                },
                new IdentityRole
                {
                    Id = writerGuid,
                    ConcurrencyStamp = writerGuid,
                    Name = "Writer",
                    NormalizedName = "Writer"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);


        }
    }
}
