using AuthService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services;

public class AuthService : IAuthService
{
    private const string SECRET = "your_secret_key_123456";   // TODO env var

    public string Authenticate(AuthRequest r)
    {
        if (r.Username != "admin" || r.Password != "password") return "";

        var key   = Encoding.ASCII.GetBytes(SECRET);
        var creds = new SigningCredentials(new SymmetricSecurityKey(key),
                                           SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: new[] { new Claim(ClaimTypes.Name, r.Username) },
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
