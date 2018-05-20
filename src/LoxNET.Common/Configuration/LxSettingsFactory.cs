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
        private List<ILxConfigurationProvider> _providers = new List<ILxConfigurationProvider>();

        public LxSettingsFactory()
        {
        }

        public void Register(ILxConfigurationProvider provider)
        {
            _providers.Add(provider);
        }

        public ILxConfiguration Configure()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()
            );

            foreach (ILxConfigurationProvider provider in _providers)
            {
                provider.Prepare(builder);
            }

            var config = new LxConfiguration();
            var root = builder.Build();
            
            BindSection(root, "MiniServer", config.MiniServer);
            BindSection(root, "EventFlow", config.EventFlow);

            /*
            var msKey = "MiniServer";
            if (configRoot.HasSection(msKey))
            {
                var msSection = configRoot.GetSection(msKey);
                if (msSection == null)
                    throw new NullReferenceException(msKey);
                msSection.Bind(config.MiniServer);
            }

            var efKey = "EventFlow";
            var efSection = configRoot.GetSection(efKey);
            if (efSection == null)
                throw new NullReferenceException(efKey);
            efSection.Bind(config.EventFlow);
            */

            return config;
        }

        private void BindSection(IConfigurationRoot root, string key, object bindingDestination)
        {
            var section = root.GetSection(key);
            if (section == null)
                throw new NullReferenceException(key);
            section.Bind(bindingDestination);
        }
    }
}