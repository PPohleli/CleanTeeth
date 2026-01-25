using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using NSubstitute;
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
            var request = new FalseRequest();
            var handleMock = Substitute.For<IRequestHandler<FalseRequest, string>>();
            var serviceProvider = Substitute.For<IServiceProvider>();
            
            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>)).Returns(handleMock);

            var mediator = new SimpleMediator(serviceProvider);
            var result = await mediator.Send(request);

            await handleMock.Received(1).Handle(request);
        }

        [TestMethod]
        [ExpectedException(typeof(MediatorException))]
        public async Task Send_WithoutRegisteredHandler_Throws()
        {
            var request = new FalseRequest();
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>)).Returns(null);
            var mediator = new SimpleMediator(serviceProvider);
            var result = await mediator.Send(request);
        }
    }
}
