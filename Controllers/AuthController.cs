using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc; 

using _.Models;
using _.util;
using _.DTOS;


namespace _.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMongoDatabase database) : ControllerBase
    {
        private readonly IMongoCollection<User> _userCollection = database.GetCollection<User>("Users");

        //admin
            
        [HttpPost("adminRegister")]
        public async Task<IActionResult> RegisterAdmin([FromBody] AdminRegistrationRequest request)
        {
        
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest("Invalid input. Please provide username, email, and password.");
            }

        
            var existingUser = await _userCollection
                .Find(u => u.Username == request.Username || u.Email == request.Email)
                .FirstOrDefaultAsync();

            if (existingUser != null)
            {
                return Conflict("Username or email already taken.");
            }

            
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            
            var newUser = new User
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Role = "Admin", 
                Password = hashedPassword  
            };

            
            await _userCollection.InsertOneAsync(newUser);
        

            return CreatedAtAction(nameof(RegisterAdmin), new { id = newUser.Username }, new
            {
                Message = "Admin Registration is successfully created!",
                User = newUser
            });
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationRequest request)
        {
        
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest("Invalid input. Please provide username, email, and password.");
            }

        
            var existingUser = await _userCollection
                .Find(u => u.Username == request.Username || u.Email == request.Email)
                .FirstOrDefaultAsync();

            if (existingUser != null)
            {
                return Conflict("Username or email already taken.");
            }

            
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            
            var newUser = new User
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Role = "User", 
                Password = hashedPassword  
            };

            
            await _userCollection.InsertOneAsync(newUser);
        

            return CreatedAtAction(nameof(RegisterUser), new { id = newUser.Username }, new
            {
                Message = "Registration is successfully created!",
                User = newUser
            });
        }


        // log in

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Invalid input. Please provide username and password.");
            }

            // Find user by username
            var existingUser = await _userCollection
                .Find(u => u.Username == request.Username)
                .FirstOrDefaultAsync();

            if (existingUser == null)
            {
                return Conflict("Invalid username.");
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, existingUser.Password);

            if (!isPasswordValid)
            {
                return Unauthorized("Invalid password.");
            }

            var token = TokenHelper.GenerateJwtToken(existingUser);
            Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true, // Makes it secure from JavaScript (prevents XSS)
                    Secure = false,    // Only sends over HTTPS
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddDays(1)
                });
            return Ok(new
            {
                
                Message = "Login successful!",
                Token = token
                
            });
        }


    }


    


    
}
