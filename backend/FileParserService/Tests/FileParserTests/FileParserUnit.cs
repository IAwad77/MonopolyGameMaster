using Xunit;
using FileParserService.Services;

namespace FileParser.Unit;
public class FileParserUnit
{
    [Fact]
    public void Csv_ParsesPlayers()
    {
        var svc=new FileParserService.Services.FileParserService();
        var csv="Name,Balance\nAlice,1500\nBob,1400";
        var res=svc.ParsePlayerCsv(csv);
        Assert.Equal(2,res.Count);
        Assert.Equal("Alice",res[0].Name);
    }
}
