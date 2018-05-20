using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace LoxNET.Configuration
{
    public class LxConfiguration
    {
        //public static IConfiguration Configuration { get; set; }
        private static IEndpointSettings _epSettings = new EndpointSettings();
        private static IEventFlowSettings _efSettings = new EventFlowSettings();
        public static IEndpointSettings MiniServer { 
            get
            {
                return _epSettings;
            } 
        }
        public static IEventFlowSettings EventFlow { 
            get
            {
                return _efSettings;
            } 
        }

   }

}