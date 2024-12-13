using Microsoft.EntityFrameworkCore;

public class IplDbContext: DbContext{
    public DbSet<Player> Players {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<TeamPlayer> TeamsPlayers {get; set;}
    public IplDbContext(DbContextOptions<IplDbContext> options) : base(options){ }
}