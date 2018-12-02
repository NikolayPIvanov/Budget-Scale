using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Application.Groups.Commands.CreateCommand;
using BudgetScale.Application.Groups.Queries.GetGroup;
using BudgetScale.Application.Infrastructure;
using BudgetScale.Application.Tests.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace BudgetScale.Application.Tests
{
    [TestFixture]
    public class InfrastructureTests : BudgetScaleTestBase
    {
        [Test]
        public void RequestLogger_LogsWarning_ToTheConsole()
        {
            var mockFactory = new Mock<LoggerFactory>();
            var mockLogger = new Mock<Logger<GetGroupQuery>>(mockFactory.Object);
            var mockRequest = new Mock<GetGroupQuery>();

            var requestLogger = new RequestLogger<GetGroupQuery>(mockLogger.Object);

            var result = requestLogger.Process(mockRequest.Object, CancellationToken.None);

            Assert.IsTrue(result == Task.CompletedTask);

        }

        [Test]
        public async Task RequestValidationBehavior_RedirectsToTheNextDelegate()
        {
            var command = new CreateGroupCommand
            {
                GroupName = "A group name",
                UserId = "1"
            };

            var mockDelegate = new Mock<RequestHandlerDelegate<string>>(MockBehavior.Default);
            
            IValidator<CreateGroupCommand> valid = new CreateGroupCommandValidator();

            var list = new List<IValidator<CreateGroupCommand>> { valid };

            var v = new RequestValidationBehavior<CreateGroupCommand, string>(list);

            object result = await v.Handle(command, CancellationToken.None, mockDelegate.Object);

            Assert.IsNull(result);
        }

        [Test]
        public void RequestValidationBehaviour_ThrowsValidationException_WhenModelIsInvalid()
        {
            var command = new CreateGroupCommand
            {
                GroupName = null,
                UserId = null
            };

            var mockDelegate = new Mock<RequestHandlerDelegate<string>>(MockBehavior.Default);

            IValidator<CreateGroupCommand> valid = new CreateGroupCommandValidator();

            var list = new List<IValidator<CreateGroupCommand>> { valid };

            var v = new RequestValidationBehavior<CreateGroupCommand, string>(list);

            Assert.ThrowsAsync<Exceptions.ValidationException>(async () => await v.Handle(command, CancellationToken.None, mockDelegate.Object));
        }

        [Test]
        public async Task RequestPerformanceBehaviour_RedirectToNextRequest()
        {
            var command = new CreateGroupCommand
            {
                GroupName = "A request",
                UserId = "1"
            };

            var mockFactory = new Mock<LoggerFactory>();
            var mockLogger = new Mock<Logger<CreateGroupCommand>>(mockFactory.Object);

            var mockDelegate = new Mock<RequestHandlerDelegate<string>>(MockBehavior.Default);

            var v = new RequestPerformanceBehaviour<CreateGroupCommand, string>(mockLogger.Object);

            var result = await v.Handle(command, CancellationToken.None, mockDelegate.Object);

            Assert.IsNull(result);
        }

        
    }
}