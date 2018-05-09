using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace LoxNET.Configuration
{
    public class LxConfiguration
    {
        //public static IConfiguration Configuration { get; set; }
        public static MiniserverSettings MiniServer { get; set; }
        public static EventFlowSettings EventFlow { get; set; }

        public static void Assign(
            MiniserverSettings miniserver,
            EventFlowSettings eventflow)
        {
            MiniServer = miniserver;
            EventFlow = eventflow;
        }
   }

}