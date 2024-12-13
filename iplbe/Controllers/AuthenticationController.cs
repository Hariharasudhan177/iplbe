using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FantasyLeagueAPI.Controllers{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController: ControllerBase{
        private readonly IplDbContext iplDbContext; 
        public AuthenticationController(IplDbContext iplDbContext){
            this.iplDbContext = iplDbContext; 
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUp signUp){
            Console.WriteLine("Hari");
            User chechEmailExists = iplDbContext.Users.FirstOrDefault(u => u.Email == signUp.Email);
            if(chechEmailExists != null){
                return BadRequest("Email already registered!");
            }

            User checkTeamNameExists = iplDbContext.Users.FirstOrDefault(u => u.TeamName == signUp.Teamname);
            if(checkTeamNameExists != null){
                return BadRequest("Team name already exists!"); 
            }

            signUp.Password = BCrypt.Net.BCrypt.HashPassword(signUp.Password);
            Guid userId = Guid.NewGuid(); 
            Guid teamId = Guid.NewGuid(); 
            User user = new User(){
                Id = userId,
                Email = signUp.Email,
                PasswordHash = signUp.Password,
                IsVerified = false,
                VerificationToken = Guid.NewGuid().ToString(),
                ResetToken = Guid.NewGuid().ToString(),
                ResetTokenExpiry = DateTime.UtcNow.AddHours(1),
                TeamName = signUp.Teamname
            };
            iplDbContext.Users.Add(user);
            await iplDbContext.SaveChangesAsync();  
            return Ok(); 
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignIn singIn){
            User userFromDb = iplDbContext.Users.FirstOrDefault(u => u.Email == singIn.Email);
            
            if(userFromDb == null){
                return BadRequest("Email not registered!");    
            }
            
            if(!BCrypt.Net.BCrypt.Verify(singIn.Password, userFromDb.PasswordHash)){
                return BadRequest("Wrong password!"); 
            }

            var tokenHandler = new JwtSecurityTokenHandler(); 
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(new[] 
                { 
                    new Claim("id", userFromDb.Id.ToString()),
                    new Claim("name", userFromDb.TeamName.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("YourVeryStrongAndSecureSecretKey123456!")), SecurityAlgorithms.HmacSha256Signature)
            }); 
            
            return Ok(new { Token = tokenHandler.WriteToken(token)});
        }
    }
}