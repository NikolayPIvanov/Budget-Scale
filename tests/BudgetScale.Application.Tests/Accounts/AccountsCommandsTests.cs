using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Application.Accounts.Commands.CreateCommand;
using BudgetScale.Application.Accounts.Commands.DeleteCommand;
using BudgetScale.Application.Accounts.Commands.UpdateCommand;
using BudgetScale.Application.Tests.Infrastructure;
using BudgetScale.Domain.Entities;
using NUnit.Framework;

namespace BudgetScale.Application.Tests.Accounts
{
    [TestFixture]
    public class AccountsCommandsTests : BudgetScaleTestBase
    {
        [Test]
        [TestCase("Mike's pocket money", "Credit", "1")]
        [TestCase("Mike's pocket money", "Checking", "1")]
        [TestCase("Mike's pocket money", "Savings", "1")]
        [TestCase("Mike's pocket money", "Cash", "1")]
        [TestCase("Mike's pocket money", "Asset", "1")]
        [TestCase("Mike's pocket money", "Liability", "1")]
        public async Task CreateAccount_WithAllPossibleAccountTypes_CreatesSuccessfullyAndSavesInDatabase(
            string accountName, string accountType, string userId)
        {
            //Arrange
            var sut = new CreateAccountCommandHandler(context, mapper);
            var expected = context.Accounts.Count() + 1;
            //Act
            await sut.Handle(new CreateAccountCommand
            {
                AccountName = accountName,
                AccountType = accountType,
                UserId = userId
            }, CancellationToken.None);

            var actual = context.Accounts.Count();

            //Assert
            Assert.True(expected == actual);
        }


        [Test]
        [TestCase("1", "A new account", "A")]
        [TestCase("2", "aOFIONWONFOAIOFNOAADWIOINAOINFOIWNOFAONFAOOIN", "B")]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public void UpdateAccount_FailsUpdateWithIncorrectEnumType(string accountId, string accountName,
            string accountType)
        {
            //Arrange
            var sut = new UpdateAccountCommandHandler(context);

            //Act

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await sut.Handle(
                    new UpdateAccountCommand
                        {AccountId = accountId, AccountType = accountType, AccountName = accountName},
                    CancellationToken.None);
            });

        }


        [Test]
        [TestCase("1", "A new account", "Asset")]
        [TestCase("2", "A new account", "Cash")]
        public async Task UpdateAccount_UpdatesTheCorrectAccountTest(string accountId, string accountName,
            string accountType)
        {

            //Arrange
            var sut = new UpdateAccountCommandHandler(context);

            //Act
            await sut.Handle(
                new UpdateAccountCommand {AccountId = accountId, AccountType = accountType, AccountName = accountName},
                CancellationToken.None);

            var expected = await context.Accounts.FindAsync(accountId);
            //Assert
            Assert.True(expected.AccountName == accountName &&
                        (AccountType) Enum.Parse(typeof(AccountType), accountType) == expected.AccountType);
        }

        [Test]
        [TestCase("1")]
        public async Task DeleteAccount_DeletesTheGivenAccount(string accountId)
        {
            var sut = new DeleteAccountCommandHandler(context);

            var expected = this.context.Accounts.Count() - 1;

            await sut.Handle(new DeleteAccountCommand {AccountId = accountId}, CancellationToken.None);

            Assert.AreEqual(expected, context.Accounts.Count());
        }

        [Test]

        [TestCase("Credit")]
        [TestCase("Checking")]
        [TestCase("Savings")]
        [TestCase("Cash")]
        [TestCase("Asset")]
        [TestCase("Liability")]
        public void UpdateAccountCommandValidator_ValidatesCorrectProperties(string type)
        {
            var validator = new UpdateAccountCommandValidator();

            var result = validator
                .Validate(new UpdateAccountCommand {AccountId = "1", AccountName = "Test", AccountType = type});

            Assert.True(result.IsValid);
        }
    
}
}