using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class StationController : ControllerBase
{
    private readonly AppDbContext _context;

    public StationController(AppDbContext context)
    {
        _context = context;
    }


}
