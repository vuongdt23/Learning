namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string WalkName { get; set; }
        public string WalkDescription { get; set; }
        public string? WalkImgUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }


    }
}