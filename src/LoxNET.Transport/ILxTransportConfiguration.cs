using System;

namespace LoxNET.Transport
{
    public interface ILxTransportConfiguration
    {
        Uri Uri { get; }
    }
}