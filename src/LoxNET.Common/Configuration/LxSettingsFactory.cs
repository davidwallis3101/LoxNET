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
                ep.HostName = "testminiserver.loxone.com";
                ep.Port = 7777;
                ep.UserName = "web";
                ep.Password = "web";
                settings.RegisterLxEndpoint(ep);
            }

            return settings;
        }
    }
}