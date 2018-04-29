using System;
using System.Collections;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using LoxNET.Transport.Domain.Model.ClientModel;
using LoxNET.Transport.Domain.Model.ClientModel.Events;
using LoxNET.Transport.Domain.Model.ClientModel.ValueObjects;

namespace LoxNET.Transport.Domain.Model.ClientModel.ReadModels
{

    public class ClientConnectReadModel : IReadModel,
        IAmReadModelFor<ClientAggregate, ClientId, ClientInitializedEvent>
    {
        public string ClientId { get; set; }
        public string Hostname { get; set; }
        public int Port { get; set; }

        public void Apply(
            IReadModelContext context,
            IDomainEvent<ClientAggregate, ClientId, ClientInitializedEvent> domainEvent)
        {
            ClientId = domainEvent.AggregateIdentity.Value;
            var endpoint = domainEvent.AggregateEvent.Endpoint; 
            Hostname = endpoint.Hostname;
            Port = endpoint.Port;
        }
    }
}
