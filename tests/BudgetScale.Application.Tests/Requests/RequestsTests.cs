using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Application.Requests.Queries.AllRequests;
using BudgetScale.Application.Tests.Infrastructure;
using BudgetScale.Domain.Entities;
using NUnit.Framework;

namespace BudgetScale.Application.Tests.Requests
{
    public class RequestsTests : BudgetScaleTestBase
    {
        [Test]
        [TestCase(1)]
        public async Task RequestsTest(int hours)
        {
            var handler = new AllRequestsHandler(context);

            var response = await handler.Handle(new AllRequests {Hours = hours}, CancellationToken.None);

            Assert.IsInstanceOf(typeof(IQueryable<LongRequest>),response);
        }

        [Test]
        [TestCase(1)]
        [TestCase(1000)]
        [TestCase(10000)]
        public async Task Requests_ReturnsCorrectItems_Test(int hours)
        {
            var handler = new AllRequestsHandler(context);

            var response = await handler.Handle(new AllRequests { Hours = hours }, CancellationToken.None);

            var expected = context.LongRequests
                .Where(request => DateTime.UtcNow.AddHours(-hours) <= request.Time)
                .OrderByDescending(e => e.Time);
            
           CollectionAssert.AreEqual(expected, response);
        }
    }
}