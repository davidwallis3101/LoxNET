using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Aggregates;
using EventFlow.Configuration;
using EventFlow.Core;
using LoxNet.Transport;
using LoxNet.Transport.Domain.Services;
using EventFlow.Extensions;
using EventFlow.Logs;
//using EventFlow.TestHelpers;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private IRootResolver _resolver;
        private IAggregateStore _aggregateStore;
        private ICommandBus _commandBus;

        [SetUp]
        public void Setup()
        {
            _resolver = EventFlowOptions.New
                .ConfigureTransportDomain()
                .CreateResolver();
            _aggregateStore = _resolver.Resolve<IAggregateStore>();
            _commandBus = _resolver.Resolve<ICommandBus>();
        }

        [Test]
        public void Test1()
        {
            var svc = _resolver.Resolve<ISocketService>();

            Assert.NotNull(svc);
        }
    }
}