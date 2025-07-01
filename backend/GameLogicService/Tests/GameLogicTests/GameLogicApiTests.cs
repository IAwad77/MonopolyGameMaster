using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Integration;
public class GameLogicApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _c;
    public GameLogicApiTests(WebApplicationFactory<Program> f)=>_c=f.CreateClient();

    [Fact]
    public async Task EndTurn_ShiftsPlayer()
    {
        var body=new StringContent("[\"Ali\",\"Sara\"]",Encoding.UTF8,"application/json");
        await _c.PostAsync("/api/GameLogic/start",body);
        var before=await (await _c.GetAsync("/api/GameLogic")).Content.ReadAsStringAsync();
        await _c.PostAsync("/api/GameLogic/endturn",null);
        var after=await (await _c.GetAsync("/api/GameLogic")).Content.ReadAsStringAsync();
        Assert.NotEqual(before,after);
    }
}
