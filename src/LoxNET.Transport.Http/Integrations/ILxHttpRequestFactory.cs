using System;
using System.Threading;
using System.Threading.Tasks;

namespace LoxNET.Transport.Http.Integrations
{
    public interface ILxHttpRequestFactory
    {
        Task<ILxHttpRequest> CreateRequestAsync(Uri uri, CancellationToken cancellationToken);
        
    }
}