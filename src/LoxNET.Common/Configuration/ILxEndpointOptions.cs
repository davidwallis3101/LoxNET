using System;

namespace LoxNET.Configuration
{
    public interface ILxEndpointOptions
    {
        string Id { get; set; } 
        string Name { get; set; } 
        string HostName { get; set; } 
        int Port { get; set; } 
        string UserName { get; set; }
        string Password { get; set; } 

        


    }
}