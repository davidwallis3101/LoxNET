using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;

namespace LoxNET.Configuration
{
    public static class LxConfigExtensions
    {
        public static IConfigurationBuilder AddTestMiniServer(
            this IConfigurationBuilder builder)
        {
            return builder.Add(new MiniServerTestConfigSource());
        }
        public static IConfigurationBuilder AddAppSettings(
            this IConfigurationBuilder builder)
        {
            return builder
                .AddJsonFile("appsettings.json",  optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.sample.json", optional: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
                //.Add
        }
    }
}
