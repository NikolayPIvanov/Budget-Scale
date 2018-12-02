using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BudgetScale.Infrastructure.Extensions;
using BudgetScale.Infrastructure.Tests.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;

namespace BudgetScale.Infrastructure.Tests
{
    public class Tests
    {
        private IMockService<HttpContext> mock;

        [SetUp]
        public void Setup()
        {
            this.mock = new MockService<HttpContext>();
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
            var claim = new Claim(ClaimTypes.NameIdentifier, "Nikolay");

            var claims = new List<Claim> {
                claim
            };

            var userIdentity = new ClaimsIdentity(claims, "Test");
            IEnumerable<ClaimsIdentity> identities = new List<ClaimsIdentity>() {userIdentity};

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            mock.Mock.Setup(l => l.User).Returns(userPrincipal);
            mock.Mock.Setup(l => l.User.Identity.IsAuthenticated).Returns(true);
            mock.Mock.Setup(l => l.User.Claims).Returns(claims);
            mock.Mock.Setup(l => l.User.Identity).Returns(userIdentity);
            mock.Mock.Setup(l => l.User.Identities).Returns(identities);
            mock.Mock.Setup(l => l.User.FindFirst(It.IsAny<Predicate<Claim>>())).Returns(claim);


            string result = this.mock.Mock.Object.User.GetId();
            Assert.That(result.Equals("Nikolay"));
        }


    }
}