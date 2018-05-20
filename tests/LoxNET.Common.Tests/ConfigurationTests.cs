using System;
using System.Collections.Generic;
using Xunit;
using LoxNET.Common;
using LoxNET.Configuration;

namespace LoxNET.Common.Tests
{
    
    public class ConfigurationTests
    {
        private LxSettings config;

        public ConfigurationTests()
        {
            //AppSettingsProvider.Configure();
            //new AppSettingsProvider().Build();

            /*
            var provider = new LxConfigurationProvider();
            provider.Build();
            */
        }

        [Fact]
        public void HostnameIsNull()
        {
            var factory = new LxSettingsFactory();
            //actory.Register(new TestConfigProvider());
            var config = factory.Configure();
            
            var eps = new List<ILxEndpointOptions>(
                config.MiniServerOptions
            );

            Assert.Equal(eps.Count, 1);
        }
    }
}
