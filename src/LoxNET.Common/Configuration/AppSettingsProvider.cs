using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;

namespace LoxNET.Configuration
{
    public class AppSettingsProvider : LxConfigurationProvider
    {
        public void Prepare(IConfigurationBuilder builder)
        {
            string fn = "appsettings.sample.json";
            if (File.Exists(fn))
                builder.AddJsonFile(fn);
            fn = "appsettings.json";
            if (File.Exists(fn))
                builder.AddJsonFile(fn);
        }
        
    }
}

