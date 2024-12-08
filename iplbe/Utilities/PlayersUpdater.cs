using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

public class PlayersUpdater{
    public static async Task UpdatePlayersAsync(IplDbContext iplDbContext, string filePath)
    {
        var playersFromCsv = GetPlayers(filePath);
        
        // Get all players from the database
        var existingPlayers = await iplDbContext.Players.ToListAsync(); 

        Console.WriteLine(existingPlayers.Count); 

        // Insert or update players from CSV data
        foreach (var player in playersFromCsv)
        {
            var existingPlayer = existingPlayers.FirstOrDefault(p => p.Id == player.Id);

            if (existingPlayer != null)
            {
                // Update existing player data
                existingPlayer.Name = player.Name;
                existingPlayer.Team = player.Team;
                existingPlayer.Type = player.Type;
                existingPlayer.Price = player.Price;
                existingPlayer.IsForeigner = player.IsForeigner;
                existingPlayer.IsSpinner = player.IsSpinner;
                existingPlayer.IsFastBowler = player.IsFastBowler;
                existingPlayer.Opener = player.Opener;
                existingPlayer.Middle = player.Middle;
                existingPlayer.Finisher = player.Finisher;
                existingPlayer.Newball = player.Newball;
                existingPlayer.Death = player.Death;
                existingPlayer.Dependable = player.Dependable;
            }
            else
            {
                // Insert new player data
                await iplDbContext.Players.AddAsync(player);
            }
        }

        await iplDbContext.SaveChangesAsync(); 
    }

    public static List<Player> GetPlayers(string filePath){
        var players = new List<Player>(); 

        using(var reader = new StreamReader(filePath))
        using(var csv =  new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture))){
            var records = csv.GetRecords<Player>().ToList();
            players.AddRange(records);
        }

        return players; 
    }
}