using BankService.Models;
using System.Collections.Generic;

namespace BankService.Services;

public interface IBankService
{
    void AddTransaction(Transaction t);
    List<Transaction> GetHistory();
}
