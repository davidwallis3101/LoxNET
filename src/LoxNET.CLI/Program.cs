using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Aggregates;
using EventFlow.Configuration;
using EventFlow.Core;
using LoxNET.Transport;
using LoxNET.Transport.Domain.Services;
using LoxNET.Transport.Domain.Model.ClientModel;
using LoxNET.Transport.Domain.Model.ClientModel.ValueObjects;
using EventFlow.Extensions;
using EventFlow.Logs;

namespace LoxNET.CLI
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("LoxNET.CLI start");

            //await Setup().ConfigureAwait(false);
            /*await new TaskFactory().StartNew(
                async () => 

            );*/


            var task = new TaskFactory().StartNew(
                //async () => await Setup().ConfigureAwait(false)
                async () => await Request().ConfigureAwait(false)
                //)
            );
            while (!task.IsCompleted)
            {
                Console.WriteLine("wait.....");
                Thread.Sleep(1000);
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

        static async Task Request()
        {
            var uri = new Uri("http://10.23.99.10");
            var rq = new LoxNET.Transport.Connection.LxHttpRequest(uri);
            var tk = new CancellationToken();
            //Task t1 = rq.RequestAsync("jdev/cfg/api", tk);
            //Task t2 = rq.ResultAsync();

            Task[] tasks = new Task[2];
            tasks[0] = rq.RequestAsync("jdev/cfg/api", tk);
            tasks[1] = rq.ResultAsync();

            await Task.WhenAll(tasks);

            Console.WriteLine(rq.Result);
            Console.WriteLine("LoxNET.CLI request end");
        }
    }
}
