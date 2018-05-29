using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LoxNET.Transport.Connection
{
    public class LxHttpRequest : ILxHttpRequest, IDisposable
    {

        /*
        private static readonly HttpClient _httpClient = new HttpClient();
        
        public static async Task<string> Get(string url)
        {
            // The actual Get method
            using (var result = await _httpClient.GetAsync(url))
            {
                string content = await result.Content.ReadAsStringAsync();
                return content;
            }
        }
         */

        private Uri _uri;

        private HttpClient _client;

        public Uri BaseUri
        {
            get 
            {
                 return _uri;
            }
            set
            {
                _uri = value;
            }
        }

        public LxHttpRequest(Uri uri)
        {
            _uri = uri;
            _client = new HttpClient();
        }

        public async Task<byte[]> GetByteArrayAsync(string path, CancellationToken token)
        {
            using (var result = await new HttpClient().GetAsync(buildUri(path), token))
            {
                byte[] content = await result.Content.ReadAsByteArrayAsync();
                return content;
            }
        }

        public void Dispose()
        {
            _client.Dispose();
            _client = null;
        }

        public async Task<string> GetStringAsync(string path, CancellationToken token)
        {
            using (var result = await new HttpClient().GetAsync(buildUri(path), token))
            {
                string content = await result.Content.ReadAsStringAsync();
                return content;
            }
        }

        private Uri buildUri(string path)
        {
            UriBuilder builder = new UriBuilder(BaseUri);
            builder.Path = path;
            return builder.Uri;            
        }

        /* 
        private Uri _uri;

        private String _mediaType;

        private HttpResponseMessage _response;

        private string _result;

        private HttpClient _client;


        public String MediaType
        {
            get
            {
                return _mediaType;
            }
        }

        public HttpResponseMessage Response
        {
            get
            {
                return _response;
            }
        }


        public String Result
        {
            get
            {
                return _result;
            }
        }

        public LxHttpRequest(Uri uri, string mediaType = "application/json")
        {
            _uri = uri;
            _mediaType = mediaType;
            _client = new HttpClient();
        }


        public async Task RequestAsync(string requestUri, CancellationToken token)
        {
            prepareClient(_client);

            _response = await executeRequestAsync(
                _client, 
                requestUri, 
                token
            ).ConfigureAwait(false);
        }


        public async Task ResultAsync()
        {

            //if (_response.IsSuccessStatusCode == false)
                //throw new HttpRequestException("Response status: " + _response.StatusCode.ToString());

            //if (!_response.Content.Headers.ContentType.Equals(_mediaType))
            //    throw new HttpRequestException("Expectet mediatype: " + _mediaType);

            await Task.FromResult(0);

            //_result = await _response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        private void prepareClient(HttpClient client)
        {
            client.BaseAddress = _uri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));
        }

        private async Task<HttpResponseMessage> executeRequestAsync(HttpClient client, string requestUri, CancellationToken token)
        {
            return await client.GetAsync(
                requestUri, 
                HttpCompletionOption.ResponseContentRead, 
                token
            ).ConfigureAwait(false);
        }
        */
    }
}