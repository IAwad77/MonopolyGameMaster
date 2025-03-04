using Microsoft.AspNetCore.Mvc;
using PropertyService.Models;
using PropertyService.Services;

namespace PropertyService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly PropertyService.Services.PropertyService _svc;
    public PropertyController(PropertyService.Services.PropertyService s)=>_svc=s;

    [HttpGet]           public IActionResult Get()           => Ok(_svc.GetAll());
    [HttpGet("{id:int}")] public IActionResult Get(int id)   => _svc.GetById(id) is { } p ? Ok(p) : NotFound();
    [HttpPost]          public IActionResult Post(Property p){ _svc.Add(p); return CreatedAtAction(nameof(Get),new{id=p.Id},p);}
    [HttpPut("{id:int}")]public IActionResult Put(int id,Property p){ if(id!=p.Id)return BadRequest(); _svc.Update(p); return NoContent();}
    [HttpDelete("{id:int}")]public IActionResult Del(int id){ _svc.Delete(id); return NoContent();}
}
