namespace LoxNET.Configuration
{
    public class LxConnectionOptions
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public LxConnectionOptions()
        {
            HostName = "testminiserver.loxone.com";
            Port = 7777;
            UserName = "Web";
            Password = "Web";
        }
    }
}