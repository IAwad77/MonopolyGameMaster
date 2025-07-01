using PropertyService.Models;
using PropertyService.Services;
using Xunit;

namespace PropertyService.UnitTests;
public class PropertyUnit
{
    [Fact]
    public void AddAndRetrieve()
    {
        var svc=new PropertyService.Services.PropertyService();
        svc.Add(new Property{ Id=1, Name="Park Place", Price=350, Owner="Alice"});
        Assert.Equal("Park Place", svc.GetById(1)?.Name);
    }
}
