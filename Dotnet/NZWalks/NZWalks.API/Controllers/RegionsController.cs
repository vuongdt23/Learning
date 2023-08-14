using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<IActionResult> GetAll()
    {
        List<RegionDTO> regions = new List<RegionDTO>();
        List<Region> regionsDomain = await dbContext.Regions.ToListAsync();

        foreach(var region in regionsDomain)
        {
            regions.Add(new RegionDTO(region));
        }
        
        return Ok(regions);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Region region = await dbContext.Regions.FindAsync(id);
        if(region == null) {
            return NotFound();
        }
        return Ok(dbContext.Regions.Find(id));
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
    {
        var regionDomainModel = new Region
        {
            RegionCode = addRegionRequestDTO.RegionCode,
            RegionName = addRegionRequestDTO.RegionName,
            RegionImgUrl = addRegionRequestDTO.RegionImgUrl,
        };

        RegionDTO dto = new RegionDTO(regionDomainModel);

        await dbContext.Regions.AddAsync(regionDomainModel);
        await dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = regionDomainModel.RegionId}, dto);
    }

    [HttpPut] 
    [Route("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
    {
        var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.RegionId == id);
        if(region == null )
        {
            return NotFound();
        }
        region.RegionCode = updateRegionRequestDTO.RegionCode;
        region.RegionName = updateRegionRequestDTO.RegionName;
        region.RegionImgUrl = updateRegionRequestDTO.RegionImgUrl;

        await dbContext.SaveChangesAsync();

        RegionDTO dTO = new RegionDTO(region);
        return (Ok(dTO)); 
         
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.RegionId == id);
        if (region == null)
        {
            return NotFound();
        }
        
        dbContext.Regions.Remove(region);

        await dbContext.SaveChangesAsync();

        RegionDTO dTO = new RegionDTO(region);
        return (Ok(dTO));

    }
}
