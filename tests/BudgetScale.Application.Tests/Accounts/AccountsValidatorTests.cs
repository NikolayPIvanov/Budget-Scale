using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Application.Accounts.Validator;
using BudgetScale.Application.Tests.Infrastructure;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BudgetScale.Application.Tests.Accounts
{
    [TestFixture]
    public class AccountsValidatorTests : BudgetScaleTestBase
    {
        [Test]
        [TestCase("1","1")]
        public async Task Validator_ReturnsCorrectValueForUserWithPermission(string accountId, string userId)
        {
            var handler = new ValidatorRequestHandler(context);

            var result = await handler.Handle(new ValidatorRequest
            {
                UserId = userId,
                AccountId = accountId
            }, CancellationToken.None);

            Assert.True(result==(true,true));
        }

        [Test]
        [TestCase("0", "1")]
        [TestCase("4", "1")]
        public async Task Validator_ReturnsThatEntityDoesNotExist(string accountId, string userId)
        {
            var handler = new ValidatorRequestHandler(context);

            var result = await handler.Handle(new ValidatorRequest
            {
                UserId = userId,
                AccountId = accountId
            }, CancellationToken.None);

            Assert.True(result == (false, false));
        }

        [Test]
        [TestCase("1", "2")]
        [TestCase("2", "10")]
        public async Task Validator_ReturnsThatEntityExistsButUserIsNotAuthorized(string accountId, string userId)
        {
            var handler = new ValidatorRequestHandler(context);

            var result = await handler.Handle(new ValidatorRequest
            {
                UserId = userId,
                AccountId = accountId
            }, CancellationToken.None);

            Assert.True(result == (true, false));
        }
    }
}