using System;

namespace LoxNET.Common
{
    public interface ILxConfiguration2
    {
        string Hostname { get; }

        int Port { get; }

        string UserName { get; } 

        string Password { get; } 
    } 
}
