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

using EventFlow.Aggregates;
using EventFlow.Extensions;
using LoxNET.Transport.Domain.Model.ConnectionModel.Events;
using LoxNET.Transport.Domain.Model.ConnectionModel.ValueObjects;
using LoxNET.Transport.Domain.Model.ConnectionModel.Enums;

namespace LoxNET.Transport.Domain.Model.ConnectionModel
{
    public class ConnectionState : AggregateState<ConnectionAggregate, ConnectionId, ConnectionState>,
        IApply<EndpointAvailableEvent>,
        IApply<ConnectionOpenedEvent>,
        IApply<ConnectionClosedEvent>,
        IApply<ConnectionChangedEvent>,
        IApply<ConnectionReceivedEvent>
    {
        public EndpointContext Endpoint { get; set; }

        public ConnectionUriContext Uri { get; set; }

        public ConnectionStateContext State  { get; set; }


        public ConnectionState()
        {
            State = new ConnectionStateContext(ConnectionStateEnum.Closed);
        }

        public void Apply(EndpointAvailableEvent evt)
        {
            Endpoint = evt.Endpoint;
        }

        public void Apply(ConnectionOpenedEvent evt)
        {
            Uri = evt.Uri;
            State = new ConnectionStateContext(ConnectionStateEnum.Open);
        }
        public void Apply(ConnectionClosedEvent evt)
        {
            State = new ConnectionStateContext(ConnectionStateEnum.Closed);

        }
        public void Apply(ConnectionSentEvent evt)
        {

        }
        
        public void Apply(ConnectionChangedEvent evt)
        {
            State = new ConnectionStateContext(evt.State.Value);
        }
        public void Apply(ConnectionReceivedEvent evt)
        {
            
        }
    }
}
