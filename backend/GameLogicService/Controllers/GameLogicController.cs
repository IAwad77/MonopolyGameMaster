using Microsoft.AspNetCore.Mvc;
using GameLogicService.Services;
using GameLogicService.Models;

namespace GameLogicService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameLogicController : ControllerBase
{
    private readonly IGameLogicService _svc;
    public GameLogicController(IGameLogicService s)=>_svc=s;

    [HttpGet] public ActionResult<GameState> Get() => Ok(_svc.GetState());

    [HttpPost("start")]
    public IActionResult Start([FromBody] List<string> players)
    { _svc.StartGame(players); return Ok(); }

    [HttpPost("endturn")]
    public IActionResult EndTurn()
    { _svc.EndTurn(); return Ok(); }
}
