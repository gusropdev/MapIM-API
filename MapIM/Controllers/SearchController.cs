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

        var professorsTask = _context.Professors
            .Where(x => x.Name.Contains(query))
            .Select(x => new SearchResultViewModel { Id = x.Id, Name = x.Name, Type = "Professor" });

        var unifiedResults = await departmentsTask
               .Union(roomsTask)
               .Union(professorsTask)
               .ToListAsync();

        return Ok(unifiedResults);
    }

    [HttpGet("details")]
    public async Task<IActionResult> GetRoomDetailsAsync([FromQuery] int entityId, [FromQuery] string entityType)
    {
        object result = null;

        switch (entityType.ToLower())
        {
            case "professor":
                var professor = await _context.Professors
                    .Include(x => x.Room)
                    .FirstOrDefaultAsync(x => x.Id == entityId);

                if (professor == null || professor.Room == null)
                    return NotFound("Professor ou Sala não encontrados.");

                result = new
                {
                    RoomId = professor.Room.Id,
                    RoomSlug = professor.Room.Slug
                };
                break;


            case "sala":
                var room = await _context.Rooms
                    .FirstOrDefaultAsync(x => x.Id == entityId);

                if (room == null)
                    return NotFound("Sala não encontrada");

                result = new
                {
                    RoomId = room.Id,
                    RoomSlug = room.Slug
                };
                break;

            case "departamento":
                var department = await _context.Departments
                    .Include(x => x.Rooms)
                    .FirstOrDefaultAsync(x => x.Id == entityId);

                if (department == null || !department.Rooms.Any())
                    return NotFound("Departamento ou salas não encontradas.");

                result = new
                {
                    Rooms = department.Rooms.Select(x => new { x.Id, x.Slug })
                };
                break;


            default:
                return BadRequest();
        }

        return Ok(result);
    }
}
