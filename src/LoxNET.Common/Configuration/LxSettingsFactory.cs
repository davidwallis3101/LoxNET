using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;

namespace LoxNET.Configuration 
{
    public class LxSettingsFactory
    {
        private static IConfiguration config { get; set; }

        public static void Init()
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()
            );

            buildFromJsonFile(builder, "appsettings.sample.json");
            buildFromJsonFile(builder, "appsettings.json");
            
            config = builder.Build();

            initSettings();
            bindSetting("MiniServer");
            bindSetting("EventFlow");
        }

        private static void buildFromJsonFile(IConfigurationBuilder builder, string filename)
        {
            if (File.Exists(filename))
                builder.AddJsonFile(filename);
        }

        private static void initSettings()
        {
            LxConfiguration.Assign(
                new MiniserverSettings(),
                new EventFlowSettings()
            );
        }

        private static void bindSetting(string key)
        {
            IConfigurationSection section = config.GetSection(key);
            if (section == null)
                throw new NullReferenceException(key);

            switch (key)
            {
                case "MiniServer":  
                    section.Bind(LxConfiguration.MiniServer);
                    break;
                case "EventFlow":  
                    section.Bind(LxConfiguration.EventFlow);
                    break;
            }
        }
    }
}