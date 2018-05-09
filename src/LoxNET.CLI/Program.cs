using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Aggregates;
using EventFlow.Configuration;
using EventFlow.Core;
using LoxNET.Transport;
using LoxNET.Transport.Connection;
using LoxNET.Configuration;
using LoxNET.Transport.Domain.Services;
using LoxNET.Transport.Domain.Model.ClientModel;
using LoxNET.Transport.Domain.Model.ClientModel.ValueObjects;
using LoxNET.Transport.Domain.Model.ClientModel.Entities;
using EventFlow.Extensions;
using EventFlow.Logs;
using LoxNET.Serialization;

namespace LoxNET.CLI
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("LoxNET.CLI start");
            LxSettingsFactory.Init();

            Console.WriteLine(LxConfiguration.MiniServer.HostName);
                        
            //string uri = "http://10.23.99.10/jdev/cfg/api";
            UriBuilder builder = new UriBuilder("http://10.23.99.10");
            using (var request = new LxHttpRequest(builder.Uri))
            {
                CancellationToken token = new CancellationToken();
                string result = request.GetStringAsync("jdev/cfg/api", token).Result;
                Console.WriteLine(result);

                var res = ResultConverter.Deserialize(result);
            }            
            Console.WriteLine("LoxNET.CLI end");
        }



        static async Task Setup()
        {
            Console.WriteLine("LoxNET.CLI setup start");
            var bootstrap = new Bootstrap();
            await bootstrap.SetupAsync().ConfigureAwait(false);
            Console.WriteLine("LoxNET.CLI setup end");

        }

        static void Request()
        {




            //var rq = new LoxNET.Transport.Connection.LxHttpRequest(uri);
            //var tk = new CancellationToken();
            //Task t1 = rq.RequestAsync("jdev/cfg/api", tk);
            //Task t2 = rq.ResultAsync();

            /* 

            Task[] tasks = new Task[2];
            tasks[0] = rq.RequestAsync("jdev/cfg/api", tk);
            tasks[1] = rq.ResultAsync();

            Task.WaitAll(tasks);

//            Console.WriteLine(rq.Response.Status);
            Console.WriteLine("LoxNET.CLI request end");
            */
        }
    }
}
