namespace LoxNET.Configuration
{
    public class TestMiniserverSettings : EndpointSettings
    {
        public TestMiniserverSettings(): base(
            "testminiserver.loxone.com", 
            7777, 
            "Web", 
            "Web"
        ){
        }
    }
}