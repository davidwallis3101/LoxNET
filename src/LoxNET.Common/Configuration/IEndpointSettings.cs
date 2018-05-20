namespace LoxNET.Configuration
{

    public interface IEndpointSettings
    {
        string HostName { get; }
        int Port { get; }
        string UserName { get; }
        string Password { get; }

        
    }
}