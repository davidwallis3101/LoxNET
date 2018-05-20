using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;

namespace LoxNET.Configuration
{
    public class LxConfigurationProvider : ILxConfigurationProvider
    {
        public static readonly ILxConfiguration Config = new LxConfiguration();

        private IConfigurationRoot configRoot; 

        public IConfigurationSection MiniServerSection 
        {
            get
            {
                var key = "MiniServer";
                var section = configRoot.GetSection(key);
                if (section == null)
                    throw new NullReferenceException(key);

                return section;
            }
        }
        public IConfigurationSection EventFlowSection 
        {
            get 
            {
                var key = "EventFlow";
                var section = configRoot.GetSection(key);
                if (section == null)
                    throw new NullReferenceException(key);

                return section;
            }
        }

        public void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()
            );

            Prepare(builder);

            configRoot = builder.Build();

            MiniServerSection.Bind(Config.MiniServer);

            EventFlowSection.Bind(Config.EventFlow);

        } 

        public virtual void Prepare(IConfigurationBuilder builder)
        {

        }
    }
}

