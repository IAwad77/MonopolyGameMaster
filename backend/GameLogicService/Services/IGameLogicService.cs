using GameLogicService.Models;
using System.Collections.Generic;

namespace GameLogicService.Services;

public interface IGameLogicService
{
    GameState GetState();
    void      EndTurn();
    void      StartGame(IEnumerable<string> players);
}
