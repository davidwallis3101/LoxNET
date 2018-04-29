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
    public class InitCheckSubscriber :
        ISubscribeSynchronousTo<InitAggregate, InitId, InitCheckEvent>
    {
        private readonly IJobScheduler _jobScheduler;

        public InitCheckSubscriber(
            IJobScheduler scheduler)
        {
            _jobScheduler = scheduler;
        }

        public Task HandleAsync(
            IDomainEvent<InitAggregate, InitId, InitCheckEvent> domainEvent, 
            CancellationToken cancellationToken)
        {
            var job = new InitCheckJob(
                domainEvent.AggregateIdentity);
            return _jobScheduler.ScheduleNowAsync(job, cancellationToken);
        }
    }

}