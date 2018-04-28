using System;

namespace LoxNet.Transport.Domain.Model.ConnectionModel.Enums
{
    public enum ConnectionStateEnum
    {
        None,
        Connecting,
        Open,
        Closed,
        Receiving,
        CloseReceived,
        Sending,
        CloseSent
    }
}
