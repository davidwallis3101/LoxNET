namespace LoxNET.Configuration
{
    public class MiniserverSettings : BaseEndpointSettings
    {
        public MiniserverSettings()
        {
            HostName = "testminiserver.loxone.com";
            Port = 7777;
            UserName = "Web";
            Password = "Web";
        }
    }
}