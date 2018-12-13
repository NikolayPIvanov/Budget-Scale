using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Application.Accounts.Queries.GetAccount;
using BudgetScale.Application.Accounts.Queries.GetAccounts;
using BudgetScale.Application.Tests.Infrastructure;
using NUnit.Framework;

namespace BudgetScale.Application.Tests.Accounts
{
    [TestFixture]
    public class AccountsQueriesTests : BudgetScaleTestBase
    {
        [Test]
        [TestCase("1")]
        [TestCase("2")]
        public async Task GetAccount_ReturnsAccount(string accountId)
        {
            //Arrange
            var handler = new GetAccountQueryHandler(context);
            var expected = await context.Accounts.FindAsync(accountId);
            //Act
            var result = await handler.Handle(new GetAccountQuery
            {
                AccountId = accountId
            }, CancellationToken.None);

            //Assert

            Assert.True(expected.AccountId.Equals(result.AccountId));
        }

        [Test]
        [TestCase("0")]
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public async Task GetAccounts_ReturnsAllAccounts(string userId)
        {
            //Arrange
            var sut = new GetAllAccountsQueryHandler(context);
            var expected = context.Accounts.Count(a => a.UserId.Equals(userId));

            //Act
            var result = await sut.Handle(new GetAllAccountsQuery(userId), CancellationToken.None);

            //Assert
            Assert.True(result.Count().Equals(expected));
        }

        [Test]
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        public void GetAllAccountsValidator(string userId)
        {
            //Arrange
            var query = new GetAllAccountsQuery(userId);
            var validator = new GetAllAccountsQueryValidator();

            //Act
            var result = validator.Validate(query);

            //Assert
            Assert.True(result.IsValid);
            Assert.True(result.Errors.Count == 0);

        }

        [Test]
        [TestCase("")]
        public void GetAllAccountsValidator_CatchesInvalidData(string userId)
        {
            //Arrange
            var query = new GetAllAccountsQuery(userId);
            var validator = new GetAllAccountsQueryValidator();

            //Act
            var result = validator.Validate(query);

            //Assert
            Assert.True(!result.IsValid);
            Assert.True(result.Errors.Count != 0);

        }

    }
}