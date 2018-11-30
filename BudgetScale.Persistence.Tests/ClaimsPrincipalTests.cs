using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BudgetScale.Infrastructure.Extensions;
using BudgetScale.Infrastructure.Tests.Services;
using BudgetScale.Persistence;
using BudgetScale.Persistence.Infrastructure;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;

namespace BudgetScale.Infrastructure.Tests
{
    public class Tests
    {
        private IMockHttpContextService mock;

        [SetUp]
        public void Setup()
        {
            this.mock = new MockHttpContextService();
        }

        [Test]
        public void ClaimsPrincipalThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>( () => this.mock.Mock.Object.User.GetId());
        }

        [Test]
        public void ClaimsPrincipalReturnsNullWhenUserIsNotAuthenticated()
        {
            mock.Mock.Setup(l => l.User.Identity.IsAuthenticated).Returns(false);

            var result = mock.Mock.Object.User.GetId();
            Assert.That(result == null);
        }

        [Test]
        public void ClaimsPrincipalReturnsTheId()
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, "Nikolay", ClaimValueTypes.String, "testhost"),
            };

            var userIdentity = new ClaimsIdentity(claims, "Test");

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            mock.Mock.Setup(l => l.User).Returns(userPrincipal);
            mock.Mock.Setup(l => l.User.Identity.IsAuthenticated).Returns(true);
            mock.Mock.Setup(l => l.User.Claims).Returns(claims);
            mock.Mock.Setup(l => l.User.Identity).Returns(userIdentity);

            var result = this.mock.Mock.Object.User.GetId();
            Assert.That(result.Equals("Nikolay"));
        }


    }
}