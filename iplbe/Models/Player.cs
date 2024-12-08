using System.ComponentModel.DataAnnotations.Schema;

public class Player{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id {get; set;}
    public string Name {get; set;}
    public string Team {get; set;}
    public string Type {get; set;}
    public float Price{get; set;}
    public bool IsForeigner{get; set;}
    public bool IsSpinner { get; set; }
    public bool IsFastBowler { get; set; }
    public int Opener { get; set; }
    public int Middle { get; set; }
    public int Finisher { get; set; }
    public int Newball { get; set; }
    public int Death { get; set; }
    public int Dependable { get; set; }
}