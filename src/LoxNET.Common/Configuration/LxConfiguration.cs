using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace LoxNET.Configuration
{
    public class LxConfiguration
    {
        //public static IConfiguration Configuration { get; set; }
        public static IEndpointSettings MiniServer { get; private set; }
        public static EventFlowSettings EventFlow { get; private set; }

        public static void Assign(
            IEndpointSettings miniserver,
            EventFlowSettings eventflow)
        {
            MiniServer = miniserver;
            EventFlow = eventflow;
        }
   }

}