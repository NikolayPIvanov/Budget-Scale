using BudgetScale.Infrastructure.Tests.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using NUnit.Framework;

namespace BudgetScale.Infrastructure.Tests
{
    public class ModelStateDictionaryExtensionsTests
    {
        private IMockService<ModelStateDictionary> mock;


        [SetUp]
        public void Setup()
        {
            this.mock = new MockService<ModelStateDictionary>();
        }



    }
}