using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO;


public class RegionDTO
{
    public RegionDTO(Region region)
    {
        this.RegionId = region.RegionId;
        this.RegionName = region.RegionName;
        this.RegionCode = region.RegionCode;
        this.RegionImgUrl = region.RegionImgUrl;
    }
    public Guid RegionId { get; set; }
    public string RegionCode { get; set; }
    public string RegionName { get; set; }
    public string? RegionImgUrl { get; set; }

}