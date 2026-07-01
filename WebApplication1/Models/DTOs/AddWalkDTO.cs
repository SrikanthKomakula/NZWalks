namespace NZWalks.UI.Models.DTOs
{
    public class AddWalkDTO
    {
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public double LengthInKm { get; set; }
        public string WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
