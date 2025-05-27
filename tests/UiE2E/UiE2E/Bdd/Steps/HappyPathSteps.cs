using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using System.IO;
using System.Threading;

namespace UiBDD;

[Binding]
public class HappyPathSteps : IDisposable
{
private readonly IWebDriver _d;
public HappyPathSteps()
{
var o=new ChromeOptions(); o.AddArgument("--headless=new");
_d=new ChromeDriver(o);
}

[Given("the login page is open")]
public void LoginPage() => _d.Navigate().GoToUrl("http://localhost:3000/login");

[When("I log in with default creds")]
public void Login()
{
_d.FindElement(By.Name("username")).SendKeys("admin");
_d.FindElement(By.Name("password")).SendKeys("password");
_d.FindElement(By.XPath("//button[contains(text(),'Login')]")).Click();
Thread.Sleep(500); // wait for alert
_d.SwitchTo().Alert().Accept();
}

[When("I upload a sample CSV")]
public void Upload()
{
_d.Navigate().GoToUrl("http://localhost:3000/upload");
var tmp=Path.GetTempFileName();
File.WriteAllText(tmp,"Name,Balance\nAlice,1500");
_d.FindElement(By.CssSelector("input[type='file']")).SendKeys(tmp);
_d.FindElement(By.XPath("//button[contains(text(),'Upload')]")).Click();
Thread.Sleep(500);
}

[Then(@"I should see the player ""(.*)"" in the list")]
public void See(string name)
=> _d.PageSource.Should().Contain(name);

public void Dispose()=>_d.Quit();
}
