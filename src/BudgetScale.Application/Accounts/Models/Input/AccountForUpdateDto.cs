using BudgetScale.Domain.Entities;

namespace BudgetScale.Application.Accounts.Models.Input
{
    public class AccountForUpdateDto
    {
        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public string AccountType { get; set; }
    }
}