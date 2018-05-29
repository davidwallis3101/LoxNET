using System;
using EventFlow.Core;
using EventFlow.Logs;
using System.Threading;
using System.Threading.Tasks;
using LoxNET.Transport.Http.Results;

namespace LoxNET.Transport.Http.Integrations
{
    public class LxHttpRequestFactory : ILxHttpRequestFactory
    {
        private readonly ILog _log;

        private readonly ILxHttpConfiguration _config;

        public LxHttpRequestFactory(ILxHttpConfiguration config)
        {
            _config = config;
        }


        public LxHttpRequestFactory(ILxHttpConfiguration config, ILog log)
        {
            _config = config;
            _log = log;
        }


        public async Task<ILxHttpRequest> CreateRequestAsync(Uri uri, CancellationToken cancellationToken)
        {
            return await Task.Run(async () => {
                await Task.Delay(100);
                return new LxHttpRequest<ConfigHttpResultBase>();
            });
        }

        public async Task<ILxHttpRequest> CreateRequestAsync<TRequest>(CancellationToken cancellationToken)
            where TRequest : ILxHttpRequest
        {
            //var request = new LxHttpRequest

            //var connectionFactory = await CreateConnectionFactoryAsync(uri, cancellationToken).ConfigureAwait(false);
            //var connection = connectionFactory.CreateConnection();

            //return new RabbitConnection(_log, _configuration.ModelsPrConnection, connection);
            return await Task.Run(async () => {
                await Task.Delay(100);
                return new LxHttpRequest<ConfigHttpResultBase>();
            });

        }
        
    }
}