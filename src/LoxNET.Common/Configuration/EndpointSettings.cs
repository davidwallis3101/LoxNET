namespace LoxNET.Configuration
{
    public class EndpointSettings : IEndpointSettings
    {
        public string HostName { get; private set; }
        public int Port { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        

        public EndpointSettings(
            string hostname, int port, 
            string username, string password)
        {
            HostName = hostname;
            Port = port;
            UserName = username;
            Password = password;
        }
    }
}