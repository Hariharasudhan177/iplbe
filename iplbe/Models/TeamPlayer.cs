using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(UserId), nameof(PlayerId))]
public class TeamPlayer{
    public Guid UserId{get; set;}
    public virtual User user { get; set; } 
    public int PlayerId{get; set;}
    public virtual Player Player { get; set; }
    public int Order{get; set;}

}