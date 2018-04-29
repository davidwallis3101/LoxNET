using System;
using System.Threading;
using System.Threading.Tasks;
using LoxNET.Transport.Domain.Model.ClientModel;
using LoxNET.Transport.Domain.Model.ClientModel.ValueObjects;
using LoxNET.Transport.Domain.Model.ConnectionModel;

namespace LoxNET.Transport.Domain.Services
{
    public interface ISocketService
    {
        Task OpenAsync(ClientId id, string Hostname, int port, CancellationToken token);
        Task SendAsync(CancellationToken token);
        void Listen();       
    }
}

