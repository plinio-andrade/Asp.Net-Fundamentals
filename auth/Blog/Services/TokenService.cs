using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Extensions;
using Blog.Models;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler(); // token handler instance
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); // byte array
        var claims = user.GetClaims();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            #region Fixed Claims
            // Subject = new ClaimsIdentity(new Claim[]{
            //     new Claim(ClaimTypes.Name, "plinioandrade"), // User.Identity.Name
            //     new Claim(ClaimTypes.Role, "user"), // User.IsInRole
            // }),              
            #endregion
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8), // time to expire token
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                     SecurityAlgorithms.HmacSha256Signature // algorithm to encrypt and decrypt token
            )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor); // create token

        return tokenHandler.WriteToken(token); // convert token to string
    }
}