using Microsoft.AspNetCore.Http;
using Moq;

namespace BudgetScale.Infrastructure.Tests.Services
{
    public interface IMockHttpContextService
    {
        Mock<HttpContext> Mock { get; set; }
    }
}