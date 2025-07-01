using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net.Http.Json;
using FluentAssertions;
using System.Linq;

namespace PlayerBDD;

[Binding]
public class PlayerUISteps : IDisposable
{
    private readonly IWebDriver _d;
    private readonly HttpClient _api = new();
    private readonly string apiUrl = ""http://localhost:5001/api/player"";

    public PlayerUISteps()
    {
        var opts = new ChromeOptions();
        opts.AddArgument(""--headless=new"");
        _d = new ChromeDriver(opts);
    }

    [Given(""the React app is open"")]
    public void OpenUI() => _d.Navigate().GoToUrl(""http://localhost:3000"");

    [When(@""I add a player named \""(.*)\"" with balance (\d+) via API"")]
    public void AddPlayer(string name, int bal)
    {
        _api.PostAsJsonAsync(apiUrl, new { name, balance = bal }).Wait();
        _d.Navigate().Refresh();
    }

    [Then(@""the UI player list should show \""(.*)\"""")]
    public void CheckUI(string name)
    {
        var texts = _d.FindElements(By.CssSelector(""li"")).Select(li => li.Text);
        texts.Should().Contain(t => t.Contains(name));
    }

    public void Dispose() => _d.Quit();
}
