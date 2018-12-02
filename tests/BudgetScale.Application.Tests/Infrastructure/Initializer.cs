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

            context.Groups.AddRange(groups);
            context.SaveChanges();
        }
    }
}