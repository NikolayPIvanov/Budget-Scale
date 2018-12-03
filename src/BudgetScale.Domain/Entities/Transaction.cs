
using System;
using BudgetScale.Domain.EntityContracts;

namespace BudgetScale.Domain.Entities
{
    public class Transaction : IAuditInfo
    {
        private TransactionType type;

        public string TransactionId { get; set; }

        public Account SourceAccount { get; set; }

        public string SourceAccountId { get; set; }

        public Account DestinationAccount { get; set; }

        public string DestinationAccountId { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public string Reason { get; set; }

        public string Memo { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public TransactionType Type
        {
            get => this.type;
            set => type = Amount >= 0 ? TransactionType.Inflow : TransactionType.Outflow;
        }
    }
}