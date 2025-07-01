namespace BankService.Models;

// Represents a single banking transaction
public class Transaction
{
    public Guid Id { get; set; }
    public string Type { get; set; } = "";   // deposit / withdraw
    public int    Amount { get; set; }
    public DateTime Timestamp { get; set; }
}
