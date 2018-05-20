// The MIT License (MIT)
// 
// Copyright (c) 2015-2018 Rasmus Mikkelsen
// Copyright (c) 2015-2018 eBay Software Foundation
// https://github.com/eventflow/EventFlow
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Threading;
using System.Threading.Tasks;
using LoxNET.Common;
using LoxNET.Configuration;
using EventFlow;
using EventFlow.Logs;
using EventFlow.Configuration;

namespace LoxNET.Transport.Connection
{
    public class LxHttpRequestFactory : ILxHttpRequestFactory
    {
        private readonly ILxConfiguration _configuration;
        private readonly ILog _log;

        public LxHttpRequestFactory(ILxConfiguration configuration, ILog log)
        {
            _configuration = configuration;
            _log = log;
        }

        public async Task<ILxHttpRequest> CreateAsync(CancellationToken token)
        {
            UriBuilder builder = new UriBuilder(
                "http", 
                _configuration.MiniServer.HostName,
                _configuration.MiniServer.Port
            );

            builder.UserName = _configuration.MiniServer.UserName;
            builder.Password = _configuration.MiniServer.Password;

            var request = new LxHttpRequest(builder.Uri);

            return await Task.FromResult<ILxHttpRequest>(request); 
        }
    }
}