using Microsoft.AspNetCore.Mvc;
using yorg.Repository.Interface;
using yorg.Model;
using Google.Apis.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using YourProject.Helpers;
using System.Threading.Tasks;

namespace yorg.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository userRepository;
    private readonly JwtHelper _jwtHelper;

    public AuthController(IUserRepository userRepository, JwtHelper jwtHelper)
    {
        this.userRepository = userRepository;
        _jwtHelper = jwtHelper;
    }

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] SignInDto request)
    {
        try
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new List<string> { "YOUR_GOOGLE_CLIENT_ID" }  
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.Token, settings);

            var existingUser = await userRepository.GetUserByGoogleId(payload.JwtId);
            if (existingUser == null)
            {
             
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = payload.Name,
                    Email = payload.Email,
                    Role = "User",
                    GoogleId = payload.Subject,  
                    ProfilePictureUrl = payload.Picture, 
                    Locale = payload.Locale
                };
                userRepository.AddUser(user);
                return Ok(new { Message = "Google login successful!", Token = _jwtHelper.GenerateToken(user) });
            }
            else
            {
                // Existing user, generate JWT token
                return Ok(new { Message = "Google login successful!", Token = _jwtHelper.GenerateToken(existingUser) });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Invalid Google token", Error = ex.Message });
        }
    }

    [HttpPost("apple-login")]
    public async Task<IActionResult> AppleLogin([FromBody] SignInDto request)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(request.Token);

            var emailClaim = token.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
            var userId = token.Claims.FirstOrDefault(c => c.Type == "sub")?.Value; 

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid Apple token");
            }

          
            var existingUser = await userRepository.GetUserByAppleId(userId);
            if (existingUser == null)
            {
               
                var user = new User
                {
                    Name = token.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? "Apple User",
                    Email = emailClaim ?? $"{userId}@apple.com",  
                    Role = "User",
                    AppleId = userId  // Store the Apple user ID
                };
                userRepository.AddUser(user);
                return Ok(new { Message = "Apple login successful!", Token = _jwtHelper.GenerateToken(user) });
            }
            else
            {
                // Existing user, generate JWT token
                return Ok(new { Message = "Apple login successful!", Token = _jwtHelper.GenerateToken(existingUser) });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Invalid Apple token", Error = ex.Message });
        }
    }
}

public class SignInDto
{
    public string Token { get; set; }
}
