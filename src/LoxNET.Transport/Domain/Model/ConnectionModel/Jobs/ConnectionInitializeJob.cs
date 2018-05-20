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

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using EventFlow.Configuration;
using LoxNET.Transport.Domain.Model.ConnectionModel.Commands;
using LoxNET.Transport.Domain.Services;
using EventFlow;
using EventFlow.Exceptions;
using EventFlow.Jobs;
using EventFlow.Queries;
using LoxNET.Configuration;
using LoxNET.Transport.Connection;

namespace LoxNET.Transport.Domain.Model.ConnectionModel.Jobs
{
    public class InitializeConnectionJob : IJob
    {
        public InitializeConnectionJob(
            ConnectionId id)
        {
            ConnectionId = id;
        }

        public ConnectionId ConnectionId { get; }

        public async Task ExecuteAsync(IResolver resolver, CancellationToken cancellationToken)
        {
            var commandBus = resolver.Resolve<ICommandBus>();
            var requestFactory = resolver.Resolve<ILxHttpRequestFactory>();
            //var websocketFactory = resolver.Resolve<ILxWebSocketFactory>();

            var miniServerCfg = LxConfiguration.MiniServer;
            UriBuilder builder = new UriBuilder(
                "http", 
                miniServerCfg.HostName,
                miniServerCfg.Port
            );
            builder.UserName = miniServerCfg.UserName;
            builder.Password = miniServerCfg.Password;

            var request = await requestFactory.CreateAsync(builder.Uri,
                cancellationToken).ConfigureAwait(false);

            var result = await request.GetStringAsync("jdev/cfg/api", 
                cancellationToken).ConfigureAwait(false);


            await commandBus.PublishAsync(new ConnectionInitializedCommand(ConnectionId, null), cancellationToken).ConfigureAwait(false);
        }
    }
}