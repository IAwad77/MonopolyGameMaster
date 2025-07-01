using Microsoft.AspNetCore.Mvc;
using PlayerService.Models;
using PlayerService.Services;

namespace PlayerService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _svc;
    public PlayerController(IPlayerService s)=>_svc=s;

    [HttpGet] public ActionResult<IEnumerable<Player>> GetAll() => Ok(_svc.GetAll());

    [HttpGet("{id:int}")] public ActionResult<Player> Get(int id)
        => _svc.GetById(id) is { } p ? Ok(p) : NotFound();

    [HttpPost] public ActionResult<Player> Add(Player p)
    {
        var added=_svc.Add(p);
        return CreatedAtAction(nameof(Get), new{ id=added.Id }, added);
    }

    [HttpPut("{id:int}/balance")] public IActionResult PutBal(int id,[FromBody]decimal bal)
    { _svc.UpdateBalance(id,bal); return NoContent(); }
}
