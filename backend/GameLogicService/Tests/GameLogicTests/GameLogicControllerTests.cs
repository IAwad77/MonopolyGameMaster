using Xunit;
using Moq;
using GameLogicService.Controllers;
using GameLogicService.Services;
using GameLogicService.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameLogic.ControllerTests;
public class GameLogicControllerTests
{
    [Fact]
    public void Get_ReturnsState()
    {
        var m=new Mock<IGameLogicService>();
        m.Setup(s=>s.GetState()).Returns(new GameState());
        var c=new GameLogicController(m.Object);
        Assert.IsType<OkObjectResult>(c.Get());
    }
}
