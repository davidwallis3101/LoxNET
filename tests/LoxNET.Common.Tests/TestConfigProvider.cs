using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using LoxNET.Common;
using LoxNET.Configuration;

namespace LoxNET.Common.Tests
{
    /* 
    public class TestConfigProvider : ILxConfigurationProvider
    {
        public TestConfigProvider()
        {
            //AppSettingsProvider.Configure();
            //new AppSettingsProvider().Build();

            /*
            var provider = new LxConfigurationProvider();
            provider.Build();
            */
    /* 
        }

        public void Prepare(IConfigurationBuilder builder)
        {
            var configs = new Dictionary<string, string> {  
                {"MiniServer:HostName", "testminiserver.loxone.com"},
                {"MiniServer:Port", "7777"},
                {"MiniServer:UserName", "web"},
                {"MiniServer:Password", "web"},
            };
            var miniserverSection = builder.AddInMemoryCollection(configs); 
        }

    }
        */
}
