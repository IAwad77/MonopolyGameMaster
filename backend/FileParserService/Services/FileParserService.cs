using FileParserService.Models;
using System.Collections.Generic;
using System.Linq;

namespace FileParserService.Services;

public class FileParserService : IFileParserService
{
    public List<ParsedPlayer> ParsePlayerCsv(string csv)
    {
        var lines = csv.Split('\n');
        return lines.Skip(1)
                    .Where(l=>!string.IsNullOrWhiteSpace(l))
                    .Select(l=>{
                        var p=l.Split(',');
                        return new ParsedPlayer{ Name=p[0].Trim(),
                                                 Balance=int.Parse(p[1]) };
                     }).ToList();
    }
}
