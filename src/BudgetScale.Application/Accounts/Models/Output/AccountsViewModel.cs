using System.Collections.Generic;
using BudgetScale.Domain.Entities;

namespace BudgetScale.Application.Accounts.Models.Output
{
    public class AccountsViewModel
    {
        public string UserId { get; set; }

        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public AccountType AccountType { get; set; }

        public ICollection<Transaction> Transactions { get; private set; }
    }
}