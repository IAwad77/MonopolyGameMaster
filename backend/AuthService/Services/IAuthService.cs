using AuthService.Models;
namespace AuthService.Services;
public interface IAuthService
{
    string Authenticate(AuthRequest req);
}
