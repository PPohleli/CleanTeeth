using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using FluentValidation;
using Microsoft.Testing.Platform.Requests;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Utilities.Mediator
{
    [TestClass]
    public class SimpleMediatorTests
    {
        public class FalseRequest : IRequest<string> 
        {
            public required string Name { get; set; }
        }

        public class FalseRequestValidator : AbstractValidator<FalseRequest>
        {
            public FalseRequestValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }

        [TestMethod]
        public async Task Send_WithRegisteredHandler_HandleIsExecuted()
        {
            // Arrange
            var request = new FalseRequest()
            {
                Name = "Test"
            };
            var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();
            var serviceProvider = Substitute.For<IServiceProvider>();

            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>)).Returns(handlerMock);

            var mediator = new SimpleMediator(serviceProvider);

            // Act
            await mediator.Send(request);

            // Assert
            await handlerMock.Received(1).Handle(request);
        }

        [TestMethod]
        public async Task Send_WithoutRegisteredHandler_Throws()
        {
            // Arrange
            var request = new FalseRequest()
            {
                Name = "Test"
            };

            var serviceProvider = Substitute.For<IServiceProvider>();

            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>)).ReturnsNull();

            var mediator = new SimpleMediator(serviceProvider);

            // Act
            Func<Task> act = () => mediator.Send(request);

            // Assert
            await Assert.ThrowsExceptionAsync<MediatorException>(act);
        }

        [TestMethod]
        public async Task Send_InvalidCommand_Throws()
        {
            // Arrange
            var request = new FalseRequest()
            {
                Name = ""
            };

            var serviceProvider = Substitute.For<IServiceProvider>();
            var validator = new FalseRequestValidator();

            serviceProvider.GetService(typeof(IValidator<FalseRequest>)).Returns(validator);

            var mediator = new SimpleMediator(serviceProvider);

            // Act
            Func<Task> act = () => mediator.Send(request);

            // Assert
            await Assert.ThrowsExceptionAsync<CustomValidationException>(act);
        }

    }
}
