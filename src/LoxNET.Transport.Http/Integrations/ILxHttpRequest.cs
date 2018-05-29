using System;

namespace LoxNET.Transport.Http.Integrations
{
    public interface ILxHttpRequest
    {

    }

    public interface ILxHttpRequest<TResult> : ILxHttpRequest
        where TResult : ILxHttpResult
    {
        string Control { get; }
    }
}