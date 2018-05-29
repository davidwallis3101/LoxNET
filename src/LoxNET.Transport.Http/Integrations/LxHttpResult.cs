using System;

namespace LoxNET.Transport.Http.Integrations
{
    public class LxHttpResult : ILxHttpResult
    {
        public string Control { get; set; }

        public int Code { get; set; }
    }
}