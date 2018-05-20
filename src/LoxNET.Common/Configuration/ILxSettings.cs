using System;
using System.Collections.Generic;

namespace LoxNET.Configuration
{
    public interface ILxSettings
    {
        ILxEventFlowOptions EventFlowOptions { get; }

        IEnumerable<ILxEndpointOptions> MiniServerOptions { get; }
        int MiniServerOptionsCount { get; }
        void RegisterLxEndpoint(ILxEndpointOptions endpoint);

        //IEnumerable<ILxEventFlowOptions2> MiniServerOptions { get; }
    }
}