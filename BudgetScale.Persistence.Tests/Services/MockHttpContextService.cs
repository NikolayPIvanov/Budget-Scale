using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Moq;

namespace BudgetScale.Infrastructure.Tests.Services
{
    public class MockHttpContextService : IMockHttpContextService
    {
        public Mock<HttpContext> Mock { get; set; } = new Mock<HttpContext>();
    }
}