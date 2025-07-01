using Microsoft.AspNetCore.Mvc;
using AuthService.Models;
using AuthService.Services;

namespace AuthService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _svc;
    public AuthController(IAuthService s)=>_svc=s;

    [HttpPost("login")]
    public ActionResult<AuthResponse> Login([FromBody] AuthRequest r)
    {
        var tok=_svc.Authenticate(r);
        if(string.IsNullOrEmpty(tok)) return Unauthorized();
        return Ok( new AuthResponse{ Token=tok } );
    }
}
