using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using System.Linq;

namespace GameLogicBDD;

[Binding]
public class TurnUISteps : IDisposable
{
    private readonly IWebDriver _d;
    public TurnUISteps()
    {
        var o=new ChromeOptions(); o.AddArgument("--headless=new");
        _d=new ChromeDriver(o);
        _d.Navigate().GoToUrl("http://localhost:3000/game"); // ensure route in React
    }

    [When(@"I click ""End Turn""")]
    public void ClickEnd()
        => _d.FindElement(By.XPath("//button[contains(text(),'End Turn')]")).Click();

    string _before="";
    [Given(@"the React game page is open")]
    public void Capture()
        => _before=_d.FindElement(By.CssSelector("h2")).Text; // assume <h2> shows current player

    [Then(@"the displayed current player should change")]
    public void Verify()
    {
        _d.Navigate().Refresh();
        var after=_d.FindElement(By.CssSelector("h2")).Text;
        after.Should().NotBe(_before);
    }

    public void Dispose()=>_d.Quit();
}
