using Microsoft.AspNetCore.Http;
using Moq;

namespace BudgetScale.Infrastructure.Tests.Services
{
    public interface IMockService<T> where T : class
    {
        Mock<T> Mock { get; set; }  
    }
}