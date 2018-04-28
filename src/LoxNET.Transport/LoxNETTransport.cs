using System;
using System.Reflection;
using EventFlow;
using EventFlow.Configuration;
using EventFlow.Extensions;
using LoxNet.Transport.Domain.Model.ConnectionModel;
using LoxNet.Transport.Domain.Services;

namespace LoxNet.Transport
{
    public static class LoxNetTransport
    {
        public static Assembly Assembly { get; } = typeof(LoxNetTransport).Assembly;

        public static IEventFlowOptions ConfigureTransportDomain(this IEventFlowOptions eventFlowOptions)
        {
            return eventFlowOptions
                .AddDefaults(Assembly)
                .RegisterServices(sr => {
                    sr.Register<ISocketService, SocketService>(Lifetime.Singleton);
                });
        }

    }
    
}