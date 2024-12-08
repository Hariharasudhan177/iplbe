using Microsoft.EntityFrameworkCore;

public class PlayerService{

    private readonly IplDbContext iplDbContext; 

    public PlayerService(IplDbContext iplDbContext){
        this.iplDbContext = iplDbContext; 
    }

    public async Task<List<PlayerDto>> GetPlayersAsync(){
        var players = await iplDbContext.Players
        .OrderBy(p => p.Name)
        .Select(p => new PlayerDto{
            Id = p.Id,
            Name = p.Name,
            Team = p.Team,
            Type = p.Type,
            Price = p.Price,
            IsForeigner = p.IsForeigner,
            IsSpinner = p.IsSpinner,
            IsFastBowler = p.IsFastBowler,
            IsOpener = p.Opener > 10,
            IsMiddle = p.Middle > 10,
            IsFinisher = p.Finisher > 10,
            IsNewball = p.Newball > 10,
            IsDeath = p.Death > 10,
            IsDependable = p.Dependable > 10,
            IsBatter = p.Type.Contains("BAT"),
            IsBowler = p.Type.Contains("BOWL"),
            IsAllRounder = p.Type.Contains("AR"),
            IsWicketKeeperBatsman = p.Type.Contains("WKBAT"),
        })
        .ToListAsync(); 
        return players; 
    }
}