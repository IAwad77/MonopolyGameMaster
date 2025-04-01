using Xunit;
using GameLogicService.Services;
using System.Collections.Generic;

namespace GameLogic.Unit;
public class GameLogicUnit
{
    [Fact]
    public void EndTurnCyclesPlayers()
    {
        var svc=new GameLogicService.Services.GameLogicService();
        svc.StartGame(new[]{"Ali","Sara"});
        var before=svc.GetState().CurrentPlayer;
        svc.EndTurn();
        var after =svc.GetState().CurrentPlayer;
        Assert.NotEqual(before,after);
    }
}
