using BudgetScale.Persistence;
using BudgetScale.Domain.Entities;
using System.Linq;

namespace BudgetScale.Application.Tests.Infrastructure
{
    public static class Initializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Groups.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(ApplicationDbContext context)
        {
            var groups = new[]
            {
                new Group
                {
                    GroupId = "1", GroupName = "first group", UserId = "1"
                },
                new Group
                {
                    GroupId = "2", GroupName = "second group", UserId = "1"
                },
                new Group
                {
                    GroupId = "3", GroupName = "third group", UserId = "2"
                },
                new Group
                {
                    GroupId = "4", GroupName = "forth group", UserId = "3"
                },

            };

            var accounts = new[]
            {
                new Account
                {
                    UserId = "1", AccountId = "1", AccountType = AccountType.Cash, AccountName = "First user cash account",
                },
                new Account
                {
                    UserId = "1", AccountId = "2", AccountType = AccountType.Checking, AccountName = "First user checking account",
                },
                new Account
                {
                    UserId = "2", AccountId = "3", AccountType = AccountType.Savings, AccountName = "Second savings",
                },
            };

            context.Accounts.AddRange(accounts);
            context.SaveChanges();

            context.Groups.AddRange(groups);
            context.SaveChanges();
        }
    }
}