using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        string[] students = new string[] { "John", "Mary", "Bob" };
        return Ok(students);
    }
}
