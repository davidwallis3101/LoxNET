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
    public class InitAuthSubscriber :
        ISubscribeSynchronousTo<InitAggregate, InitId, InitAuthEvent>
    {
        private readonly IJobScheduler _jobScheduler;

        public InitAuthSubscriber(
            IJobScheduler scheduler)
        {
            _jobScheduler = scheduler;
        }

        public Task HandleAsync(
            IDomainEvent<InitAggregate, InitId, InitAuthEvent> domainEvent, 
            CancellationToken cancellationToken)
        {
            var job = new InitCheckJob(
                domainEvent.AggregateIdentity);
            return _jobScheduler.ScheduleNowAsync(job, cancellationToken);
        }
    }

}