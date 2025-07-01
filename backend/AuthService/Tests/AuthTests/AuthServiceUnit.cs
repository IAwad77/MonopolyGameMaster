using Xunit;
using AuthService.Services;
using AuthService.Models;

namespace Auth.Unit;
public class AuthServiceUnit
{
    [Fact] public void ValidCreds_ReturnToken()
    {
        var s=new AuthService.Services.AuthService();
        var tok=s.Authenticate(new AuthRequest{Username="admin",Password="password"});
        Assert.False(string.IsNullOrEmpty(tok));
    }

    [Fact] public void InvalidCreds_ReturnEmpty()
    {
        var s=new AuthService.Services.AuthService();
        var tok=s.Authenticate(new AuthRequest{Username="bad",Password="bad"});
        Assert.Equal("",tok);
    }
}
