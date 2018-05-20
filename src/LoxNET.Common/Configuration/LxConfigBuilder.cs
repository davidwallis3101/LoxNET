using System;
using System.IO;
using System.Collections.Generic;
using EventFlow.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;

namespace LoxNET.Configuration
{
    public class LxConfigBuilder
    {

        public ILxSettings Build()
        {
            var settings = new LxSettings();
            var builder = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()
            );
            builder.AddAppSettings();

            var root = builder.Build();

            root.GetSection("EventFlow").Bind(settings.EventFlowOptions);
            foreach (var ep in root.GetSection("MiniServers").GetChildren())
            {
                var lxEp = new LxEndpointOptions();
                ep.Bind(lxEp);
                settings.RegisterLxEndpoint(lxEp);
            }
            return settings;
        }
        
    }
}