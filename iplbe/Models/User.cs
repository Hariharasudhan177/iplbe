using System.ComponentModel.DataAnnotations.Schema;

public class User{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id {get; set;}
    public string Email {get; set;}
    public string PasswordHash{get; set;}
    public bool IsVerified{get; set;}
    public string VerificationToken{get; set;}
    public string ResetToken{get; set;}
    public DateTime? ResetTokenExpiry{get; set; }
    public string TeamName {get; set;}
}