using System;
using Xunit;
using LoxNET.Common;
using LoxNET.Configuration;

namespace LoxNET.Common.Tests
{
    
    public class ConfigurationTests
    {
        private readonly LxConfiguration config;

        public ConfigurationTests()
        {
            var provider = new LxConfigurationProvider();
            provider.Build();
        }

        [Fact]
        public void HostnameIsNull()
        {

            Assert.False(config.MiniServer.HostName != null);
        }
    }
}
