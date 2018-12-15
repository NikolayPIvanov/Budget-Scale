using Moq;

namespace BudgetScale.Infrastructure.Tests.Services
{
    public class MockService<T> : IMockService<T> where T : class 
    {
        public Mock<T> Mock { get; set; } = new Mock<T>();
    }
}