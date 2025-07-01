using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net.Http.Json;
using FluentAssertions;
using System.Linq;

namespace BankBDD;

[Binding]
public class BankUISteps : IDisposable
{
    private readonly IWebDriver _d;
    private readonly HttpClient _api = new();
    private readonly string apiUrl = "http://localhost:5002/api/bank";

    public BankUISteps()
    {
        var opts=new ChromeOptions();
        opts.AddArgument("--headless=new");
        _d=new ChromeDriver(opts);
    }

    [Given(@"the React app is on bank page")]
    public void OpenBank()
    {
        _d.Navigate().GoToUrl("http://localhost:3000/bank"); // add this route in React later
    }

    [When(@"I submit a deposit of (\d+)")]
    public void Deposit(int amt)
    {
        _api.PostAsJsonAsync(apiUrl,new{ type="deposit", amount=amt }).Wait();
        _d.Navigate().Refresh();
    }

    [Then(@"the transaction list should show ""(.*)"" of (\d+)")]
    public void CheckList(string type,int amt)
    {
        var rows=_d.FindElements(By.CssSelector("li")).Select(li=>li.Text);
        rows.Should().Contain(r=>r.Contains(type) && r.Contains(amt.ToString()));
    }

    public void Dispose()=>_d.Quit();
}
