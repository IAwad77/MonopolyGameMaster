using Xunit;
using Moq;
using AuthService.Controllers;
using AuthService.Services;
using AuthService.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auth.ControllerTests;
public class AuthControllerTests
{
    [Fact]
    public void Login_Valid_Ok()
    {
        var m=new Mock<IAuthService>();
        m.Setup(x=>x.Authenticate(It.IsAny<AuthRequest>())).Returns("tok");
        var c=new AuthController(m.Object);
        var res=c.Login(new AuthRequest{Username="admin",Password="password"});
        Assert.IsType<OkObjectResult>(res.Result);
    }
}
