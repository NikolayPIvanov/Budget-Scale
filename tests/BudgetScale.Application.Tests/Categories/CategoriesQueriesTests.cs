using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Application.Categories.Queries.GetAllQuery;
using BudgetScale.Application.Categories.Queries.GetQuery;
using BudgetScale.Application.Tests.Infrastructure;
using BudgetScale.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BudgetScale.Application.Tests.Categories
{
    public class CategoriesQueriesTests : BudgetScaleTestBase
    {
        [Test]
        [TestCase("1","1")]
        [TestCase("2", "2")]
        [TestCase("3", "3")]
        public async Task GetCategoryQuery_ReturnsCorrectValueOfCorrectType(string categoryId, string groupId)
        {   
            var handler = new GetCategoryQueryHandler(context);

            var expected = await context.Categories.FindAsync(categoryId);

            var result = await handler.Handle(new GetCategoryQuery {CategoryId = categoryId, GroupId = groupId},
                CancellationToken.None);

            Assert.IsInstanceOf(typeof(Category),result);
            Assert.AreSame(expected,result);
        }

        [Test]
        [TestCase("1","1")]
        [TestCase("2","2")]
        public async Task GetAllCategoriesQuery_ReturnsIQueryableOfCategoryType(string userId,string groupId)
        {
            var handler = new GetAllCategoriesQueryHandler(context);

            var result = await handler.Handle(new GetAllCategoriesQuery{UserId = userId, GroupId = groupId}, CancellationToken.None);

            Assert.IsInstanceOf(typeof(IQueryable<Category>),result);

        }

        [Test]
        [TestCase("1", "1")]
        [TestCase("2", "2")]
        public async Task GetAllCategoriesQuery_ReturnsTheCategoriesForGivenUser(string userId, string groupId)
        {
            var handler = new GetAllCategoriesQueryHandler(context);
            var expected = context.Categories.Include(c => c.Group).Where(c => c.Group.UserId == userId);
            var result = await handler.Handle(new GetAllCategoriesQuery { UserId = userId, GroupId = groupId }, CancellationToken.None);

            CollectionAssert.AreEqual(expected,result);
            Assert.True(expected.Count() == result.Count());

        }
    }
}