using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.ClientModel.ValueObjects
{
    public class HostAddress : SingleValueObject<string>
    {
        public HostAddress(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
                throw DomainError.With($"Invalid HostAddress '{value}'");
        }
    }
}
