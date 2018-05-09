namespace LoxNET.Configuration
{

    public interface IEndpointSettings
    {
        string HostName { get; set; }
        int Port { get; set; }
        string UserName { get; set; }
        string Password { get; set; }

        
    }
}