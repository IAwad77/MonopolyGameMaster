using FileParserService.Models;
namespace FileParserService.Services;
public interface IFileParserService
{
    List<ParsedPlayer> ParsePlayerCsv(string csv);
}
