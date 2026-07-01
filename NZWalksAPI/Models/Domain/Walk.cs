namespace NZWalksAPI.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public double LengthInKm { get; set; }
        public string WalkImageUrl { get; set; }

        /** Navigational Properties */
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
