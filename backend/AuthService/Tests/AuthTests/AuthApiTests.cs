using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Integration;
public class AuthApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _c;
    public AuthApiTests(WebApplicationFactory<Program> f)=>_c=f.CreateClient();

    [Fact]
    public async Task Login_Valid_ReturnsToken()
    {
        var json="{\"username\":\"admin\",\"password\":\"password\"}";
        var res=await _c.PostAsync("/api/Auth/login",new StringContent(json,Encoding.UTF8,"application/json"));
        Assert.True(res.IsSuccessStatusCode);
    }
}
