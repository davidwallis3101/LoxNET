namespace LoxNET.Configuration
{
    public class TestMiniserverSettings : EndpointSettings
    {
        public TestMiniserverSettings()
        {
            HostName = "testminiserver.loxone.com"; 
            Port = 7777; 
            UserName = "Web"; 
            Password = "Web";
        }
    }
}