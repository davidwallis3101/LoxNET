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
using System.Net.WebSockets;

namespace LoxNET.Transport.Connection 
{
    public class LxConnection : ILxConnection
    {
        private LxConnectionState _state;
        private ClientWebSocketOptions _options;

        private ClientWebSocket _socket;

        public LxConnectionState State 
        { 
            get 
            {
                return _state;
            } 
        }
        public ClientWebSocketOptions Options 
        { 
            get 
            {
                return _socket.Options;
            }
        }

        public LxConnection()
        {
            _state = LxConnectionState.Closed;
            _socket = new ClientWebSocket();
        }

        public async Task ConnectAsync(Uri uri, CancellationToken cancellationToken)
        {

        }

        public async Task<ILxReceiveResult> ReceiveAsync(CancellationToken cancellationToken)
        {
            return new LxReceiveResult();
        }

        public async Task SendAsync(ILxSendContent content, CancellationToken cancellationToken)
        {
            
        }

        public async Task CloseAsync(string statusDescription, CancellationToken cancellationToken)
        {
            
        }
    }
}