using PlayerService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlayerService.Services;

public class PlayerService : IPlayerService
{
    private readonly List<Player> _players = new();
    private int _nextId = 1;

    public IEnumerable<Player> GetAll() => _players;

    public Player? GetById(int id) => _players.FirstOrDefault(p => p.Id == id);

    public Player Add(Player p)
    {
        p.Id = _nextId++;
        _players.Add(p);
        return p;
    }

    public void UpdateBalance(int id, decimal newBalance)
    {
        var p = GetById(id);
        if (p != null) p.Balance = newBalance;
    }
}
