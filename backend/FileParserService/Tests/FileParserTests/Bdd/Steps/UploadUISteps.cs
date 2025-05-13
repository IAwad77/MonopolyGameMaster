using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;
using System.IO;

namespace FileParserBDD;

[Binding]
public class UploadUISteps : IDisposable
{
    private readonly IWebDriver _d;
    public UploadUISteps()
    {
        var o=new ChromeOptions(); o.AddArgument("--headless=new");
        _d=new ChromeDriver(o);
        _d.Navigate().GoToUrl("http://localhost:3000/upload"); 
    }

    [Given("the upload page is open")] public void Pg() { }

    [When(@"I choose ""(.*)"" and click Upload")]
    public void ChooseFile(string fileName)
    {
        var tmp=Path.GetTempFileName();
        File.WriteAllText(tmp,"Name,Balance\nAlice,1500");
        _d.FindElement(By.CssSelector("input[type='file']")).SendKeys(tmp);
        _d.FindElement(By.XPath("//button[contains(text(),'Upload')]")).Click();
    }

    [Then(@"I should see ""(.*)"" in the parsed list")]
    public void SeeAlice(string name)
    {
        _d.FindElement(By.TagName("body")).Text.Should().Contain(name);
    }

    public void Dispose()=>_d.Quit();
}
