using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase
{
    private NZWalksDbContext dbContext;
    public RegionsController(NZWalksDbContext dbContext)
    {
         this.dbContext = dbContext;
    }

    [HttpGet] 
    public IActionResult GetAll()
    {
        List<RegionDTO> regions = new List<RegionDTO>();
        List<Region> regionsDomain = dbContext.Regions.ToList();    

        foreach(var region in regionsDomain)
        {
            regions.Add(new RegionDTO(region));
        }
        
        return Ok(regions);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(Guid id)
    {
        Region region = dbContext.Regions.Find(id);
        if(region == null) {
            return NotFound();
        }
        return Ok(dbContext.Regions.Find(id));
    }

    [HttpPost]
    [Route("create")]
    public IActionResult Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
    {
        var regionDomainModel = new Region
        {
            RegionCode = addRegionRequestDTO.RegionCode,
            RegionName = addRegionRequestDTO.RegionName,
            RegionImgUrl = addRegionRequestDTO.RegionImgUrl,
        };

        RegionDTO dto = new RegionDTO(regionDomainModel);

        dbContext.Regions.Add(regionDomainModel);
        dbContext.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {id = regionDomainModel.RegionId}, dto);
    }

    [HttpPut] 
    [Route("{id:Guid}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
    {
        var region = dbContext.Regions.FirstOrDefault(x => x.RegionId == id);
        if(region == null )
        {
            return NotFound();
        }
        region.RegionCode = updateRegionRequestDTO.RegionCode;
        region.RegionName = updateRegionRequestDTO.RegionName;
        region.RegionImgUrl = updateRegionRequestDTO.RegionImgUrl;

        dbContext.SaveChanges();

        RegionDTO dTO = new RegionDTO(region);
        return (Ok(dTO)); 
         
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var region = dbContext.Regions.FirstOrDefault(x => x.RegionId == id);
        if (region == null)
        {
            return NotFound();
        }
        
        dbContext.Regions.Remove(region);

        dbContext.SaveChanges();

        RegionDTO dTO = new RegionDTO(region);
        return (Ok(dTO));

    }
}
