using BudgetScale.Domain.Entities;

namespace BudgetScale.Application.Accounts.Models.Input
{
    public class CreateAccountViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}