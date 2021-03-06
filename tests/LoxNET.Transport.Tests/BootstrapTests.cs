using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Aggregates;
using EventFlow.Configuration;
using EventFlow.Core;
using LoxNET.Transport;
using LoxNET.Transport.Domain.Services;
using LoxNET.Transport.Domain.Model.ClientModel;
using LoxNET.Transport.Domain.Model.ClientModel.ValueObjects;
using EventFlow.Extensions;
using EventFlow.Logs;
using EventFlow.RabbitMQ;
using EventFlow.RabbitMQ.Extensions;
//using EventFlow.TestHelpers;
using NUnit.Framework;

namespace LoxNET.Transport.Tests
{
    public class Tests
    {
        /* 
        private IRootResolver _resolver;
        private IAggregateStore _aggregateStore;
        private ICommandBus _commandBus;

        [SetUp]
        public void Setup()
        {
            var mquri = new Uri("amqp://rabbitmq:rabbitmq@127.0.0.1");

            //#Rabbit
            _resolver = EventFlowOptions.New
                .ConfigureTransportDomain()
                .UseConsoleLog()
                .PublishToRabbitMq(RabbitMqConfiguration.With(mquri))
                .CreateResolver();
            _aggregateStore = _resolver.Resolve<IAggregateStore>();
            _commandBus = _resolver.Resolve<ICommandBus>();
        }

        [TearDown]
        public void TearDown()
        {
            _resolver.DisposeSafe(new ConsoleLog(), "");
        }

        [Test]
        public async Task Test01Create()
        {
            try
            {
                await CreateClientAggregateAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await LogException(ex.Message).ConfigureAwait(false);
            }

            var svc = _resolver.Resolve<ISocketService>();

            Assert.NotNull(svc);
        }


        public Task LogException(string message)
        {
            var log = _resolver.Resolve<ILog>();
            log.Debug(message);

            return Task.FromResult(0);
        }

        public Task CreateClientAggregateAsync()
        {

            Client client = new Client(ClientId.New);

            return UpdateAsync<ClientAggregate, ClientId>(
                client.Id, 
                a => a.Initialize(
                    new Endpoint("testminiserver.loxone.com", 7777),
                    new Credentials("Web", "Web")
                )
            );
        }



        private async Task UpdateAsync<TAggregate, TIdentity>(TIdentity id, Action<TAggregate> action)
            where TAggregate : IAggregateRoot<TIdentity>
            where TIdentity : IIdentity
        {
            await _aggregateStore.UpdateAsync<TAggregate, TIdentity>(
                id,
                SourceId.New,
                (a, c) =>
                    {
                        action(a);
                        return Task.FromResult(0);
                    },
                CancellationToken.None)
                .ConfigureAwait(false);
        }
        */

    }
}