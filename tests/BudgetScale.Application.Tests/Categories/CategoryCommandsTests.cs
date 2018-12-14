using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Application.Categories.Commands.CreateCommand;
using BudgetScale.Application.Categories.Commands.DeleteCommand;
using BudgetScale.Application.Categories.Commands.Update;
using BudgetScale.Application.Tests.Infrastructure;
using NUnit.Framework;

namespace BudgetScale.Application.Tests.Categories
{
    public class CategoryCommandsTests : BudgetScaleTestBase
    {
        [Test]
        public async Task CreateCategory_AddsCategoryToTheContext()
        {
            var handler = new CreateCategoryCommandHandler(context, mapper);

            var result = await handler.Handle(new CreateCategoryCommand
            {
                Month = "Dec",
                CategoryName = "A category",
                GroupId = "1",
                UserId = "1"
            }, CancellationToken.None);


            var saved = context.Categories.FindAsync(result);
            Assert.True(saved != null);
        }

        [Test]
        [TestCase("1","Ferrari")]
        public async Task UpdateCategory_UpdatesCategorySuccessfully(string categoryId, string categoryName)
        {
            var handler = new UpdateCategoryCommandHandler(context);

            await handler.Handle(new UpdateCategoryCommand{CategoryId = categoryId,CategoryName = categoryName}, CancellationToken.None);

            var result = await context.Categories.FindAsync(categoryId);

            Assert.True(result.CategoryName == categoryName);
        }

        [Test]
        [TestCase("1")]
        public async Task DeleteCategory_RemovesTheGivenCategoryFromTheDatabase(string categoryId)
        {
            var handler = new DeleteCategoryCommandHandler(context);
            var expectedCount = context.Categories.Count() - 1;
            await handler.Handle(new DeleteCategoryCommand{CategoryId = categoryId}, CancellationToken.None);

            var actual = context.Categories.Count();
            Assert.True(expectedCount == actual);
        }
    }
}