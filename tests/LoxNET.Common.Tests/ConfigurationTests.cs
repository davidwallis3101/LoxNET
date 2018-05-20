using System;
using Xunit;
using LoxNET.Common;
using LoxNET.Configuration;

namespace LoxNET.Common.Tests
{
    
    public class ConfigurationTests
    {
        private LxConfiguration config;

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
            factory.Register(new TestConfigProvider());
            var config = factory.Configure();
            
            Assert.Equal(config.MiniServer.HostName, "testminiserver.loxone.com");
        }
    }
}
