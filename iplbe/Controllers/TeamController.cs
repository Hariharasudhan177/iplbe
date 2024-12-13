using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq; 

[ApiController]
[Route("api/team")]
public class TeamController: ControllerBase{
    private readonly IplDbContext iplDbContext; 
    public TeamController(IplDbContext iplDbContext){
        this.iplDbContext = iplDbContext; 
    }

    [HttpGet("getteam")]
    public async Task<IActionResult> GetTeam(Guid userId){

        return Ok(iplDbContext.TeamsPlayers
                .Where(tp => tp.UserId == userId)
                .OrderBy(tp => tp.Order)); 
    }

    [HttpPost("addplayer")]
    public async Task<IActionResult> AddPlayer(AddOrUpdatePlayer addPlayer){
        TeamPlayer teamPlayer = new TeamPlayer{
            UserId = Guid.Parse(addPlayer.UserId),
            PlayerId = addPlayer.PlayerId,
            Order = addPlayer.Order
        };
        iplDbContext.TeamsPlayers.Add(teamPlayer);
        await iplDbContext.SaveChangesAsync(); 
        return Ok(); 
    }

    [HttpPost("deleteplayer")]
    public async Task<IActionResult> DeletePlayer(AddOrUpdatePlayer addPlayer){
        TeamPlayer teamPlayer = await iplDbContext.TeamsPlayers.FirstOrDefaultAsync(
            tp => tp.UserId == Guid.Parse(addPlayer.UserId) && tp.PlayerId == addPlayer.PlayerId);
        
        if(teamPlayer == null){
            return NotFound("Player not found");
        }

        iplDbContext.TeamsPlayers.Remove(teamPlayer);
        await iplDbContext.SaveChangesAsync();
        return Ok(); 
    }

    [HttpPost("updateplayer")]
    public async Task<IActionResult> UpdatePlayer(AddOrUpdatePlayer addPlayer){
        TeamPlayer teamPlayer = await iplDbContext.TeamsPlayers.FirstOrDefaultAsync(
            tp => tp.UserId == Guid.Parse(addPlayer.UserId) && tp.PlayerId == addPlayer.PlayerId);
        
        if(teamPlayer == null){
            return NotFound("Player not found");
        }

        teamPlayer.Order = addPlayer.Order; 
        await iplDbContext.SaveChangesAsync();
        return Ok(); 
    }
}