using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
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
        public class FalseRequest : IRequest<string> { }

        [TestMethod]
        public async Task Send_WithRegisteredHandler_HandleIsExecuted()
        {
            // Arrange
            var request = new FalseRequest();
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
            var request = new FalseRequest();

            var serviceProvider = Substitute.For<IServiceProvider>();

            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>)).ReturnsNull();

            var mediator = new SimpleMediator(serviceProvider);

            // Act
            Func<Task> act = () => mediator.Send(request);

            // Assert
            await Assert.ThrowsExceptionAsync<MediatorException>(act);
        }

    }
}
