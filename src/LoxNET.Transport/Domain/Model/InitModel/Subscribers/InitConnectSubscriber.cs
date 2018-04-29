using System.Threading;
using System.Threading.Tasks;
using EventFlow.Configuration;
using EventFlow.Queries;
using EventFlow.Aggregates;
using LoxNET.Transport.Domain.Model.InitModel.Events;
using LoxNET.Transport.Domain.Model.InitModel.Jobs;
using LoxNET.Transport.Domain.Services;
using EventFlow.Jobs;
using EventFlow.Subscribers;

namespace LoxNET.Transport.Domain.Model.InitModel.Subscribers
{
    public class InitConnectSubscriber :
        ISubscribeSynchronousTo<InitAggregate, InitId, InitConnectEvent>
    {
        private readonly IJobScheduler _jobScheduler;

        public InitConnectSubscriber(
            IJobScheduler scheduler)
        {
            _jobScheduler = scheduler;
        }

        public Task HandleAsync(
            IDomainEvent<InitAggregate, InitId, InitConnectEvent> domainEvent, 
            CancellationToken cancellationToken)
        {
            var job = new InitConnectJob(
                domainEvent.AggregateIdentity);
            return _jobScheduler.ScheduleNowAsync(job, cancellationToken);
        }
    }

}