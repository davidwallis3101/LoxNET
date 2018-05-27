using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Core;
using EventFlow.Logs;
using LoxNET.Transport;

namespace LoxNET.Transport.Http.Integrations
{
    public class LxHttpConnection : ILxHttpConnection
    {
        private readonly ILog _log;

        public LxHttpConnection(ILog log)
        {
            _log = log;
        }

        public async Task<ILxHttpResult> RequestStringAsync(string path, CancellationToken token)
        {
            return await Task.Run(async () => {
                await Task.Delay(100);
                return new LxHttpResult();
            });
        }

        public async Task<ILxHttpResult> RequestByteArrayAsync(string path, CancellationToken token)
        {
            return await Task.Run(async () => {
                await Task.Delay(100);
                return new LxHttpResult();
            });
        }
    }
}