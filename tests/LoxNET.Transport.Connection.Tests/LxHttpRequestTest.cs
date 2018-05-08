using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using LoxNET.Transport.Connection;

namespace LoxNET.Transport.Connection.Tests
{
    public class LxHttpRequestTest
    {
        private string _serverUri;

        [SetUp]
        public void Setup()
        {
            _serverUri = "http://10.23.99.10";
        }

        [Test]
        public async Task TestRequest()
        {
            UriBuilder builder = new UriBuilder(_serverUri);
            //UriBuilder builder = new UriBuilder("http://testminiserver.loxone.com:7777");
            using (var request = new LxHttpRequest(builder.Uri))
            {
                CancellationToken token = new CancellationToken();
                string result = request.GetStringAsync("jdev/cfg/api", token).Result;
                Assert.IsFalse(String.IsNullOrEmpty(result));
            }            
        }

        [Test]
        public async Task TestRequestFactory()
        {
            UriBuilder builder = new UriBuilder(_serverUri);
            //UriBuilder builder = new UriBuilder("http://testminiserver.loxone.com:7777");
            using (var request = new LxHttpRequest(builder.Uri))
            {
                CancellationToken token = new CancellationToken();
                string result = request.GetStringAsync("jdev/cfg/api", token).Result;
                Assert.IsFalse(String.IsNullOrEmpty(result));
            }            
        }
    }
}