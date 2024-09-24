using MapIM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapIM.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    private readonly MapimDataContext _context;

    public CategoryController(MapimDataContext context) => _context = context;


    [HttpGet("v1/api/categories")]
    public async Task<IActionResult> GeyAsync()
    {
        var categories = await _context.Categories.AsNoTracking().ToListAsync();
        return Ok(categories);
    }
}
