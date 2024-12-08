using Microsoft.EntityFrameworkCore;

public class IplDbContext: DbContext{
    public DbSet<Player> Players {get; set;}
    public IplDbContext(DbContextOptions<IplDbContext> options) : base(options){ }
}