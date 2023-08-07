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
}
