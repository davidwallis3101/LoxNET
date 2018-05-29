using System;
using EventFlow;
using EventFlow.Configuration;
using LoxNET.Transport;
using LoxNET.Transport.Http.Integrations;

namespace LoxNET.Transport.Http.Extensions
{
    public static class EventFlowOptionsLxTransportHttpExtension
    {
        public static IEventFlowOptions RegisterLxTransportHttp(
            this IEventFlowOptions eventFlowOptions,
            ILxTransportConfiguration configuration)
        {
            return eventFlowOptions.RegisterServices(sr => 
            {
                sr.Register<ILxHttpRequestFactory, LxHttpRequestFactory>(Lifetime.Singleton);
                sr.Register(rc => configuration, Lifetime.Singleton);
            });
        }
    }
}