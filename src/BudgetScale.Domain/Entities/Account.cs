using System;
using System.Collections.Generic;
using BudgetScale.Domain.EntityContracts;

namespace BudgetScale.Domain.Entities
{
    public class Account : IAuditInfo
    {
        public Account()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Transactions = new HashSet<Transaction>();
        }
        public ApplicationUser ApplicationUser { get; set; }

        public string UserId { get; set; }

        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public AccountType AccountType { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public ICollection<Transaction> Transactions { get; private set; }

    }
}