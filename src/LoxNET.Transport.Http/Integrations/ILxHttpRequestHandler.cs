using System;
using System.Threading;
using System.Threading.Tasks;

namespace LoxNET.Transport.Http.Integrations
{
    public interface ILxHttpRequestHandler
    {
        
    }

    public interface ILxHttpRequestHandler<in TRequest, TResult> : ILxHttpRequestHandler
        where TResult : ILxHttpResult
        where TRequest : ILxHttpRequest<TResult>
    {
        Task<TResult> ExecuteRequestAsync(CancellationToken cancellationToken);
    }
}