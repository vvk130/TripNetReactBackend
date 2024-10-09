using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Journey> Journeys { get; set; }
    public DbSet<Station> Stations { get; set; }
}
