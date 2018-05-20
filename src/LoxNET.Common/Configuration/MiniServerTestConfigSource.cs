using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;

namespace LoxNET.Configuration
{
    public class MiniServerTestConfigSource : MemoryConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var provider = new MemoryConfigurationProvider(this);
            provider.Add("MiniServer:HostName", "testminiserver.loxone.com"); 
            provider.Add("MiniServer:Port", "7777"); 
            provider.Add("MiniServer:UserName", "web"); 
            provider.Add("MiniServer:Password", "web"); 
            return provider;
        }
        
    }
}
