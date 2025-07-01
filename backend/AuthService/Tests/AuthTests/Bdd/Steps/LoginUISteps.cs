using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;

namespace AuthBDD;

[Binding]
public class LoginUISteps : IDisposable
{
    private readonly IWebDriver _d;
    public LoginUISteps()
    {
        var o=new ChromeOptions(); o.AddArgument("--headless=new");
        _d=new ChromeDriver(o);
        _d.Navigate().GoToUrl("http://localhost:3000/login");
    }

    [Given("the login page is open")] public void PgOpen(){}

    [When(@"I submit ""(.*)"" and ""(.*)""")]
    public void Submit(string user,string pass)
    {
        _d.FindElement(By.CssSelector("input[name='username']")).SendKeys(user);
        _d.FindElement(By.CssSelector("input[name='password']")).SendKeys(pass);
        _d.FindElement(By.XPath("//button[contains(text(),'Login')]")).Click();
    }

    [Then(@"I should see ""(.*)""")]
    public void ShouldSee(string txt)
        => _d.PageSource.Should().Contain(txt);

    public void Dispose()=>_d.Quit();
}
