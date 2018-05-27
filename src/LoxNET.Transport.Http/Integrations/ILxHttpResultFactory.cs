using System;

namespace LoxNET.Transport.Http.Integrations
{
    public interface ILxHttpResultFactory
    {
        Task<ILxHttpResult> CreateHttpResultAsync(Uri uri, CancellationToken cancellationToken);
        
    }
}