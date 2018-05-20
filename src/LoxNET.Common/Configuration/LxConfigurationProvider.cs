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
        public static LxConfiguration Config = new LxConfiguration();

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

            var msKey = "MiniServer";
            var msSection = configRoot.GetSection(msKey);
            if (msSection == null)
                throw new NullReferenceException(msKey);
            msSection.Bind(Config.MiniServer);

            var efKey = "EventFlow";
            var efSection = configRoot.GetSection(efKey);
            if (efSection == null)
                throw new NullReferenceException(efKey);
            efSection.Bind(Config.EventFlow);

        } 

        public virtual void Prepare(IConfigurationBuilder builder)
        {

        }
    }
}

