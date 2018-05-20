using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace LoxNET.Configuration
{
    public class LxConfiguration : ILxConfiguration
    {
        //public static IConfiguration Configuration { get; set; }
        private IEndpointSettings _epSettings = new EndpointSettings();
        private IEventFlowSettings _efSettings = new EventFlowSettings();
        public IEndpointSettings MiniServer { 
            get
            {
                return _epSettings;
            } 
        }
        public IEventFlowSettings EventFlow { 
            get
            {
                return _efSettings;
            } 
        }

   }

}