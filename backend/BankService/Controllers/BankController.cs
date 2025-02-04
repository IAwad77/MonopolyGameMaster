using Microsoft.AspNetCore.Mvc;
using BankService.Models;
using BankService.Services;

namespace BankService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BankController : ControllerBase
{
    private readonly IBankService _svc;
    public BankController(IBankService s)=>_svc=s;

    [HttpPost]                               
    public IActionResult Post(Transaction t)
    {
        _svc.AddTransaction(t);
        return Ok("Queued");
    }

    [HttpGet]                                 
    public ActionResult<List<Transaction>> Get()
    {
        return Ok(_svc.GetHistory());
    }
}
