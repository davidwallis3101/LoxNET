using System;
using EventFlow.ValueObjects;
using EventFlow.Exceptions;

namespace LoxNET.Transport.Domain.Model.ClientModel.ValueObjects
{
    public class HostUsername : SingleValueObject<string>
    {
        public HostUsername(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
                throw DomainError.With($"Invalid Username '{value}'");
        }
    }
}
