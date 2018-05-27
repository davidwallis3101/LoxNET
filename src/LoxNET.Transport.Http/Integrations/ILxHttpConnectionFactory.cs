using System;
using System.Threading;
using System.Threading.Tasks;

namespace LoxNET.Transport.Http.Integrations
{
    public interface ILxHttpConnectionFactory
    {
        Task<ILxHttpConnection> CreateHttpConnectionAsync(Uri uri, CancellationToken cancellationToken);
    }    
}

