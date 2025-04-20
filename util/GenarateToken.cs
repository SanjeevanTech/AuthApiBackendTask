using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetEnv; 
using Microsoft.IdentityModel.Tokens;

using _.Models;

namespace _.util
{
    public static class TokenHelper
    {
        public static string GenerateJwtToken(User user)
        {
            
            Env.Load();
            
            
            var secretKey = Env.GetString("JWT_SECRET_KEY");
            var issuer = Env.GetString("JWT_ISSUER");
            var audience = Env.GetString("JWT_AUDIENCE");
            var expiryHours = 4;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            
    
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("userId", user.Id!),
                new Claim(ClaimTypes.Role, user.Role ?? "User"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
            };

            
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expiryHours),
                signingCredentials: credentials
            );

            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}