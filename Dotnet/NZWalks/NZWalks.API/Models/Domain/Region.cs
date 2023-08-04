namespace NZWalks.API.Models.Domain
{
    public class Region
    {
        public Guid RegionId { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string? RegionImgUrl { get; set; }
    }
}