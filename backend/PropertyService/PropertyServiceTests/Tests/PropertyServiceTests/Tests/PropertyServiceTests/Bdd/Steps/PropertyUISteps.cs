using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net.Http.Json;
using FluentAssertions;
using System.Linq;

namespace PropertyBDD;

[Binding]
public class PropertyUISteps : IDisposable
{
    private readonly IWebDriver _d;
    private readonly HttpClient _api = new();
    private readonly string apiUrl = "http://localhost:5003/api/property";

    public PropertyUISteps()
    {
        var opts=new ChromeOptions(); opts.AddArgument("--headless=new");
        _d=new ChromeDriver(opts);
    }

    [Given(@"the React app is on property page")]
    public void OpenPage() => _d.Navigate().GoToUrl("http://localhost:3000/property");

    [When(@"I add property ""(.*)"" priced (\d+)")]
    public void AddProp(string name,int price)
    {
        _api.PostAsJsonAsync(apiUrl,new{ id=99,name,price,owner="" }).Wait();
        _d.Navigate().Refresh();
    }

    [Then(@"the UI properties list should include ""(.*)""")]
    public void CheckUI(string name)
    {
        var rows=_d.FindElements(By.CssSelector("li")).Select(li=>li.Text);
        rows.Should().Contain(t=>t.Contains(name));
    }

    public void Dispose()=>_d.Quit();
}
