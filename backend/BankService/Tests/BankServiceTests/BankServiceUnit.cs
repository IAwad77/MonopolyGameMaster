using BankService.Models;
using BankService.Services;
using Xunit;

namespace BankService.UnitTests;
public class BankServiceUnit
{
    [Fact]
    public void QueueStoresTransaction()
    {
        var svc = new BankService.Services.BankService();
        svc.AddTransaction(new Transaction{ Type="deposit", Amount=100 });
        Assert.Single(svc.GetHistory());
    }
}
