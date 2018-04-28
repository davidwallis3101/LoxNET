using System;
using System.Threading;
using System.Threading.Tasks;
using LoxNet.Transport.Domain.Model.ConnectionModel;

namespace LoxNet.Transport.Domain.Services
{
    public interface ISocketService
    {
        Task OpenAsync(ConnectionId id, string ipaddress, int port, CancellationToken token);
        Task SendAsync(CancellationToken token);
        void Listen();       
    }
}

