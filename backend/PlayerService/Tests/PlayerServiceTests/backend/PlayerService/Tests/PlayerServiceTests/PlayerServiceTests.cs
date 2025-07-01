using Xunit;
using PlayerService.Models;
using PlayerService.Services;

namespace PlayerService.UnitTests;

public class PlayerServiceTests
{
    [Fact]
    public void CanAddPlayer()
    {
        var svc = new PlayerService.Services.PlayerService();
        var p   = svc.Add(new Player { Name = "Alice" });

        Assert.Equal(1, p.Id);
        Assert.Equal("Alice", p.Name);
    }
}
