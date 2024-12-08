using Microsoft.AspNetCore.Mvc;

namespace FantasyLeagueAPI.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IplDbContext iplDbContext;
        private readonly PlayerService playerService; 

        public PlayerController(IplDbContext iplDbContext, PlayerService playerService)
        {
            this.iplDbContext = iplDbContext;
            this.playerService = playerService; 
        }

        [HttpPost("updatefromcsv")]
        public async Task<IActionResult> UpdatePlayersFromCsv()
        {
            string filePath = "Data/Players.csv";
            await PlayersUpdater.UpdatePlayersAsync(iplDbContext, filePath);
            return Ok("Players updated from CSV.");
        }

        [HttpGet("getallplayers")]
        public async Task<IActionResult> GetAllPlayers(){
            var players = await playerService.GetPlayersAsync(); 
            return Ok(players); 
        }
    }
}
