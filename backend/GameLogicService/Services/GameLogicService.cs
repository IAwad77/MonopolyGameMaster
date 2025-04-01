using GameLogicService.Models;
using System.Collections.Generic;

namespace GameLogicService.Services;

public class GameLogicService : IGameLogicService
{
    private readonly GameState _state = new();

    public GameState GetState() => _state;
    public void EndTurn() => _state.EndTurn();
    public void StartGame(IEnumerable<string> players) => _state.ResetPlayers(players);
}
