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
            Console.WriteLine("LoxNET.CLI");

            var bootstrap = new Bootstrap();


            new TaskFactory().StartNew(
                async () => await bootstrap.Setup()
            );

            bootstrap.Dispose();
        }
    }
}
