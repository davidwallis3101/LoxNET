using System;
using System.Net;
using LoxNET.Transport.Http;
using LoxNET.Transport.Http.Integrations;
using LoxNET.Transport.Http.Requests;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LoxNET.Transport.Http.Tests
{
    public class RequestFactoryTest
    {
        private ILxHttpConfiguration _config;

        public RequestFactoryTest()
        {
            UriBuilder builder = new UriBuilder(
                "http", 
                "testminiserver.loxone.com",
                7777
            );
            builder.UserName = "web";
            builder.Password = "web";
            
            _config = LxHttpConfiguration.With(builder.Uri);
        }


        [Fact]
        public void PassingTest()
        {
            var factory = new LxHttpRequestFactory(_config);
            var token = new CancellationToken();
            var res = Task.Run(async () => {
                return await factory
                    .CreateRequestAsync<ConfigHttpRequestBase>(token)
                    .ConfigureAwait(false);
            });
            Assert.NotNull(res);
            //var request = factory.Create
            Assert.Equal(4, 2+2);
        }

    }
}
