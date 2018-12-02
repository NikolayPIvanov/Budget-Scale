using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Application.Groups.Queries.GetGroups;
using BudgetScale.Application.Tests.Infrastructure;
using NUnit.Framework;
namespace BudgetScale.Application.Tests
{
    [TestFixture]
    public class GroupsQueriesTests : BudgetScaleTestBase
    {
        [Test]
        [TestCase("1", "Dec")]
        [TestCase("2", "Nov")]
        [TestCase("3", "Nov")]
        [TestCase("0", "Nov")]
        public async Task GetGroups_ReturnsIListType(string userId, string month)
        {
            //Act
            var query = new GetGroupsQuery
            {
                Month = month,
                UserId = userId
            };

            var handler = new GetGroupsQueryHandler(context, mapper);

            //Arrange
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsInstanceOf<IList<GroupViewModel>>(result);
        }

        [Test]
        [TestCase("1", "Dec")]
        [TestCase("2", "Dec")]
        [TestCase("3", "Dec")]
        [TestCase("0", "Dec")]
        public async Task GetGroups_AListOfTheCorrectItems(string userId, string month)
        {
            //Act
            var query = new GetGroupsQuery
            {
                Month = month,
                UserId = userId
            };

            var handler = new GetGroupsQueryHandler(context, mapper);

            var expected = context.Groups.Where(g => g.UserId.Equals(userId)).ToList();

            //Arrange
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.True(result.Count() == expected.Count);
        }

        [Test]
        [TestCase("1", "Dec")]
        [TestCase("0","Mar")]
        [TestCase("10", "Apr")]
        [TestCase("11", "Nov")]
        public  void GroupsQueryValidator_IsWorking(string userId, string month)
        {
            //Act
            var query = new GetGroupsQuery
            {
                Month = month,
                UserId = userId
            };

            var validator = new GetGroupsQueryValidator();

            var result = validator.Validate(query);

            Assert.True(result.IsValid);
        }

        [Test]
        [TestCase("", "Dec")]
        [TestCase("", "mar")]
        [TestCase(null, "Mar")]
        [TestCase(null, "apr")]
        [TestCase(null, "NOV")]
        [TestCase("", "NOV")]
        public void GroupsQueryValidator_CatchesInvalidData(string userId, string month)
        {
            //Act
            var query = new GetGroupsQuery
            {
                Month = month,
                UserId = userId
            };

            var validator = new GetGroupsQueryValidator();

            var result = validator.Validate(query);

            Assert.True(!result.IsValid);
        }
    }
}