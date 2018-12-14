using System;
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

            var categories = new[]
            {
                new Category
                {
                    Activity = 100, Available = 10, Budgeted = 0, CategoryId = "1", CategoryName = "first category",
                    Month = "Dec", GroupId = "1"
                },
                new Category
                {
                    Activity = 10, Available = 20, Budgeted = 100, CategoryId = "2", CategoryName = "second category",
                    Month = "Nov", GroupId = "2"
                },
                new Category
                {
                    Activity = 2.41m, Available = 10, Budgeted = 70, CategoryId = "3", CategoryName = "third category",
                    Month = "Dec", GroupId = "3"
                }
            };

            var longRequests = new[]
            {
                new LongRequest
                {
                    ElapsedMilliseconds = "600", Id = "1", Name = "Weird Request", RequestDescription = "None really",
                    Time = DateTime.Now
                },
                new LongRequest
                {
                    ElapsedMilliseconds = "800", Id = "2", Name = "Weird Request two",
                    RequestDescription = "None really", Time = DateTime.Now.AddMonths(-1)
                },
                new LongRequest
                {
                    ElapsedMilliseconds = "1200", Id = "3", Name = "Weird Request three",
                    RequestDescription = "None really", Time = DateTime.Now.AddYears(-1)
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

            context.LongRequests.AddRange(longRequests);
            context.Categories.AddRange(categories);
            context.Accounts.AddRange(accounts);
            context.Groups.AddRange(groups);
            context.SaveChanges();
        }
    }
}