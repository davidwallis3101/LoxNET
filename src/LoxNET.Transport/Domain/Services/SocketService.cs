using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using EventFlow;
using LoxNET.Transport.Domain.Model.ClientModel;
using LoxNET.Transport.Domain.Model.ClientModel.Commands;
using LoxNET.Transport.Domain.Model.ClientModel.ValueObjects;
using LoxNET.Transport.Domain.Model.ConnectionModel;
using LoxNET.Transport.Domain.Model.ConnectionModel.Commands;
using LoxNET.Transport.Domain.Model.ConnectionModel.ValueObjects;

namespace LoxNET.Transport.Domain.Services
{
    public class SocketService : ISocketService, IDisposable
    {
        private ClientWebSocket _socket;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly CancellationToken _cancellationToken;        

        private readonly ICommandBus _commandBus;

        public SocketService(ICommandBus commandBus)
        {
            _socket = new ClientWebSocket();
            _commandBus = commandBus;
            _cancellationToken = new CancellationToken();
        }

        public async Task OpenAsync(ClientId id, string Hostname, int port, CancellationToken token)
        {
            var builder = new UriBuilder
            {
                Host = Hostname,
                Port = port,
                Scheme = "ws",
                Path = "ws/rfc6455"
            };

            await _socket.ConnectAsync(
                builder.Uri, 
                token
            ).ConfigureAwait(false);
            
            await _commandBus.PublishAsync(
                new ConnectCommand(
                    id, 
                    new Endpoint(Hostname, port)), 
                token
            ).ConfigureAwait(false);
        }

        public async Task SendAsync(CancellationToken token)
        {
            await Task.FromResult(0);
        }

        public void Listen()
        {
            Task.Factory.StartNew(
                async () => await StartListening(), 
                new CancellationToken(), 
                TaskCreationOptions.LongRunning, 
                TaskScheduler.Default
            );
        }
        public async Task StartListening()
        {
            try 
            {
                while (_socket.State == WebSocketState.Open)
                {
                    var header = await retrieveAsync(8).ConfigureAwait(false);
                    var contentSize = header.ElementAt(2);
                    var content = await retrieveAsync(contentSize).ConfigureAwait(false);

                    await _commandBus.PublishAsync(
                        new ConnectionReceivedCommand(
                            new ConnectionId("ABCD"),
                            new ConnectionReceivedContext(header, content)
                        ), 
                        _cancellationToken
                    ).ConfigureAwait(false);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _socket.Dispose();
        }


        private async Task<IEnumerable<byte>> retrieveAsync(int size)
        {
            var rcvResult = new List<byte>();
            var rcvBytes = new byte[1024];
            var rcvBuffer = new ArraySegment<byte>(rcvBytes);

            WebSocketReceiveResult result;
            do
            {
                result = await _socket.ReceiveAsync(
                    rcvBuffer, 
                    _cancellationToken
                ).ConfigureAwait(false);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _socket.CloseAsync(
                        WebSocketCloseStatus.NormalClosure, 
                        string.Empty, 
                        CancellationToken.None
                    ).ConfigureAwait(false);
                    
                    await _commandBus.PublishAsync(
                        new ConnectionClosedCommand(new ConnectionId("ABCD")), 
                        _cancellationToken
                    ).ConfigureAwait(false);

                }
                else
                {
                    rcvResult.AddRange(rcvBuffer);
                }

            } while (!result.EndOfMessage);      

            return rcvResult.Take(size);      
        }
    }
}
