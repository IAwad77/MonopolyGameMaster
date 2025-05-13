using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Integration;
public class FileParserApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _c;
    public FileParserApiTests(WebApplicationFactory<Program> f)=>_c=f.CreateClient();

    [Fact]
    public async Task Parse_ReturnsPlayers()
    {
        var csv="Name,Balance\nAlice,1500";
        var content=new StringContent(csv,Encoding.UTF8,"text/csv");
        var form=new MultipartFormDataContent{ {content,"file","players.csv"} };
        var res=await _c.PostAsync("/api/FileParser/parse",form);
        Assert.True(res.IsSuccessStatusCode);
    }
}
