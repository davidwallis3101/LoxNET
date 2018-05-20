namespace LoxNET.Configuration
{
    public class LxEndpointOptions : ILxEndpointOptions
    {
        public string Id { get; set; } 
        public string Name { get; set; } 
        public string HostName { get; set; } 
        public int Port { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; } 



    }
}