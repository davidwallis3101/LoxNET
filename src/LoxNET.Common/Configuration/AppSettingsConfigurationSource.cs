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
    public class AppSettingsConfigurationSource : MemoryConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var provider = new MemoryConfigurationProvider(this);
            return provider;
        }
    }
}