using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Application.Groups.Commands.CreateCommand;
using BudgetScale.Application.Groups.Commands.DeleteCommand;
using BudgetScale.Application.Groups.Commands.UpdateCommand;
using BudgetScale.Application.Groups.Models.Input;
using BudgetScale.Application.Tests.Infrastructure;
using NUnit.Framework;

namespace BudgetScale.Application.Tests
{
    [TestFixture]
    public class GroupsCommandsTests : BudgetScaleTestBase
    {
        [Test]
        public async Task CreateGroup_SuccessfullyCreatesAGroup_ForAUser()
        {
            var command = new CreateGroupCommand
            {
                UserId = "1",
                GroupName = "Unit test group"
            };
            //var expectedAllGroups = context.Groups.Count();

            var expectedGroupsForUser = context.Groups.Count(e => e.UserId.Equals("1")) + 1;

            var sut = new CreateGroupCommandHandler(context, mapper);

            await sut.Handle(command, CancellationToken.None);

            var actualGroupsForUser = context.Groups.Count(e => e.UserId.Equals("1"));

            Assert.True(actualGroupsForUser == expectedGroupsForUser);

        }

        [Test]
        [TestCase(null, "An invalid data")]
        [TestCase(null, "A")]
        [TestCase(null, "An invalid data that is too long to be processed by the validator because the maximum is reached!")]
        [TestCase("Valid", "An invalid data that is too long to be processed by the validator because the maximum is reached!")]
        [TestCase("Valid", "A")]
        [TestCase(null, null)]
        public void CreateGroup_Validation_TracksInvalidData(string userId, string groupName)
        {
            //Act
            var query = new CreateGroupCommand()
            {
                UserId = userId,
                GroupName = groupName
            };

            var validator = new CreateGroupCommandValidator();

            //Arrange
            var result = validator.Validate(query);

            //Assert
            Assert.True(!result.IsValid);

        }

        [Test]
        [TestCase("1", "New group")]
        [TestCase("2", "New group two")]
        [TestCase("3", "New group threeeeeeeeeeeee")]
        [TestCase("4", "Ne")]
        public async Task UpdateGroup_SuccessfullyUpdates(string id, string name)
        {
            //Arrange
            var sut = new UpdateGroupCommandHandler(context);

            //Act
            await sut.Handle(new UpdateGroupCommand {
                GroupId = id,
                GroupName =name }, CancellationToken.None);
            
            var result = await context.Groups.FindAsync(id);

            //Assert
            Assert.That(result.GroupName.Equals(name));
        }

        [Test]
        [TestCase("1")]
        public async Task DeleteGroupTest(string id)
        {
            //Arrange
            var sut = new DeleteGroupCommandHandler(context);
            var expected = context.Groups.Count() - 1;
            //Act
            await sut.Handle(new DeleteGroupCommand() {GroupId = id}, CancellationToken.None);

            //Assert
            Assert.True(expected == context.Groups.Count());
        }
    }
}