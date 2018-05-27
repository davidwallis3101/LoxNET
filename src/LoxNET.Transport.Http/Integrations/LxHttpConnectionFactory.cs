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
    public class LxHttpConnectionFactory : ILxHttpConnectionFactory
    {
        private readonly ILog _log;

        private readonly ILxTransportConfiguration _configuration;

        public LxHttpConnectionFactory(
            ILog log,
            ILxTransportConfiguration configuration) 
        {
            _log = log;
            _configuration = configuration;
        }

        public async Task<ILxHttpConnection> CreateHttpConnectionAsync(Uri uri, CancellationToken cancellationToken)
        {
            return await Task.Run(() => 
                {
                    var connection = new LxHttpConnection(_log); 
                    return connection;
                });
        }
    }
}