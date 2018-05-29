using System;
using LoxNET.Transport.Http.Integrations;
using LoxNET.Transport.Http.Results;

namespace LoxNET.Transport.Http.Requests
{
    public class ConfigHttpRequestBase : LxHttpRequest<ConfigHttpResultBase>
    {
        private string _basePath = "jdev/cfg/";

        public ConfigHttpRequestBase()
        {
            Control = "jdev/cfg/version";
        }
    }
}