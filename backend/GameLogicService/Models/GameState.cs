namespace GameLogicService.Models;

public class GameState
{
    public Queue<string> PlayerTurns { get; private set; } = new();

    public string CurrentPlayer => PlayerTurns.Count > 0 ? PlayerTurns.Peek() : "";

    public void EndTurn()
    {
        if (PlayerTurns.Count == 0) return;
        var p = PlayerTurns.Dequeue();
        PlayerTurns.Enqueue(p);
    }

    public void ResetPlayers(IEnumerable<string> players)
        => PlayerTurns = new Queue<string>(players);
}
