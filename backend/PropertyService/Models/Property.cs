namespace PropertyService.Models;

public class Property
{
    public int    Id     { get; set; }
    public string Name   { get; set; } = "";
    public int    Price  { get; set; }
    public string Owner  { get; set; } = "";
}
