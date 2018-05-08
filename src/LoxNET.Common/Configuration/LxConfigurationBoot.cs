using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace LoxNET.Configuration
{
    public class LxConfigurationBoot
    {
        public static IConfiguration Configuration { get; set; }

        public static void Setup()
        {
            string dir = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(dir)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();            
        }
    }

}