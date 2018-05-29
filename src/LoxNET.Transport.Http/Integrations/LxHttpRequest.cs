using System;

namespace LoxNET.Transport.Http.Integrations
{
    public class LxHttpRequest<TResult> : ILxHttpRequest<TResult>
        where TResult : ILxHttpResult, new()
    {
        public string Control { get; set; }

        public Type ResultType { get; set; }

        public LxHttpRequest()
        {
            Control = String.Empty;
            ResultType = typeof(TResult);
        }
    }
}