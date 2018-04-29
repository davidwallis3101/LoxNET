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
                async () => await Setup().ConfigureAwait(false)
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
    }
}
