using Microsoft.AspNetCore.Mvc;
using FileParserService.Services;
using Microsoft.AspNetCore.Http;

namespace FileParserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileParserController : ControllerBase
{
    private readonly IFileParserService _svc;
    public FileParserController(IFileParserService s)=>_svc=s;

    [HttpPost("parse")]
    public async Task<IActionResult> Parse(IFormFile file)
    {
        if(file is null || file.Length==0) return BadRequest("Invalid file");
        using var r=new StreamReader(file.OpenReadStream());
        var txt=await r.ReadToEndAsync();
        var players=_svc.ParsePlayerCsv(txt);
        return Ok(players);
    }
}
