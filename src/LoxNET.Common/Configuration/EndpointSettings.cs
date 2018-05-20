namespace LoxNET.Configuration
{
    public class EndpointSettings : IEndpointSettings
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        

        public EndpointSettings()
        {
        }
    }
}