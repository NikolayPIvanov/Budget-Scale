using BudgetScale.Infrastructure.Extensions;
using BudgetScale.Infrastructure.Tests.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NUnit.Framework;

namespace BudgetScale.Infrastructure.Tests
{
    [TestFixture]
    public class ModelStateDictionaryExtensionsTests
    {
        private IMockService<ModelStateDictionary> mock;
        
        [SetUp]
        public void Setup()
        {
            this.mock = new MockService<ModelStateDictionary>();
        }

        [Test]
        public void GetFirstErrorReturnNullWithNoErrors()
        {
            Assert.That(this.mock.Mock.Object.GetFirstError() == null);
        }

        [Test]
        public void GetFirstErrorReturnFirstError() 
        {
            this.mock.Mock.Object.AddModelError("Error", "First Error");
            this.mock.Mock.Object.AddModelError("Error", "Second Error");

            Assert.That(this.mock.Mock.Object.GetFirstError() == "First Error");

        }


    }
}