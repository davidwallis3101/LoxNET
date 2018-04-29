using System.Threading;
using System.Threading.Tasks;
using EventFlow.Configuration;
using EventFlow.Queries;
using EventFlow.Aggregates;
using EventFlow;
using EventFlow.Core;
using LoxNET.Transport.Domain.Model.ClientModel.Queries;
using LoxNET.Transport.Domain.Model.ClientModel.Events;
using LoxNET.Transport.Domain.Services;
using EventFlow.Jobs;
using EventFlow.Subscribers;

namespace LoxNET.Transport.Domain.Model.ClientModel.Subscribers
{
    public class ClientSetupSubscriber :
        ISubscribeSynchronousTo<ClientAggregate, ClientId, ClientInitializedEvent>
    {
        private readonly IResolver _resolver;

        public ClientSetupSubscriber(
            IResolver resolver)
        {
            _resolver = resolver;
        }

        public async Task HandleAsync(IDomainEvent<ClientAggregate, ClientId, ClientInitializedEvent> domainEvent, CancellationToken cancellationToken)
        {
            var socketService = _resolver.Resolve<ISocketService>();

            /*await socketService.OpenAsync(
                Identity.New,
                domainEvent.AggregateEvent.Endpoint.Hostname,
                domainEvent.AggregateEvent.Endpoint.Port, 
                cancellationToken
            ).ConfigureAwait(false);*/
            await Task.FromResult(0);

        }
    }

}