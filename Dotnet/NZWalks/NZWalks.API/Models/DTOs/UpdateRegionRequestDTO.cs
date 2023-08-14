using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO;


public class UpdateRegionRequestDTO
{
    public UpdateRegionRequestDTO()
    {

    }
    public string RegionCode { get; set; }
    public string RegionName { get; set; }
    public string? RegionImgUrl { get; set; }

}