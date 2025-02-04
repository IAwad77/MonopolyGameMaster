using BankService.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankService.Services;

public class BankService : IBankService
{
    private readonly Queue<Transaction> _queue = new();

    public void AddTransaction(Transaction t)
    {
        t.Id        = Guid.NewGuid();
        t.Timestamp = DateTime.UtcNow;
        _queue.Enqueue(t);                  
    }

    public List<Transaction> GetHistory() => _queue.ToList();
}

