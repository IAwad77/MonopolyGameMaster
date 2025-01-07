using PlayerService.Models;
using System.Collections.Generic;

namespace PlayerService.Services;

public interface IPlayerService
{
    IEnumerable<Player> GetAll();
    Player?  GetById(int id);
    Player   Add(Player p);
    void     UpdateBalance(int id, decimal newBalance);
}
