using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;

namespace LoxNET.Configuration 
{
    public class LxSettingsFactory
    {
        public LxSettingsFactory()
        {
        }

        public ILxSettings Configure()
        {
            var settings = new LxConfigBuilder().Build();

            if (settings.MiniServerOptionsCount == 0)
            {
                var ep = new LxEndpointOptions();
                ep.HostName = "192.168.0.77";
                ep.Port = 80;
                ep.UserName = "admin";
                ep.Password = "P@55w0rd";
                settings.RegisterLxEndpoint(ep);
            }

            return settings;
        }
    }
}