using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LoxNET.Transport.Http.Integrations
{
    public class LxHttpRequestHandler<TRequest, TResult> : ILxHttpRequestHandler<TRequest, TResult>
        where TResult : ILxHttpResult, new()
        where TRequest : ILxHttpRequest<TResult>
    {
        public async Task<TResult> ExecuteRequestAsync(CancellationToken cancellationToken)
        {
            Uri uri = new Uri("");

            using (var result = await new HttpClient().GetAsync(uri, cancellationToken))
            {
                string content = await result.Content.ReadAsStringAsync();
            }



            //await ExecuteRequestAsync(
            //        request, 
            //        cancellationToken
            //    ).ConfigureAwait(false);

            return new TResult();
        }

    }
}