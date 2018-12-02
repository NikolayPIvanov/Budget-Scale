using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Moq;

namespace BudgetScale.Infrastructure.Tests.Services
{
    public class MockService<T> : IMockService<T> where T : class 
    {
        public Mock<T> Mock { get; set; } = new Mock<T>();
    }
}