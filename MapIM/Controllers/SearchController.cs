using MapIM.Data;
using MapIM.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapIM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly MapimDataContext _context;

    public SearchController(MapimDataContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public async Task<IActionResult> SearchAsync([FromQuery] string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return BadRequest("A query must be provided");
        }

        var departmentsTask = _context.Departments
        .Where(x => x.Name.Contains(query))
        .Select(x => new SearchResultViewModel { Id = x.Id, Name = x.Name, Type = "Departmento" });

        var roomsTask = _context.Rooms
            .Where(x => x.Name.Contains(query))
            .Select(x => new SearchResultViewModel { Id = x.Id, Name = x.Name, Type = "Sala" });

        var categoriesTask = _context.Categories
            .Where(x => x.Name.Contains(query))
            .Select(x => new SearchResultViewModel { Id = x.Id, Name = x.Name, Type = "Categoria" });

        var professorsTask = _context.Professors
            .Where(x => x.Name.Contains(query))
            .Select(x => new SearchResultViewModel { Id = x.Id, Name = x.Name, Type = "Professor" });

        var floorsTask = _context.Floors
            .Where(x => x.Name.Contains(query))
            .Select(x => new SearchResultViewModel { Id = x.Id, Name = x.Name, Type = "Andar" });

        var unifiedResults = await departmentsTask
               .Union(roomsTask)
               .Union(categoriesTask)
               .Union(professorsTask)
               .Union(floorsTask)
               .ToListAsync();

        return Ok(unifiedResults);
    }

}
