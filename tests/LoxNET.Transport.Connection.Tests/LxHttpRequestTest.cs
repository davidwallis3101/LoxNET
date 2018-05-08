using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using LoxNET.Transport.Connection;

namespace LoxNET.Transport.Connection.Tests
{
    public class LxHttpRequestTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            try
            {
                var uri = new Uri("http://10.23.99.10");
                var rq = new LoxNET.Transport.Connection.LxHttpRequest(uri);
                var tk = new CancellationToken();
                await rq.RequestAsync("jdev/cfg/api", tk).ConfigureAwait(false);
                //using (var request = new ())
                Assert.Pass();
                //Assert.IsFalse(String.IsNullOrEmpty(result));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}